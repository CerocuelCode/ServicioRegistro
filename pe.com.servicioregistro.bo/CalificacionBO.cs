using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.servicioregistro.bo
{
    public class CalificacionBO
    {
        public int codigo { get; set; }
        public AlumnoBO alumno { get; set; }
        public CursoBO curso { get; set; }
        public double calificacion { get; set; }
        public bool estado { get; set; }
    }
}
