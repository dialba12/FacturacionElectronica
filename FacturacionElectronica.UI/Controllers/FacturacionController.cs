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

            List<Factura> ListaDeFacturasAEnviar = new List<Factura>();

            foreach (var factura in ListaDeFacturas)
            {

                if (factura.idResumen != 0) { ListaDeFacturasAEnviar.Add(factura); }
            }
            return View(ListaDeFacturasAEnviar);
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
                Factura cliente = Repositorio.ObtenerFacturaPorId(id);

                Repositorio.EliminarFactura(cliente);
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
            ViewBag.idFactura = idFactura;

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
            string nombreUsuario = User.Identity.Name;
            factura.idUsuario = Int32.Parse(nombreUsuario);
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

            if (producto.Existencia == 0) { return RedirectToAction("NoExistenUnidadesEnInventario", "Facturacion", new { idFactura }); }
            else
            {
                ViewBag.cantidadMaxima = producto.Existencia;



                return View(valoresLinea);
            }
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
                Inventario cambiar = new Inventario();
                cambiar = Repositorio.ObtenerInventarioPorId(valores.idInventario);

                cambiar.Existencia = cambiar.Existencia - valores.cantidad;
                Repositorio.ModificarInventario(cambiar.idInventario, cambiar);

                return RedirectToAction("ListarInventario", "Facturacion", new { valores.idFactura });

            }
            catch
            {
                return View();
            }
        }
        public ActionResult NoExistenUnidadesEnInventario(int idFactura)
        {
            TempData["idFactura"] = idFactura;

            return View();
        }
        public ActionResult AgregarMedioPago(int idFactura)
        {

            TempData["idFactura"] = idFactura;
            Factura facturaAsociada = new Factura();
            Cliente cliente = new Cliente();
            List<LineaDetalle> lineasAsociadas = new List<LineaDetalle>();
            string nombrecliente;
            double totalImpuestos = 0;
            double total = 0;


            facturaAsociada = Repositorio.ObtenerFacturaPorId(idFactura);
            cliente = Repositorio.ObtenerClientePorId(facturaAsociada.idCliente);
            nombrecliente = cliente.Nombre + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido;

            lineasAsociadas = Repositorio.ObtenerLineas(idFactura);

            if (lineasAsociadas.Count == 0) { return RedirectToAction("NoExistenLineasAgregadas", "Facturacion", new { idFactura }); }
            else
            {
                foreach (var linea in lineasAsociadas)
                {
                    totalImpuestos += linea.MontoImpuesto;
                    total += linea.MontoTotal;
                }

                ResumenDeCompra resumenCompra = new ResumenDeCompra();

                resumenCompra.fecha = facturaAsociada.FechaEmision;
                resumenCompra.cliente = nombrecliente;
                resumenCompra.consecutivo = facturaAsociada.NumeroConsecutivo;
                resumenCompra.lineasDetalle = lineasAsociadas;
                resumenCompra.TotalImpuestos = totalImpuestos;
                resumenCompra.Total = total;
                resumenCompra.idFactura = idFactura;


                return View(resumenCompra);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarMedioPago(ResumenDeCompra valores)
        {
          
            return RedirectToAction("GenerarFactura", "Facturacion", new { @idFactura = valores.idFactura, @MedioPago = valores.MedioPago, @condicion = valores.CondicionVenta });

        }
        public ActionResult NoExistenLineasAgregadas(int idFactura)
        {
            TempData["idFactura"] = idFactura;

            return View();
        }
        public ActionResult GenerarFactura(int idFactura, string MedioPago, string condicion)
        {
            double TotalVenta = 0;
            double TotalVentaNeto = 0;
            double TotalImpuesto = 0;
            double TotalComprobante = 0;

            var lineasAsociadas = Repositorio.ObtenerLineas(idFactura);

            foreach (var linea in lineasAsociadas)
            {
                TotalVenta += linea.MontoTotal;
                TotalVentaNeto += linea.Subtotal;
                TotalImpuesto += linea.MontoImpuesto;
                TotalComprobante += linea.Subtotal;
            }




            ResumenFactura resumen = new ResumenFactura();
            resumen.TotalVenta = TotalVenta;
            resumen.TotalDescuento = 0;
            resumen.TotalVentaNeto = TotalVentaNeto;
            resumen.TotalImpuesto = TotalImpuesto;
            resumen.TotalComprobante = TotalComprobante;
            Repositorio.AgregarResumen(resumen);




            List<ResumenFactura> listaResumenes = new List<ResumenFactura>();
            listaResumenes = Repositorio.ObtenerResumenes();
            ResumenFactura resumenActual = new ResumenFactura();
            resumenActual = listaResumenes.Last();

            int idResumen = resumenActual.idResumen;


            List<Factura> lista = new List<Factura>();
            lista = Repositorio.ObtenerFactura();
            Factura facturaAModificar = new Factura();
            facturaAModificar = lista.Last();

            facturaAModificar.idResumen = idResumen;
            facturaAModificar.MedioPago = MedioPago;
            facturaAModificar.CondicionVenta = condicion;

            Repositorio.ModificarFactura(facturaAModificar.idFactura, facturaAModificar);
            Repositorio.GenerarXml(idFactura);

            return RedirectToAction("FacturaAgregada", "Facturacion");
        }
        public ActionResult FacturaAgregada()

        {
            return View();
        }
    }


}
