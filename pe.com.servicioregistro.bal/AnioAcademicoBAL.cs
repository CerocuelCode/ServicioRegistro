using pe.com.servicioregistro.bo;
using pe.com.servicioregistro.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.servicioregistro.bal
{
    public class AnioAcademicoBAL
    {
        AnioAcademicoDAL dalanio = new AnioAcademicoDAL();

        public List<AnioAcademicoBO> MostrarAnioAcademico()
        {
            return dalanio.MostrarAnioAcademico();
        }

        public List<AnioAcademicoBO> MostrarAnioAcademicoTodo()
        {
            return dalanio.MostrarAnioAcademico();
        }

        public bool RegistrarAnioAcademico(AnioAcademicoBO baa)
        {
            return dalanio.EliminarAnioAcademico(baa);

        }

        public bool ActualizarAnioAcademico(AnioAcademicoBO baa)
        {
            return dalanio.ActualizarAnioAcademico(baa);

        }
        public bool EliminarAnioAcademico(AnioAcademicoBO baa)
        {
            return dalanio.EliminarAnioAcademico(baa);

        }
    }
}

