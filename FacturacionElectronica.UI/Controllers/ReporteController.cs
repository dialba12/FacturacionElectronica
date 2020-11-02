using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacturacionElectronica.BL;
using FacturacionElectronica.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionElectronica.UI.Controllers
{
    [Authorize]
    public class ReporteController : Controller
    {
        private readonly IRepositorioFacturacion Repositorio;

        public ReporteController(IRepositorioFacturacion repositorio)
        {
            Repositorio = repositorio;
        }
        public ActionResult Listar()
        {
            List<Cierre> ListaDeCierres;
            ListaDeCierres = Repositorio.ObtenerCierre();
            return View(ListaDeCierres);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Cierre cierre)
        {
            try
            {
                string nombreUsuario = User.Identity.Name;
                cierre.NombreUsuario = nombreUsuario;
                cierre.Fecha = DateTime.Now;

                Repositorio.AgregarCierre(cierre);

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Modificar(int id)
        {
            Cierre cierre;
            cierre = Repositorio.ObtenerCierrePorId(id);

            return View(cierre);
        }

        // POST: ReportesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(int id, Cierre cierre)
        {
            try
            {
                Repositorio.ModificarCierre(id, cierre);
                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportesController/Delete/5
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
