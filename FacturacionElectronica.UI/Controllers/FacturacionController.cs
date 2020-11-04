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

        public ActionResult Consultar(int id)

        {
            List<Factura> ListaDeFacturas;
            ListaDeFacturas = Repositorio.ObtenerFacturaPorIdentificacion(id);

            Factura factura;


            if (ListaDeFacturas.Count.Equals(0))
            {
                return RedirectToAction("NoExiste", "Facturacion");
            }
            else
            {
                factura = ListaDeFacturas.First();
            }
            return View(factura);
        }

        public ActionResult NoExiste(int id)

        {

            return View();
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

        public ActionResult Eliminar(int id)

        {
            Factura factura;
            factura = Repositorio.ObtenerFacturaPorId(id);

            return View(factura);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, IFormCollection collection)
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
            if (ListaDeInventario.Count.Equals(0)) { return RedirectToAction("NoExistenInventarios", "Facturacion");}

            return View(ListaDeClientes);
        }

        public ActionResult ListarInventario(int idCliente)
        {
            List<Inventario> ListaDeInventario;
            ListaDeInventario = Repositorio.ObtenerInventario();

            
            if (ListaDeInventario.Count.Equals(0)) { return RedirectToAction("NoExisteInventario", "Facturacion"); }

            return View(ListaDeInventario);
        }

        public ActionResult NoExistenClientes()
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

        // GET: FacturacionController1/Details/5
        public ActionResult AgregarLinea(int codigo)
        {
            return View();
        }

        
        // GET: FacturacionController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturacionController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturacionController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturacionController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
