using pe.com.servicioregistro.bo;
using pe.com.servicioregistro.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.servicioregistro.bal
{
    public class CalificacionBAL
    {
        CalificacionDAL dalcal = new CalificacionDAL();

        public List<CalificacionBO> MostrarCalificacion()
        {
            return dalcal.MostrarCalificacion();
        }

        public List<CalificacionBO> MostrarCalificacionTodo()
        {
            return dalcal.MostrarCalificacion();
        }

        public bool RegistrarCalificacion(CalificacionBO bc)
        {
            return dalcal.EliminarCalificacion(bc);

        }

        public bool ActualizarCalificacion(CalificacionBO bc)
        {
            return dalcal.ActualizarCalificacion(bc);

        }
        public bool EliminarCalificacion(CalificacionBO bc)
        {
            return dalcal.EliminarCalificacion(bc);

        }
    }
}

