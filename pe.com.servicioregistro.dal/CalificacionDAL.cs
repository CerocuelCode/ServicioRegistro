using pe.com.servicioregistro.bo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.servicioregistro.dal
{
    public class CalificacionDAL
    {
        //objeto de la clase conexion
        ConexionDAL objconexion = new ConexionDAL();

        //comando SQL
        private SqlCommand cmdcal;
        //lectura de datos SQL
        private SqlDataReader drcal;
        int res = 0;

        //funcion que muestra todos los datos activos de Calificacion
        public List<CalificacionBO> MostrarCalificacion()
        {
            List<CalificacionBO> calificaciones = new List<CalificacionBO>();
            try
            {
                cmdcal = new SqlCommand();
                cmdcal.CommandType = CommandType.StoredProcedure;
                cmdcal.CommandText = "SP_MostrarCalificacion";
                cmdcal.Connection = objconexion.Conectar();
                drcal = cmdcal.ExecuteReader();
                while (drcal.Read())
                {
                    CalificacionBO objcal = new CalificacionBO();
                    AlumnoBO objalum = new AlumnoBO();
                    CursoBO objcur = new CursoBO();

                    objcal.codigo = Convert.ToInt32(drcal["codCalif"].ToString());
                    objalum.codigo = Convert.ToInt32(drcal["codAlum"].ToString());
                    objcal.alumno = objalum;
                    objcur.codigo = Convert.ToInt32(drcal["codCurso"].ToString());
                    objcal.curso = objcur;
                    objcal.calificacion = Convert.ToDouble(drcal["califCalif"].ToString());
                    objcal.estado = Convert.ToBoolean(drcal["estCalif"].ToString());
                    calificaciones.Add(objcal);
                }
                return calificaciones;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //funcion para mostrar todas las calificaciones (Activos o Inactivos)
        public List<CalificacionBO> MostrarCalificacionTodo()
        {
            List<CalificacionBO> calificaciones = new List<CalificacionBO>();
            try
            {
                cmdcal = new SqlCommand();
                cmdcal.CommandType = CommandType.StoredProcedure;
                cmdcal.CommandText = "SP_MostrarCalificacionTodo";
                cmdcal.Connection = objconexion.Conectar();
                drcal = cmdcal.ExecuteReader();
                while (drcal.Read())
                {
                    CalificacionBO objcal = new CalificacionBO();
                    AlumnoBO objalum = new AlumnoBO();
                    CursoBO objcur = new CursoBO();

                    objcal.codigo = Convert.ToInt32(drcal["codCalif"].ToString());
                    objalum.codigo = Convert.ToInt32(drcal["codAlum"].ToString());
                    objcal.alumno = objalum;
                    objcur.codigo = Convert.ToInt32(drcal["codCurso"].ToString());
                    objcal.curso = objcur;
                    objcal.calificacion = Convert.ToDouble(drcal["califCalif"].ToString());
                    objcal.estado = Convert.ToBoolean(drcal["estCalif"].ToString());
                    calificaciones.Add(objcal);
                }
                return calificaciones;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //funcion para registrar calificacion
        public bool RegistrarCalificacion(CalificacionBO bc)
        {
            try
            {
                cmdcal = new SqlCommand();
                cmdcal.CommandType = CommandType.StoredProcedure;
                cmdcal.CommandText = "SP_RegistrarCalificacion";
                cmdcal.Connection = objconexion.Conectar();

                cmdcal.Parameters.AddWithValue("@codAlum", bc.alumno.codigo);
                cmdcal.Parameters.AddWithValue("@codCurso", bc.curso.codigo);
                cmdcal.Parameters.AddWithValue("@califCalif", bc.calificacion);
                cmdcal.Parameters.AddWithValue("@estCalif", bc.estado);

                res = cmdcal.ExecuteNonQuery();

                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //funcion para actualizar calificacion
        public bool ActualizarCalificacion(CalificacionBO bc)
        {
            try
            {
                cmdcal = new SqlCommand();
                cmdcal.CommandType = CommandType.StoredProcedure;
                cmdcal.CommandText = "SP_ActualizarCalificacion";
                cmdcal.Connection = objconexion.Conectar();

                cmdcal.Parameters.AddWithValue("@codCalif", bc.codigo);
                cmdcal.Parameters.AddWithValue("@codAlum", bc.alumno.codigo);
                cmdcal.Parameters.AddWithValue("@codCurso", bc.curso.codigo);
                cmdcal.Parameters.AddWithValue("@califCalif", bc.calificacion);
                cmdcal.Parameters.AddWithValue("@estCalif", bc.estado);

                res = cmdcal.ExecuteNonQuery();

                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //funcion para eliminar calificacion (cambiar el estado a inactivo)
        public bool EliminarCalificacion(CalificacionBO bc)
        {
            try
            {
                cmdcal = new SqlCommand();
                cmdcal.CommandType = CommandType.StoredProcedure;
                cmdcal.CommandText = "SP_EliminarCalificacion";
                cmdcal.Connection = objconexion.Conectar();

                cmdcal.Parameters.AddWithValue("@codCalif", bc.codigo);

                res = cmdcal.ExecuteNonQuery();

                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }
    }
}
