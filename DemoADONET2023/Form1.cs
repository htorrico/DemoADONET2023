using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoADONET2023
{
    public partial class Form1 : Form
    {

        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

            ListarRegionesDataTable();

        }

        private void btnListar2_Click(object sender, EventArgs e)
        {
            dgvDemo2.DataSource= table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            ListarRegionesDataReader();
        }

         

        private void ListarRegionesDataReader()
        {

            //Obtengo la conexión
            SqlConnection connection=null;
            SqlParameter param = null;
            SqlCommand command = null;
            List<Region> regiones = null;
            try
            {
               connection = new SqlConnection("Data Source=HUGO-PC\\SQLEXPRESS;Initial Catalog=CAVV_MonitoreoViolencia;Integrated Security=True;");

                connection.Open();
                
                //Hago mi consulta
                command = new SqlCommand("USP_ListarRegion", connection);
                command.CommandType = CommandType.StoredProcedure;

                param= new SqlParameter();
                param.ParameterName = "@Description";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = txtDescription.Text;

                command.Parameters.Add(param);

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
                dgvDemo.DataSource = regiones;


            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            finally
            {
                connection = null;
                command= null;
                param= null;
                regiones= null;

            }

            
           


           

        }
        private void ListarRegionesDataTable()
        {
            //Obtengo la conexión
            SqlConnection connection = new SqlConnection("Data Source=HUGO-PC\\SQLEXPRESS;Initial Catalog=CAVV_MonitoreoViolencia;Integrated Security=True;");
            DataTable table2 = new DataTable();


            connection.Open();
            //Hago mi consulta
            SqlCommand command = new SqlCommand("USP_ListarRegion", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Description";
            param.SqlDbType = SqlDbType.VarChar;
            param.Value = txtDescription.Text;

            command.Parameters.Add(param);

            //Almaceno mi consulta
            SqlDataAdapter adapter = new SqlDataAdapter(command);


            //Lleno mi tabla
            adapter.Fill(table2);
            connection.Close();

            //Muestro la información
            dgvDemo.DataSource = table2;

        }
    }
}
