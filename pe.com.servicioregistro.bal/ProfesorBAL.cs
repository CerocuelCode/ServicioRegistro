using pe.com.servicioregistro.bo;
using pe.com.servicioregistro.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.servicioregistro.bal
{
    public class ProfesorBAL
    {
        ProfesorDAL dalpro = new ProfesorDAL();

        public List<ProfesorBO> MostrarProfesor()
        {
            return dalpro.MostrarProfesor();
        }

        public List<ProfesorBO> MostrarProfesorTodo()
        {
            return dalpro.MostrarProfesorTodo();
        }

        public bool RegistrarProfesor(ProfesorBO bp)
        {
            return dalpro.RegistrarProfesor(bp);

        }

        public bool ActualizarProfesor(ProfesorBO bp)
        {
            return dalpro.ActualizarProfesor(bp);

        }
        public bool EliminarProfesor(ProfesorBO bp)
        {
            return dalpro.EliminarProfesor(bp);

        }
    }
}
