using pe.com.servicioregistro.bal;
using pe.com.servicioregistro.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace pe.com.servicioregistro.ws
{
    /// <summary>
    /// Descripción breve de WSServicioRegistro
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSServicioRegistro : System.Web.Services.WebService
    {
        AlumnoBAL balalum = new AlumnoBAL();
        ProfesorBAL balprof = new ProfesorBAL();
        AnioAcademicoBAL balanio = new AnioAcademicoBAL();

        CalificacionBAL balcal = new CalificacionBAL();
        CursoBAL balcur = new CursoBAL();
        
        // Alumno
        [WebMethod]
        public List<AlumnoBO> MostrarAlumno()
        {
            List<AlumnoBO> alumnos = balalum.MostrarAlumno().ToList();
            return alumnos;
        }
        [WebMethod]
        public List<AlumnoBO> MostrarAlumnoTodo()
        {
            List<AlumnoBO> alumnos = balalum.MostrarAlumnoTodo().ToList();
            return alumnos;
        }
        [WebMethod]
        public bool RegistrarAlumno(AlumnoBO ba)
        {
            return balalum.RegistrarAlumno(ba);
        }
        [WebMethod]
        public bool ActualizarAlumno(AlumnoBO ba)
        {
            return balalum.ActualizarAlumno(ba);
        }
        [WebMethod]
        public bool EliminarAlumno(AlumnoBO ba)
        {
            return balalum.EliminarAlumno(ba);
        }

        //Profesor
        [WebMethod]
        public List<ProfesorBO> MostrarProfesor()
        {
            List<ProfesorBO> profesores = balprof.MostrarProfesor().ToList();
            return profesores;
        }
        [WebMethod]
        public List<ProfesorBO> MostrarProfesorTodo()
        {
            List<ProfesorBO> profesores = balprof.MostrarProfesorTodo().ToList();
            return profesores;
        }
        [WebMethod]
        public bool RegistrarProfesor(ProfesorBO bp)
        {
            return balprof.RegistrarProfesor(bp);
        }
        [WebMethod]
        public bool ActualizarProfesor(ProfesorBO bp)
        {
            return balprof.ActualizarProfesor(bp);
        }
        [WebMethod]
        public bool EliminarProfesor(ProfesorBO bp)
        {
            return balprof.EliminarProfesor(bp);
        }

        // Año Academico
        [WebMethod]
        public List<AnioAcademicoBO> MostrarAnioAcademico()
        {
            List<AnioAcademicoBO> aniosAcademicos = balanio.MostrarAnioAcademico().ToList();
            return aniosAcademicos;
        }
        [WebMethod]
        public List<AnioAcademicoBO> MostrarAnioAcademicoTodo()
        {
            List<AnioAcademicoBO> aniosAcademicos = balanio.MostrarAnioAcademicoTodo().ToList();
            return aniosAcademicos;
        }
        [WebMethod]
        public bool RegistrarAnioAcademico(AnioAcademicoBO baa)
        {
            return balanio.RegistrarAnioAcademico(baa);
        }
        [WebMethod]
        public bool ActualizarAnioAcademico(AnioAcademicoBO baa)
        {
            return balanio.ActualizarAnioAcademico(baa);
        }
        [WebMethod]
        public bool EliminarAnioAcademico(AnioAcademicoBO baa)
        {
            return balanio.EliminarAnioAcademico(baa);
        }

        // Calificacion
        [WebMethod]
        public List<CalificacionBO> MostrarCalificacion()
        {
            List<CalificacionBO> calificaciones = balcal.MostrarCalificacion().ToList();
            return calificaciones;
        }
        [WebMethod]
        public List<CalificacionBO> MostrarCalificacionTodo()
        {
            List<CalificacionBO> calificaciones = balcal.MostrarCalificacionTodo().ToList();
            return calificaciones;
        }
        [WebMethod]
        public bool RegistrarCalificacion(CalificacionBO bc)
        {
            return balcal.RegistrarCalificacion(bc);
        }
        [WebMethod]
        public bool ActualizarCalificacion(CalificacionBO bc)
        {
            return balcal.ActualizarCalificacion(bc);
        }
        [WebMethod]
        public bool EliminarCalificacion(CalificacionBO bc)
        {
            return balcal.EliminarCalificacion(bc);
        }

        // Curso
        [WebMethod]
        public List<CursoBO> MostrarCurso()
        {
            List<CursoBO> cursos = balcur.MostrarCurso().ToList();
            return cursos;
        }
        [WebMethod]
        public List<CursoBO> MostrarCursoTodo()
        {
            List<CursoBO> cursos = balcur.MostrarCursoTodo().ToList();
            return cursos;
        }
        [WebMethod]
        public bool RegistrarCurso(CursoBO bc)
        {
            return balcur.RegistrarCurso(bc);
        }
        [WebMethod]
        public bool ActualizarCurso(CursoBO bc)
        {
            return balcur.ActualizarCurso(bc);
        }
        [WebMethod]
        public bool EliminarCurso(CursoBO bc)
        {
            return balcur.EliminarCurso(bc);
        }



    }
}
