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
    public class ProfesorDAL
    {
        //objeto de la clase conexion
        ConexionDAL objconexion = new ConexionDAL();

        //comando SQL
        private SqlCommand cmdprof;
        //lectura de datos SQL
        private SqlDataReader draprof;
        int res = 0;

        //funcion que muestra todos los datos activos de profesor
        public List<ProfesorBO> MostrarProfesor()
        {
            List<ProfesorBO> profesores = new List<ProfesorBO>();
            try
            {
                cmdprof = new SqlCommand();
                cmdprof.CommandType = CommandType.StoredProcedure;
                cmdprof.CommandText = "SP_MostrarProfesor";
                cmdprof.Connection = objconexion.Conectar();
                draprof = cmdprof.ExecuteReader();
                while (draprof.Read())
                {
                    ProfesorBO objprof = new ProfesorBO();
                    objprof.codigo = Convert.ToInt32(draprof["codProf"].ToString());
                    objprof.nombre = draprof["nomProf"].ToString();
                    objprof.apellidoPaterno = draprof["apepProf"].ToString();
                    objprof.apellidoMaterno = draprof["apemProf"].ToString();
                    objprof.correo = draprof["correoProf"].ToString();
                    objprof.direccion = draprof["dirProf"].ToString();
                    objprof.estado = Convert.ToBoolean(draprof["estProf"].ToString());
                    profesores.Add(objprof);
                }
                return profesores;
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

        //funcion para mostrar a todos los profesores (Activos o Inactivos)
        public List<ProfesorBO> MostrarProfesorTodo()
        {
            List<ProfesorBO> profesores = new List<ProfesorBO>();
            try
            {
                cmdprof = new SqlCommand();
                cmdprof.CommandType = CommandType.StoredProcedure;
                cmdprof.CommandText = "SP_MostrarProfesorTodo";
                cmdprof.Connection = objconexion.Conectar();
                draprof = cmdprof.ExecuteReader();
                while (draprof.Read())
                {
                    ProfesorBO objprof = new ProfesorBO();
                    objprof.codigo = Convert.ToInt32(draprof["codProf"].ToString());
                    objprof.nombre = draprof["nomProf"].ToString();
                    objprof.apellidoPaterno = draprof["apepProf"].ToString();
                    objprof.apellidoMaterno = draprof["apemProf"].ToString();
                    objprof.correo = draprof["correoProf"].ToString();
                    objprof.direccion = draprof["dirProf"].ToString();
                    objprof.estado = Convert.ToBoolean(draprof["estProf"].ToString());
                    profesores.Add(objprof);
                }
                return profesores;
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

        //funcion para registrar profesor
        public bool RegistrarProfesor(ProfesorBO bp)
        {
            try
            {
                cmdprof = new SqlCommand();
                cmdprof.CommandType = CommandType.StoredProcedure;
                cmdprof.CommandText = "SP_RegistrarProfesor";
                cmdprof.Connection = objconexion.Conectar();

                cmdprof.Parameters.AddWithValue("@nomProf", bp.nombre);
                cmdprof.Parameters.AddWithValue("@apepProf", bp.apellidoPaterno);
                cmdprof.Parameters.AddWithValue("@apemProf", bp.apellidoMaterno);
                cmdprof.Parameters.AddWithValue("@correoProf", bp.correo);
                cmdprof.Parameters.AddWithValue("@dirProf", bp.direccion);
                cmdprof.Parameters.AddWithValue("@estProf", bp.estado);

                res = cmdprof.ExecuteNonQuery();

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

        //funcion para actualizar profesor
        public bool ActualizarProfesor(ProfesorBO bp)
        {
            try
            {
                cmdprof = new SqlCommand();
                cmdprof.CommandType = CommandType.StoredProcedure;
                cmdprof.CommandText = "SP_ActualizarProfesor";
                cmdprof.Connection = objconexion.Conectar();

                cmdprof.Parameters.AddWithValue("@codProf", bp.codigo);
                cmdprof.Parameters.AddWithValue("@nomProf", bp.nombre);
                cmdprof.Parameters.AddWithValue("@apepProf", bp.apellidoPaterno);
                cmdprof.Parameters.AddWithValue("@apemProf", bp.apellidoMaterno);
                cmdprof.Parameters.AddWithValue("@correoProf", bp.correo);
                cmdprof.Parameters.AddWithValue("@dirProf", bp.direccion);
                cmdprof.Parameters.AddWithValue("@estProf", bp.estado);

                res = cmdprof.ExecuteNonQuery();

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

        //funcion para eliminar alumno (cambiar el estado a inactivo)
        public bool EliminarProfesor(ProfesorBO bp)
        {
            try
            {
                cmdprof = new SqlCommand();
                cmdprof.CommandType = CommandType.StoredProcedure;
                cmdprof.CommandText = "SP_EliminarProfesor";
                cmdprof.Connection = objconexion.Conectar();

                cmdprof.Parameters.AddWithValue("@codProf", bp.codigo);

                res = cmdprof.ExecuteNonQuery();

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
