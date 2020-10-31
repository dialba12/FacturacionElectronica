using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FacturacionElectronica.BL;
using FacturacionElectronica.Modelos;

namespace FacturacionElectronica.SI.Controllers
{
    public class CatalogoClientesController : Controller
    {
        private readonly IRepositorioFacturacion Repositorio;
        // GET: CatalogoClientesController

        public CatalogoClientesController(IRepositorioFacturacion repositorioFacturacion)
        {
            Repositorio = repositorioFacturacion;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: CatalogoClientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatalogoClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogoClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente Cliente)
        {
            try
            {
                if (ModelState.IsValid) {

                    Repositorio.AgregarCliente(Cliente);
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(Cliente);
        }

        // GET: CatalogoClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogoClientesController/Edit/5
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

        // GET: CatalogoClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogoClientesController/Delete/5
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
