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
    public class FacturacionController : Controller
    {

        private readonly UserManager<Usuario> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;

        public FacturacionController(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;
        }


        public async Task<ActionResult> Listar()
        {
            if (User.Identity.IsAuthenticated)
            {
                await RoleManager.CreateAsync(new IdentityRole("Administrador"));
                var Usuario = await UserManager.GetUserAsync(HttpContext.User);
                await UserManager.AddToRoleAsync(Usuario, "Administrador");
            }
            return View();
        }

        // GET: FacturacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturacionController/Create
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

        // GET: FacturacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturacionController/Edit/5
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

        // GET: FacturacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturacionController/Delete/5
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
