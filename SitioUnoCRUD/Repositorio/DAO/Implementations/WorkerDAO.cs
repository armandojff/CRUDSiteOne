using MongoDB.Bson;
using MongoDB.Driver;
using SitioUnoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioUnoCRUD.Repositorio.DAO.Implementations
{
    public class WorkerDAO : IWorkerDAO
    {

            MongoDBRepositorio rep = new MongoDBRepositorio();

            IMongoCollection<Worker> workersDB;

            public WorkerDAO()
            {
                this.workersDB = rep.db.GetCollection<Worker>("Trabajador");
            }

            public List<Worker> consultarTrabajadores()
            {

                List<Worker> trabajadores = workersDB.Find(d => true).ToList();

                return trabajadores;

            }

            public Worker consultarTrabajador(string id)
            {

                var TrabajadorId = new ObjectId(id);

            Worker trabajador = workersDB.AsQueryable<Worker>().SingleOrDefault(a => a._id == TrabajadorId);

                return trabajador;

            }

            public Worker registrarTrabajador(Worker trabajador)
            {

                workersDB.InsertOne(trabajador);

                return trabajador;

            }

            public Worker actualizarTrabajador(Worker trabajador, string id)
            {

                    workersDB.UpdateOne(Builders<Worker>.Filter.Eq("_id", ObjectId.Parse(id)),
                    Builders<Worker>.Update
                    .Set("nombre", trabajador.nombre)
                    .Set("apellido", trabajador.apellido)
                    .Set("año_de_nacimiento", trabajador.año_de_nacimiento)
                    .Set("cargo", trabajador.cargo)
                    );

                return trabajador;
            }

            public void eliminarTrabajador(string id)
            {
                  workersDB.DeleteOne(Builders<Worker>.Filter.Eq("_id", ObjectId.Parse(id)));

            }

        }

}