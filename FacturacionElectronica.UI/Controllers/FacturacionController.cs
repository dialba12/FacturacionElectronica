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

        public ActionResult ListarClientes()
        {
            List<Cliente> ListaDeClientes;
            ListaDeClientes = Repositorio.ObtenerClientes();

            List<Inventario> ListaDeInventario;
            ListaDeInventario = Repositorio.ObtenerInventario();

            if (ListaDeClientes.Count.Equals(0)) { return RedirectToAction("NoExistenClientes", "Facturacion"); }
            else
            if (ListaDeInventario.Count.Equals(0)) { return RedirectToAction("NoExisteInventario", "Facturacion");}

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
