using SitioUnoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitioUnoCRUD.Repositorio.DAO
{
    internal interface IDepartmentDAO
    {
        List<Department> consultarDepartamentos();

        Department consultarDepartamento(string id);

        Department actualizarDepartamento(Department departamento,string id);

        Department registrarDepartamento(Department departamento);

        void añadirTrabajadorAlDepartamento(string idDepartamento, string idTrabajador);

        void eliminarDepartamento(string id);

        void eliminarTrabajadorDelDepartamento(string id);

    }
}
