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
    public class CursoDAL
    {
        //objeto de la clase conexion
        ConexionDAL objconexion = new ConexionDAL();

        //comando SQL
        private SqlCommand cmdcur;
        //lectura de datos SQL
        private SqlDataReader drcur;
        int res = 0;

        //funcion que muestra todos los datos activos de Curso
        public List<CursoBO> MostrarCurso()
        {
            List<CursoBO> curso = new List<CursoBO>();
            try
            {
                cmdcur = new SqlCommand();
                cmdcur.CommandType = CommandType.StoredProcedure;
                cmdcur.CommandText = "SP_MostrarCurso";
                cmdcur.Connection = objconexion.Conectar();
                drcur = cmdcur.ExecuteReader();
                while (drcur.Read())
                {
                    CursoBO objcur = new CursoBO();
                    ProfesorBO objpro = new ProfesorBO();
                    AnioAcademicoBO objanio = new AnioAcademicoBO();

                    objcur.codigo = Convert.ToInt32(drcur["codCurso"].ToString());
                    objcur.nombre = drcur["nomCurso"].ToString();
                    objcur.estado = Convert.ToBoolean(drcur["estCurso"].ToString());

                    objpro.codigo = Convert.ToInt32(drcur["codProf"].ToString());
                    objcur.profesor = objpro;

                    objanio.codigo = Convert.ToInt32(drcur["codAnioAcademico"].ToString());
                    objcur.anioAcademico = objanio;

                    curso.Add(objcur);
                }
                return curso;
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

        //funcion para mostrar todos los cursos (Activos o Inactivos)
        public List<CursoBO> MostrarCursoTodo()
        {
            List<CursoBO> curso = new List<CursoBO>();
            try
            {
                cmdcur = new SqlCommand();
                cmdcur.CommandType = CommandType.StoredProcedure;
                cmdcur.CommandText = "SP_MostrarCursoTodo";
                cmdcur.Connection = objconexion.Conectar();
                drcur = cmdcur.ExecuteReader();
                while (drcur.Read())
                {
                    CursoBO objcur = new CursoBO();
                    ProfesorBO objpro = new ProfesorBO();
                    AnioAcademicoBO objanio = new AnioAcademicoBO();

                    objcur.codigo = Convert.ToInt32(drcur["codCurso"].ToString());
                    objcur.nombre = drcur["nomCurso"].ToString();
                    objcur.estado = Convert.ToBoolean(drcur["estCurso"].ToString());

                    objpro.codigo = Convert.ToInt32(drcur["codProf"].ToString());
                    objcur.profesor = objpro;

                    objanio.codigo = Convert.ToInt32(drcur["codAnioAcademico"].ToString());
                    objcur.anioAcademico = objanio;

                    curso.Add(objcur);
                }
                return curso;
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

        //funcion para registrar curso
        public bool RegistrarCurso(CursoBO bc)
        {
            try
            {
                cmdcur = new SqlCommand();
                cmdcur.CommandType = CommandType.StoredProcedure;
                cmdcur.CommandText = "SP_RegistrarCurso";
                cmdcur.Connection = objconexion.Conectar();

                cmdcur.Parameters.AddWithValue("@nomCurso", bc.nombre);
                cmdcur.Parameters.AddWithValue("@codProf", bc.profesor.codigo);
                cmdcur.Parameters.AddWithValue("@codAnioAcademico", bc.anioAcademico.codigo);
                cmdcur.Parameters.AddWithValue("@estCurso", bc.estado);

                res = cmdcur.ExecuteNonQuery();

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

        //funcion para actualizar curso
        public bool ActualizarCurso(CursoBO bc)
        {
            try
            {
                cmdcur = new SqlCommand();
                cmdcur.CommandType = CommandType.StoredProcedure;
                cmdcur.CommandText = "SP_ActualizarCurso";
                cmdcur.Connection = objconexion.Conectar();

                cmdcur.Parameters.AddWithValue("@nomCurso", bc.nombre);
                cmdcur.Parameters.AddWithValue("@codProf", bc.profesor.codigo);
                cmdcur.Parameters.AddWithValue("@codAnioAcademico", bc.anioAcademico.codigo);
                cmdcur.Parameters.AddWithValue("@estCurso", bc.estado);

                res = cmdcur.ExecuteNonQuery();

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

        //funcion para eliminar curso (cambiar el estado a inactivo)
        public bool EliminarCurso(CursoBO bc)
        {
            try
            {
                cmdcur = new SqlCommand();
                cmdcur.CommandType = CommandType.StoredProcedure;
                cmdcur.CommandText = "SP_EliminarCurso";
                cmdcur.Connection = objconexion.Conectar();

                cmdcur.Parameters.AddWithValue("@codCurso", bc.codigo);

                res = cmdcur.ExecuteNonQuery();

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
