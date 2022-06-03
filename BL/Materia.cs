using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MCastanedaDigiProEntities context = new DL_EF.MCastanedaDigiProEntities())
                // using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo);
                    // string query = "UsuarioAdd";
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }

            catch (Exception ex)
            {


                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MCastanedaDigiProEntities context = new DL_EF.MCastanedaDigiProEntities())

                {
                    var query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo); 
                    
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }

            catch (Exception ex)
            {


                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try

            {
                using (DL_EF.MCastanedaDigiProEntities context = new DL_EF.MCastanedaDigiProEntities())
                {
                    var query = context.MateriaDelete(materia.IdMateria);


                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {

                        result.Correct = false;
                    }





                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MCastanedaDigiProEntities context = new DL_EF.MCastanedaDigiProEntities())

                {
                    var query = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo.Value;
                         
                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MCastanedaDigiProEntities context = new DL_EF.MCastanedaDigiProEntities())
                {
                    var obmateria = context.MateriaGetById(IdMateria).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (obmateria != null)
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = obmateria.IdMateria;
                        materia.Nombre = obmateria.Nombre;
                        materia.Costo = obmateria.Costo.Value;
                      


                        result.Object = materia;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    }





}



