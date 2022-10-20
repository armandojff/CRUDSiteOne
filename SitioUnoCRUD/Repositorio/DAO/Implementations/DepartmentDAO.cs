using Microsoft.Ajax.Utilities;
using MongoDB.Bson;
using MongoDB.Driver;
using SitioUnoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioUnoCRUD.Repositorio.DAO.Implementations
{
    public class DepartmentDAO : IDepartmentDAO
    {
        MongoDBRepositorio rep = new MongoDBRepositorio();

        IMongoCollection<Department> departmentDB;

        IMongoCollection<Worker> workerDB;

        public DepartmentDAO()
        {
            this.departmentDB = rep.db.GetCollection<Department>("Departamento");

            this.workerDB = rep.db.GetCollection<Worker>("Trabajador");
        }

        public List<Department> consultarDepartamentos()
        {

            List<Department> departamentos = departmentDB.Find(d => true).ToList();

            return departamentos;

        }

        public Department consultarDepartamento(string id)
        {

            var DepartamentoId = new ObjectId(id);

            Department departamento = departmentDB.AsQueryable<Department>().SingleOrDefault(a => a._id == DepartamentoId);

            return departamento;

        }

        public void eliminarTrabajadorDelDepartamento(string id)
        {

            List<Department> departamentos = departmentDB.Find(d => true).ToList();

              Department departamentoEncontrado = new Department();

                foreach( var depas in departamentos )
                {
                    if (depas.trabajadores != null)
                    {
                        foreach (var workers in depas.trabajadores)
                        {
                            if (workers._id == ObjectId.Parse(id))
                            {
                                departamentoEncontrado = depas;
                            }
                        }
                    }
                }

            departamentoEncontrado.trabajadores.RemoveAll(c => c._id == ObjectId.Parse(id));

            //var filter = Builders<Department>.Filter.Eq(c => c._id,ObjectId.Parse(id del departamento ));

            // var update = Builders<Department>.Update.PullFilter(c => c.trabajadores, Builders<Worker>.Filter.Where(ni => ni._id == ObjectId.Parse(id)));

            //var update = Builders<Department>.Update.PullFilter(c => c.trabajadores, i => i._id == ObjectId.Parse(id));

            //Builders<Worker>.Filter.Eq("_id", ObjectId.Parse( id)));

            //var result = departmentDB.UpdateOne(departamento);

            var filter = Builders<Department>.Filter.Eq(d => d._id, departamentoEncontrado._id);

            departmentDB.ReplaceOneAsync(filter, departamentoEncontrado);

            /*departmentDB.UpdateOne(Builders<Department>.Filter.Eq("_id", "6349cbbd0cc5e5fc48185e26"),
                    Builders<Department>.Update
                    .Set("nombre", departamento.nombre)
                    .Set("area", "OtraArea")
                    .Set("trabajadores", departamento.trabajadores)
                    );*/

        }

        public void eliminarDepartamento(string id)
        {

            departmentDB.DeleteOne(Builders<Department>.Filter.Eq("_id", ObjectId.Parse(id)));

        }

        public Department actualizarDepartamento(Department departamento, string id)
        {

            departmentDB.UpdateOne(Builders<Department>.Filter.Eq("_id", ObjectId.Parse(id)),
            Builders<Department>.Update
            .Set("nombre", departamento.nombre)
            .Set("area", departamento.area)
            );

            return departamento;

        }

        public void añadirTrabajadorAlDepartamento(string departmentName, string workerName){

            /* esto está mal, pero mientras perfecciono los queries para la gestion de documentos embebido en mongo 
            y manejo mejor las interfaces para poder pasar los id ya que los nombres no son unicos y generan problemas */

            Department departamento = departmentDB.Find(Builders<Department>.Filter.Eq(d => d.nombre, departmentName)).FirstOrDefault();


            Worker trabajador =  workerDB.Find(Builders<Worker>.Filter.Eq(w => w.nombre, workerName)).FirstOrDefault();

            departamento.trabajadores.Add(trabajador);

            var filter = Builders<Department>.Filter.Eq(d => d._id, departamento._id);

            departmentDB.ReplaceOneAsync(filter, departamento);


        }

    }
}