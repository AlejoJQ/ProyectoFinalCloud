using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Disquera.UAPI;
using Disquera.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Disquera.WebMVC.Controllers
{
    public class CancionesController : Controller
    {
        private string Url = "https://localhost:7290/api/Canciones";
        private Crud<Cancion> Crud { get; set; }


        public CancionesController() { 
        
            Crud = new Crud<Cancion>();
        }


        // GET: CancionesController
        public ActionResult Index()
        {
            var datos = Crud.Select(Url);
            return View(datos);
        }

        // GET: CancionesController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud.Select_byId(Url, id.ToString());
            return View(datos);
        }

        // GET: CancionesController/Create
        public ActionResult Create()
        {
            var listaAutores = new Crud<Autor>().Select(Url.Replace("Canciones", "Autores"))
                .Select(p => new SelectListItem
                {
                    Value = p.id_autor.ToString(),
                    Text = p.nombre
                })
                .ToList();

            ViewBag.ListaAutores = listaAutores;

            return View();
        }

        // POST: CancionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cancion datos)
        {
            try
            {
                Crud.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar los datos: " + ex.Message);
                return View(datos);
            }
        }

        // GET: CancionesController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud.Select_byId(Url, id.ToString());
            return View(datos);
        }

        // POST: CancionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cancion datos)
        {
            try
            {
                Crud.Update(Url, id.ToString(),datos); 
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar los datos: " + ex.Message);
                return View(datos);
            }
        }

        // GET: CancionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud.Select_byId(Url, id.ToString());
            return View(datos);
        }

        // POST: CancionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cancion datos)
        {
            try
            {
                Crud.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar los datos: " + ex.Message);
                return View(datos);
            }
        }
    }
}
