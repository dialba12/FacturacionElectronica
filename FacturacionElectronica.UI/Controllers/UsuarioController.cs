using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacturacionElectronica.UI.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionElectronica.UI.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> UserManager;

        public UsuarioController(UserManager<Usuario> user)
        {
            UserManager = user;
        }

        
        public ActionResult Listar()
        {
           
            return View(UserManager.Users);
        }

        // GET: UsuariosController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsuariosController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuariosController1/Edit/5
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

        // GET: UsuariosController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuariosController1/Delete/5
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
