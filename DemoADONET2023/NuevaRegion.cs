using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoADONET2023
{
    public partial class NuevaRegion : Form
    {
        public NuevaRegion()
        {
            InitializeComponent();
        }

        private void Grabar_Click(object sender, EventArgs e)
        {

            try
            {
                BRegion negocio = new BRegion();
                negocio.Insertar(new Entidad.Region
                {
                    Code = txtCode.Text,
                    Description = txtDescription.Text,
                });
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

            }
            

        }
    }
}
