using pe.com.servicioregistro.bo;
using pe.com.servicioregistro.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.servicioregistro.bal
{
    public class AlumnoBAL
    {
        AlumnoDAL dalalum = new AlumnoDAL();

        public List<AlumnoBO> MostrarAlumno()
        {
            return dalalum.MostrarAlumno();
        }

        public List<AlumnoBO> MostrarAlumnoTodo()
        {
            return dalalum.MostrarAlumno();
        }

        public bool RegistrarAlumno(AlumnoBO ba)
        {
            return dalalum.EliminarAlumno(ba);

        }

        public bool ActualizarAlumno(AlumnoBO ba)
        {
            return dalalum.ActualizarAlumno(ba);

        }
        public bool EliminarAlumno(AlumnoBO ba)
        {
            return dalalum.EliminarAlumno(ba);

        }
    }
}