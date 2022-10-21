using SitioUnoCRUD.Models;
using SitioUnoCRUD.Repositorio.DAO;
using SitioUnoCRUD.Repositorio.DAO.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioUnoCRUD.Controllers
{
    public class WorkerController : Controller
    {
        private IWorkerDAO db = new WorkerDAO();
        // GET: Worker
        public ActionResult Index()
        {
            var workers = db.consultarTrabajadores();
            return View(workers);
        }

        // GET: Worker/Details/5
        public ActionResult Details(string id)
        {
            var worker = db.consultarTrabajador(id);

            return View(worker);
        }

        // GET: Worker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Worker/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                var trabajador = new Worker()
                {
                    nombre = collection["nombre"],
                    apellido = collection["apellido"],
                    año_de_nacimiento = collection["año_De_nacimiento"],
                    cargo = collection["cargo"]

                };
                db.registrarTrabajador(trabajador);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Worker/Edit/5
        public ActionResult Edit(string id)
        {
            var worker = db.consultarTrabajador(id);
            
            return View(worker);

        }

        // POST: Worker/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var trabajador = new Worker()
                {
                    nombre = collection["nombre"],
                    apellido = collection["apellido"],
                    año_de_nacimiento = collection["año_De_nacimiento"],
                    cargo = collection["cargo"]

                };

                db.actualizarTrabajador(trabajador, id);

               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Worker/Delete/5
        public ActionResult Delete(string id)
        {
            var worker = db.consultarTrabajador(id);

            return View(worker);
        }

        // POST: Worker/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                db.eliminarTrabajador(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DataTableWorker()
        {
            var workers = db.consultarTrabajadores();
            return View(workers);
        }
    }
}
