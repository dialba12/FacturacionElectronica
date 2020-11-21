using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FacturacionElectronica.BL;
using FacturacionElectronica.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FacturacionElectronica.UI.Controllers
{
    [Authorize]
    public class FacturacionController : Controller
    {
        private readonly IRepositorioFacturacion Repositorio;

        public FacturacionController(IRepositorioFacturacion repositorio)
        {
            Repositorio = repositorio;
        }



        public ActionResult ListarFacturas()
        {
            List<Factura> ListaDeFacturas;
            ListaDeFacturas = Repositorio.ObtenerFactura();

            return View(ListaDeFacturas);
        }

        public ActionResult ConsultarFactura(int id)

        {
            List<Factura> ListaDeFacturas;
            ListaDeFacturas = Repositorio.ObtenerFacturaPorIdentificacion(id);

            Factura factura;


            if (ListaDeFacturas.Count.Equals(0))
            {
                return RedirectToAction("NoExisteFactura", "Facturacion");
            }
            else
            {
                factura = ListaDeFacturas.First();
            }
            return View(factura);
        }

        public ActionResult NoExisteFactura()

        {

            return View();
        }

        public ActionResult EliminarFactura(int id)

        {
            Factura factura;
            factura = Repositorio.ObtenerFacturaPorId(id);

            return View(factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarFactura(int id, IFormCollection collection)
        {
            try
            {
                Factura factura = Repositorio.ObtenerFacturaPorId(id);

                Repositorio.EliminarFactura(factura);
                return RedirectToAction(nameof(ListarFacturas));
            }
            catch
            {
                return View();
            }
        }









        public ActionResult ListarClientes()
        {
            List<Cliente> ListaDeClientes;
            ListaDeClientes = Repositorio.ObtenerClientes();

            List<Inventario> ListaDeInventario;
            ListaDeInventario = Repositorio.ObtenerInventario();

            if (ListaDeClientes.Count.Equals(0)) { return RedirectToAction("NoExistenClientes", "Facturacion"); }
            else
            if (ListaDeInventario.Count.Equals(0)) { return RedirectToAction("NoExistenInventarios", "Facturacion"); }

            return View(ListaDeClientes);
        }

        public ActionResult ConsultarCliente(int id)

        {
            List<Cliente> ListaDeClientes;
            ListaDeClientes = Repositorio.ObtenerClientePorIdentificacion(id);

            Cliente cliente;


            if (ListaDeClientes.Count.Equals(0))
            {
                return RedirectToAction("NoExisteCliente", "Facturacion");
            }
            else
            {
                cliente = ListaDeClientes.First();
            }
            return View(cliente);
        }

        public ActionResult NoExisteCliente(int id)

        {

            return View();
        }

        public ActionResult NoExistenClientes()
        {
            return View();
        }












        public ActionResult ListarInventario(int idFactura)
        {
            List<Inventario> ListaDeInventario;
            ListaDeInventario = Repositorio.ObtenerInventario();

            TempData["idFactura"] = idFactura;

            if (ListaDeInventario.Count.Equals(0)) { return RedirectToAction("NoExisteInventario", "Facturacion"); }

            return View(ListaDeInventario);
        }

        public ActionResult ConsultarInventario(int codigo)

        {
            List<Inventario> ListaDeInventario;
            ListaDeInventario = Repositorio.ObtenerInventarioPorCodigo(codigo);

            Inventario inventario;


            if (ListaDeInventario.Count.Equals(0))
            {
                return RedirectToAction("NoExisteInventario", "Facturacion");
            }
            else
            {
                inventario = ListaDeInventario.First();
            }
            return View(inventario);
        }

        public ActionResult NoExisteInventario(int id)

        {
            return View();
        }
        public ActionResult NoExistenInventarios()
        {
            return View();
        }

        public ActionResult NoExisteInventario()
        {
            return View();
        }







        public ActionResult AgregarFactura(int idCliente)
        {
            Factura factura = new Factura();
            factura.idCliente = idCliente;
            factura.FechaEmision = DateTime.Now;

            Repositorio.AgregarFactura(factura);

            List<Factura> lista = new List<Factura>();
            lista = Repositorio.ObtenerFactura();
            Factura facturaAModificar = new Factura();
            facturaAModificar = lista.Last();

            Repositorio.ModificarFactura(facturaAModificar.Clave, facturaAModificar);

            List<Factura> lista2 = new List<Factura>();
            lista2 = Repositorio.ObtenerFactura();
            Factura Ultimafactura = new Factura();
            Ultimafactura = lista2.Last();


            return RedirectToAction("ListarInventario", "Facturacion", new { @idFactura = Ultimafactura.idFactura });
        }

        public ActionResult AgregarCantidadUnidad(int idFactura, int idInventario)
        {
            AgregarValoresLinea valoresLinea = new AgregarValoresLinea();
            valoresLinea.idInventario = idInventario;
            valoresLinea.idFactura = idFactura;

            Inventario producto = new Inventario();
            producto = Repositorio.ObtenerInventarioPorId(idInventario);


            ViewBag.cantidadMaxima = producto.Existencia;



            return View(valoresLinea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarCantidadUnidad(AgregarValoresLinea valores)
        {
            try
            {
                Inventario buscar = new Inventario();
                buscar = Repositorio.ObtenerInventarioPorId(valores.idInventario);


                int existencia = buscar.Existencia;
                string detalle = buscar.Descripcion;
                double precioUnitario = buscar.PrecioVenta;




                LineaDetalle linea = new LineaDetalle();
                linea.idFactura = valores.idFactura;
                linea.Cantidad = valores.cantidad;
                linea.UnidadMedida = valores.unidadMedida.ToString();
                linea.Detalle = detalle;
                linea.PrecioUnitario = precioUnitario;
                linea.Subtotal = (linea.Cantidad * precioUnitario);
                linea.MontoImpuesto = linea.Subtotal * 0.13;
               linea.MontoTotal = (linea.MontoImpuesto + linea.Subtotal);
                
                linea.MontoTotalLinea = 0;

                Repositorio.AgregarLineaDetalle(linea);

                List<LineaDetalle> lista = new List<LineaDetalle>();
                lista = Repositorio.ObtenerLineas();

                LineaDetalle lineaNueva = new LineaDetalle();
                lineaNueva = lista.Last();
                int idLinea = lineaNueva.idLineaDetalle;





                return RedirectToAction("ListarInventario", "Facturacion", new { valores.idFactura });


            }
            catch
            {
                return View();
            }
        }


       
    }
}
