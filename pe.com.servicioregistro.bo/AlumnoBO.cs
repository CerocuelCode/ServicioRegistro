using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.servicioregistro.bo
{
    public class AlumnoBO
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public bool estado { get; set; }
    }
}
