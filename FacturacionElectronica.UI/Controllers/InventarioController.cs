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
    public class InventarioController : Controller
    {
        private readonly IRepositorioFacturacion Repositorio;

        public InventarioController(IRepositorioFacturacion repositorio)
        {
            Repositorio = repositorio;
        }

        public ActionResult Listar()
        {
            List<Inventario> ListaDeInventario;
            ListaDeInventario = Repositorio.ObtenerInventario();
            return View(ListaDeInventario);
        }
        
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Inventario inventario)
        {
            try
            {
                Repositorio.AgregarInventario(inventario);
                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Inventario producto;
            producto = Repositorio.ObtenerInventarioPorId(id);

            return View(producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inventario inventario)
        {
            try
            {
                Repositorio.ModificarInventario(id, inventario);
                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Eliminar(int id)

        {
           Inventario inventario;
            inventario = Repositorio.ObtenerInventarioPorId(id);

            return View(inventario);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, IFormCollection collection)
        {
            try
            {
                Inventario inventario;
                inventario = Repositorio.ObtenerInventarioPorId(id);


                Repositorio.EliminarInventario(inventario);
                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }
    }
}
