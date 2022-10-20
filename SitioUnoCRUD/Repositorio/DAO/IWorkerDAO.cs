using SitioUnoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitioUnoCRUD.Repositorio.DAO
{
    internal interface IWorkerDAO
    {
        List<Worker> consultarTrabajadores();

        Worker consultarTrabajador(string id);

        Worker registrarTrabajador(Worker trabajador);

        Worker actualizarTrabajador(Worker trabajador, string id);

        void eliminarTrabajador(string id);


    }
}
