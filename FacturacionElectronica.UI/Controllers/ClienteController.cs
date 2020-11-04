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
                    Text = "Cédula Física.",
                     Value = "01"
                },
                new SelectListItem()
                {
                    Text = "Cédula Jurídica.",
                    Value = "02"
                },
                new SelectListItem()
                {
                   Text = "DIMEX.",
                   Value = "03"
                },
                new SelectListItem()
                {
                   Text = "NITE",
                   Value = "04"
                }
            };
       }


        public ActionResult Consultar(int id)

        {
            List<Cliente> ListaDeClientes;
            ListaDeClientes = Repositorio.ObtenerClientePorIdentificacion(id);

            Cliente cliente;


            if (ListaDeClientes.Count.Equals(0))
            {
                return RedirectToAction("NoExiste", "Cliente");
            }
            else
            {
                cliente = ListaDeClientes.First();
            }
            return View(cliente);
        }

        public ActionResult NoExiste(int id)

        {

            return View();
        }


        public ActionResult Eliminar(int id)

        {
            Cliente cliente;
            cliente = Repositorio.ObtenerClientePorId(id);

            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, IFormCollection collection)
        {
            try
            {
                Cliente cliente = Repositorio.ObtenerClientePorId(id);

                Repositorio.EliminarCliente(cliente);
                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }
    }
}
