using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Disquera.UAPI;
using Disquera.Modelos;

namespace Disquera.WebMVC.Controllers
{
    public class AutoresController : Controller
    {
        private string Url = "https://localhost:7290/api/Autores";

        // GET: AutoresController
        public ActionResult Index()
        {
            var datos = new Crud<Autor>().Select(Url);
            return View(datos);
        }

        // GET: AutoresController/Details/5
        public ActionResult Details(int id)
        {
            var datos = new Crud<Autor>().Select_byId(Url, id.ToString());
            return View(datos);
        }

        // GET: AutoresController/Create
        public ActionResult Create()
        {           
            return View();
        }

        // POST: AutoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autor datos)
        {
            try
            {
                new Crud<Autor>().Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: AutoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = new Crud<Autor>().Select_byId(Url, id.ToString());
            return View(datos);
        }

        // POST: AutoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Autor datos)
        {
            try
            {
                new Crud<Autor>().Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: AutoresController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = new Crud<Autor>().Select_byId(Url, id.ToString());
            return View(datos);
        }

        // POST: AutoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Autor datos)
        {
            try
            {
                new Crud<Autor>().Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
