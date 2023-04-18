using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Datos
{
    public class DRegion
    {
        public   List<Region> Listar()
        {

            //Obtengo la conexión
            SqlConnection connection = null;
            SqlParameter param = null;
            SqlCommand command = null;
            List<Region> regiones = null;
            try
            {
                connection = new SqlConnection("Data Source=HUGO-PC\\SQLEXPRESS;Initial Catalog=CAVV_MonitoreoViolencia;Integrated Security=True;");

                connection.Open();

                //Hago mi consulta
                command = new SqlCommand("USP_GetRegion", connection);
                command.CommandType = CommandType.StoredProcedure;

                //param = new SqlParameter();
                //param.ParameterName = "@Description";
                //param.SqlDbType = SqlDbType.VarChar;
                //param.Value = description;

                //command.Parameters.Add(param);

                SqlDataReader reader = command.ExecuteReader();
                regiones = new List<Region>();


                while (reader.Read())
                {

                    Region region = new Region();
                    region.IdRegion = (int)reader["RegionID"];
                    region.Description = reader["Description"].ToString();
                    region.Code = reader["Code"].ToString();

                    regiones.Add(region);

                }

                connection.Close();

                //Muestro la información
                return regiones;


            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            finally
            {
                connection = null;
                command = null;
                param = null;
                regiones = null;

            }


        }
    }
}
