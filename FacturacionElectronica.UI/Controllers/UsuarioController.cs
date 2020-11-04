using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacturacionElectronica.Modelos;
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
        private readonly UserManager<Areas.Identity.Data.Usuario> UserManager;
        private readonly IPasswordHasher<Areas.Identity.Data.Usuario> PasswordHasher;

        public UsuarioController(UserManager<Areas.Identity.Data.Usuario> user, IPasswordHasher<Areas.Identity.Data.Usuario> passwordHasher)
        {
            UserManager = user;
            PasswordHasher = passwordHasher;
        }


        public ActionResult Listar()
        {

            return View(UserManager.Users);
        }

        public async Task<ActionResult> Modificar(string id)
        {
            Areas.Identity.Data.Usuario usuarioPorModificar = await UserManager.FindByIdAsync(id);
            return View(usuarioPorModificar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(string id, string nombre, string primerApellido,
                                                  string segundoApellido, int identificacion,
                                                  int tipoIdentificacion,
                                                  string provincia, string canton, string distrito,
                                                  string otrasSenas)
        {
            Areas.Identity.Data.Usuario usuarioPorModificar = await UserManager.FindByIdAsync(id);

            try
            {
                usuarioPorModificar.Nombre = nombre;
                usuarioPorModificar.PrimerApellido = primerApellido;
                usuarioPorModificar.SegundoApellido = segundoApellido;
                usuarioPorModificar.Identificacion = identificacion;
                usuarioPorModificar.Provincia = provincia;
                usuarioPorModificar.Canton = canton;
                usuarioPorModificar.Distrito = distrito;
                usuarioPorModificar.OtrasSenas = otrasSenas;

                await UserManager.UpdateAsync(usuarioPorModificar);

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Eliminar(string id)
        {
            Areas.Identity.Data.Usuario usuarioPorEliminar;

            usuarioPorEliminar = await UserManager.FindByIdAsync(id);
            return View(usuarioPorEliminar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(string id, IFormCollection collection)
        {
            try
            {
                Areas.Identity.Data.Usuario usuarioPorEliminar;
                usuarioPorEliminar = await UserManager.FindByIdAsync(id);
                await UserManager.DeleteAsync(usuarioPorEliminar);

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Consultar(string identificacion)
        {
            Areas.Identity.Data.Usuario usuarioPorMostrar;
            usuarioPorMostrar = await UserManager.FindByNameAsync(identificacion);

            
            return View(usuarioPorMostrar);
        }
    }
}
