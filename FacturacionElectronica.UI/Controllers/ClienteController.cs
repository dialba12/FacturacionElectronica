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
    public class ClienteController : Controller
    {
        private readonly IRepositorioFacturacion Repositorio;

        public ClienteController(IRepositorioFacturacion repositorio)
        {
            Repositorio = repositorio;
        }

        public ActionResult Listar()
        {
            List<Cliente> ListaDeClientes;
            ListaDeClientes = Repositorio.ObtenerClientes();

            return View(ListaDeClientes);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Cliente cliente)
        {

            try
            {
                Repositorio.AgregarCliente(cliente);

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Modificar(int id)
        {
            Cliente cliente;
            cliente = Repositorio.ObtenerClientePorId(id);

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(int id, Cliente cliente)
        {
            try
            {
                Repositorio.ModificarCliente(id, cliente);
                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }


        public List<SelectListItem> ObtenerTipoDeCedula()
        {
            return new List<SelectListItem>()
            {
                 new SelectListItem()
                {
                    Text = "Cédula física.",
                     Value = "1"
                },
                new SelectListItem()
                {
                    Text = "Cédula jurídica.",
                    Value = "2"
                },
                new SelectListItem()
                {
                   Text = "DIMEX.",
                   Value = "3"
                },
                new SelectListItem()
                {
                   Text = "NITE",
                   Value = "4"
                }
            };
       }
        
        
       

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientesController/Delete/5
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
