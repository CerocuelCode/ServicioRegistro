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
    public class AnioAcademicoDAL
    {
        //objeto de la clase conexion
        ConexionDAL objconexion = new ConexionDAL();

        //comando SQL
        private SqlCommand cmdanio;
        //lectura de datos SQL
        private SqlDataReader draanio;
        int res = 0;

        //funcion que muestra el anio academico activo
        public List<AnioAcademicoBO> MostrarAnioAcademico()
        {
            List<AnioAcademicoBO> aniosAcademicos = new List<AnioAcademicoBO>();
            try
            {
                cmdanio = new SqlCommand();
                cmdanio.CommandType = CommandType.StoredProcedure;
                cmdanio.CommandText = "SP_MostrarAnioAcademico";
                cmdanio.Connection = objconexion.Conectar();
                draanio = cmdanio.ExecuteReader();
                while (draanio.Read())
                {
                    AnioAcademicoBO objanio = new AnioAcademicoBO();
                    objanio.codigo = Convert.ToInt32(draanio["codAnioAcademico"].ToString());
                    objanio.fechaInicio = Convert.ToDateTime(draanio["fechaInicio"].ToString());
                    objanio.fehcaFin = Convert.ToDateTime(draanio["fechaFin"].ToString());
                    objanio.estado = Convert.ToBoolean(draanio["estanioAcademico"].ToString());
                    aniosAcademicos.Add(objanio);
                }
                return aniosAcademicos;
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

        //funcion para mostrar a todos los Años Academicos (Activos o Inactivos)
        public List<AnioAcademicoBO> MostrarAnioAcademicoTodo()
        {
            List<AnioAcademicoBO> aniosAcademicos = new List<AnioAcademicoBO>();
            try
            {
                cmdanio = new SqlCommand();
                cmdanio.CommandType = CommandType.StoredProcedure;
                cmdanio.CommandText = "SP_MostrarAnioAcademicoTodo";
                cmdanio.Connection = objconexion.Conectar();
                draanio = cmdanio.ExecuteReader();
                while (draanio.Read())
                {
                    AnioAcademicoBO objanio = new AnioAcademicoBO();
                    objanio.codigo = Convert.ToInt32(draanio["codAnioAcademico"].ToString());
                    objanio.fechaInicio = Convert.ToDateTime(draanio["fechaInicio"].ToString());
                    objanio.fehcaFin = Convert.ToDateTime(draanio["fechaFin"].ToString());
                    objanio.estado = Convert.ToBoolean(draanio["estanioAcademico"].ToString());
                    aniosAcademicos.Add(objanio);
                }
                return aniosAcademicos;
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

        //funcion para registrar Año Academico
        public bool RegistrarAnioAcademico(AnioAcademicoBO baa)
        {
            try
            {
                cmdanio = new SqlCommand();
                cmdanio.CommandType = CommandType.StoredProcedure;
                cmdanio.CommandText = "SP_RegistrarAnioAcademico";
                cmdanio.Connection = objconexion.Conectar();

                cmdanio.Parameters.AddWithValue("@fechaInicio", baa.fechaInicio);
                cmdanio.Parameters.AddWithValue("@fechaFin", baa.fehcaFin);
                cmdanio.Parameters.AddWithValue("@estanioAcademico", baa.estado);

                res = cmdanio.ExecuteNonQuery();

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

        //funcion para actualizar Año Academico
        public bool ActualizarAnioAcademico(AnioAcademicoBO baa)
        {
            try
            {
                cmdanio = new SqlCommand();
                cmdanio.CommandType = CommandType.StoredProcedure;
                cmdanio.CommandText = "SP_ActualizarAnioAcademico";
                cmdanio.Connection = objconexion.Conectar();

                cmdanio.Parameters.AddWithValue("@codAnioAcademico", baa.codigo);
                cmdanio.Parameters.AddWithValue("@fechaInicio", baa.fechaInicio);
                cmdanio.Parameters.AddWithValue("@fechaFin", baa.fehcaFin);
                cmdanio.Parameters.AddWithValue("@estanioAcademico", baa.estado);

                res = cmdanio.ExecuteNonQuery();

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

        //funcion para eliminar Año Academico (cambiar el estado a inactivo)
        public bool EliminarAnioAcademico(AnioAcademicoBO baa)
        {
            try
            {
                cmdanio = new SqlCommand();
                cmdanio.CommandType = CommandType.StoredProcedure;
                cmdanio.CommandText = "SP_EliminarAnioAcademico";
                cmdanio.Connection = objconexion.Conectar();

                cmdanio.Parameters.AddWithValue("@codProf", baa.codigo);

                res = cmdanio.ExecuteNonQuery();

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
