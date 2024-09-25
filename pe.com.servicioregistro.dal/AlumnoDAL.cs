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
    public class AlumnoDAL
    {
        //objeto de la clase conexion
        ConexionDAL objconexion = new ConexionDAL();

        //comando SQL
        private SqlCommand cmdalum;
        //lectura de datos SQL
        private SqlDataReader dralum;
        int res = 0;

        //funcion que muestra todos los datos activos de alumno
        public List<AlumnoBO> MostrarAlumno()
        {
            List<AlumnoBO> alumnos = new List<AlumnoBO>();
            try
            {
                cmdalum = new SqlCommand();
                cmdalum.CommandType = CommandType.StoredProcedure;
                cmdalum.CommandText = "SP_MostrarAlumno";
                cmdalum.Connection = objconexion.Conectar();
                dralum = cmdalum.ExecuteReader();
                while (dralum.Read())
                {
                    AlumnoBO objalum = new AlumnoBO();
                    objalum.codigo = Convert.ToInt32(dralum["codAlum"].ToString());
                    objalum.nombre = dralum["nomAlum"].ToString();
                    objalum.apellidoPaterno = dralum["apepAlum"].ToString();
                    objalum.apellidoMaterno = dralum["apemAlum"].ToString();
                    objalum.direccion = dralum["dirAlum"].ToString();
                    objalum.correo = dralum["correoAlum"].ToString();
                    objalum.estado = Convert.ToBoolean(dralum["estAlum"].ToString());
                    alumnos.Add(objalum);
                }
                return alumnos;
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

        //funcion para mostrar a todos los alumnos (Activos o Inactivos)
        public List<AlumnoBO> MostrarAlumnoTodo()
        {
            List<AlumnoBO> alumnos = new List<AlumnoBO>();
            try
            {
                cmdalum = new SqlCommand();
                cmdalum.CommandType = CommandType.StoredProcedure;
                cmdalum.CommandText = "SP_MostrarAlumnoTodo";
                cmdalum.Connection = objconexion.Conectar();
                dralum = cmdalum.ExecuteReader();
                while (dralum.Read())
                {
                    AlumnoBO objalum = new AlumnoBO();
                    objalum.codigo = Convert.ToInt32(dralum["codAlum"].ToString());
                    objalum.nombre = dralum["nomAlum"].ToString();
                    objalum.apellidoPaterno = dralum["apepAlum"].ToString();
                    objalum.apellidoMaterno = dralum["apemAlum"].ToString();
                    objalum.direccion = dralum["dirAlum"].ToString();
                    objalum.correo = dralum["correoAlum"].ToString();
                    objalum.estado = Convert.ToBoolean(dralum["estAlum"].ToString());
                    alumnos.Add(objalum);
                }
                return alumnos;
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

        //funcion para registrar alumno
        public bool RegistrarAlumno(AlumnoBO ba)
        {
            try
            {
                cmdalum = new SqlCommand();
                cmdalum.CommandType = CommandType.StoredProcedure;
                cmdalum.CommandText = "SP_RegistrarAlumno";
                cmdalum.Connection = objconexion.Conectar();

                cmdalum.Parameters.AddWithValue("@nomAlum", ba.nombre);
                cmdalum.Parameters.AddWithValue("@apepAlum", ba.apellidoPaterno);
                cmdalum.Parameters.AddWithValue("@apemAlum", ba.apellidoMaterno);
                cmdalum.Parameters.AddWithValue("@dirAlum", ba.direccion);
                cmdalum.Parameters.AddWithValue("@correoAlum", ba.correo);
                cmdalum.Parameters.AddWithValue("@estAlum", ba.estado);

                res = cmdalum.ExecuteNonQuery();

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

        //funcion para actualizar alumno
        public bool ActualizarAlumno(AlumnoBO ba)
        {
            try
            {
                cmdalum = new SqlCommand();
                cmdalum.CommandType = CommandType.StoredProcedure;
                cmdalum.CommandText = "SP_ActualizarAlumno";
                cmdalum.Connection = objconexion.Conectar();

                cmdalum.Parameters.AddWithValue("@codAlum", ba.codigo);
                cmdalum.Parameters.AddWithValue("@nomAlum", ba.nombre);
                cmdalum.Parameters.AddWithValue("@apepAlum", ba.apellidoPaterno);
                cmdalum.Parameters.AddWithValue("@apemAlum", ba.apellidoMaterno);
                cmdalum.Parameters.AddWithValue("@dirAlum", ba.direccion);
                cmdalum.Parameters.AddWithValue("@correoAlum", ba.correo);
                cmdalum.Parameters.AddWithValue("@estAlum", ba.estado);

                res = cmdalum.ExecuteNonQuery();

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
        public bool EliminarAlumno(AlumnoBO ba)
        {
            try
            {
                cmdalum = new SqlCommand();
                cmdalum.CommandType = CommandType.StoredProcedure;
                cmdalum.CommandText = "SP_EliminarAlumno";
                cmdalum.Connection = objconexion.Conectar();

                cmdalum.Parameters.AddWithValue("@codAlum", ba.codigo);

                res = cmdalum.ExecuteNonQuery();

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
