using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.servicioregistro.bo
{
    public class CursoBO
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public ProfesorBO profesor { get; set; }
        public AnioAcademicoBO anioAcademico { get; set; }
        public bool estado {  get; set; }
    }
}
