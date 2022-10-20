using SitioUnoCRUD.Repositorio.DAO.Implementations;
using SitioUnoCRUD.Repositorio.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitioUnoCRUD.Models;

namespace SitioUnoCRUD.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentDAO db = new DepartmentDAO();

        private IWorkerDAO dbW = new WorkerDAO();

        // GET: Department
        public ActionResult Index()
        {
            var departamentos = db.consultarDepartamentos();
            return View(departamentos);
        }

        // GET: Department/Details/5
        public ActionResult Details(string id)
        {
            var departamento = db.consultarDepartamento(id);

            return View(departamento);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddWorkerToApartment/Add/5

        public ActionResult AddWorkerToApartment()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult AddWorkerToApartment(FormCollection collection)
        {
            try
            {
                string departamento = collection["nombre"];
                string trabajador = collection["area"];

                db.añadirTrabajadorAlDepartamento(departamento, trabajador);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: Department/Edit/5
        public ActionResult Edit(string id)
        {
            var departamento = db.consultarDepartamento(id);

            return View(departamento);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var departamento = new Department()
                {
                    nombre = collection["nombre"],
                    area = collection["area"]

                };

                db.actualizarDepartamento(departamento, id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(string id)
        {
            var departamento = db.consultarDepartamento(id);

            return View(departamento);
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                db.eliminarDepartamento(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/DeleteWorkerFromApartment/5
        public ActionResult DeleteWorkerFromApartment(string id)
        {
            var worker = dbW.consultarTrabajador(id);

            return View(worker);

        }

        // DELETE: Department/DeleteWorkerFromApartment/5
        [HttpPost]
        public ActionResult DeleteWorkerFromApartment(string id, string idDep)
        { 
            try
            {
                // TODO: Add delete logic here

                db.eliminarTrabajadorDelDepartamento(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
    }


}
