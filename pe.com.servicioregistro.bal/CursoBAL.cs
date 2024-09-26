using pe.com.servicioregistro.bo;
using pe.com.servicioregistro.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.servicioregistro.bal
{
    public class CursoBAL
    {
        CursoDAL dalcur = new CursoDAL();

        public List<CursoBO> MostrarCurso()
        {
            return dalcur.MostrarCurso();
        }

        public List<CursoBO> MostrarCursoTodo()
        {
            return dalcur.MostrarCursoTodo();
        }

        public bool RegistrarCurso(CursoBO bc)
        {
            return dalcur.RegistrarCurso(bc);

        }

        public bool ActualizarCurso(CursoBO bc)
        {
            return dalcur.ActualizarCurso(bc);

        }
        public bool EliminarCurso(CursoBO bc)
        {
            return dalcur.EliminarCurso(bc);

        }
    }
}
