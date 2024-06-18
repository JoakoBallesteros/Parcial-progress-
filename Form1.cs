using System;
using System.Data;
using System.Windows.Forms;

namespace Presentismo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = TxtUsuario.Text;
            string contraseña = TxtContraseña.Text;

           
            if (nombreUsuario == "LautaroCuello" || nombreUsuario == "EnriqueJuarez" || nombreUsuario == "FrancoAlegranza" || nombreUsuario == "SamuelNuñez" || nombreUsuario == "PaolaOviedo" || nombreUsuario == "CarolinaGomez" || nombreUsuario == "MaximilianoBurgos" || nombreUsuario == "PedroFernandez")
                
            {
                if (contraseña == "rosario")
                {
                    FrmRep rep = new FrmRep(nombreUsuario); 
                    rep.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta.");
                }

            }
            else
            {
                MessageBox.Show("Nombre de usuario no válido.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
