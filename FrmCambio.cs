using System;
using System.Data;
using System.Windows.Forms;

namespace Presentismo
{
    public partial class FrmCambio : Form
    {
        private Representantes oRepresentantes;

        public FrmCambio()
        {
            InitializeComponent();
            oRepresentantes = new Representantes();
            CargarLideres();
        }

        private void FrmCambio_Load(object sender, EventArgs e)
        {
            
        }

        private void CargarLideres()
        {
      
            string[] nombresLideres = { "LautaroCuello", "EnriqueJuarez", "FrancoAlegranza", "SamuelNuñez", "PaolaOviedo", "CarolinaGomez", "MaximilianoBurgos", "PedroFernandez" };

        
            cmbLideres.Items.Clear();

         
            foreach (string nombreLider in nombresLideres)
            {
                cmbLideres.Items.Add(nombreLider);
            }

       
            if (cmbLideres.Items.Count > 0)
            {
                cmbLideres.SelectedIndex = 0;
            }
        }

        private void cmbLideres_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreLider = cmbLideres.SelectedItem.ToString();

            CargarRepresentantes(nombreLider);
        }

        private void CargarRepresentantes(string nombreLider)
        {
          
            DataTable representantes = null;

           
            switch (nombreLider)
            {
                case "LautaroCuello":
                    representantes = oRepresentantes.GetLC();
                    break;
                case "EnriqueJuarez":
                    representantes = oRepresentantes.GetEJ();
                    break;
                case "FrancoAlegranza":
                    representantes = oRepresentantes.GetFA();
                    break;
                case "CarolinaGomez":
                    representantes = oRepresentantes.GetCG();
                    break;
                case "PaolaOviedo":
                    representantes = oRepresentantes.GetPO();
                    break;
                case "MaximilianoBurgos":
                    representantes = oRepresentantes.GetMB();
                    break;
                case "PedroFernandez":
                    representantes = oRepresentantes.GetPF();
                    break;
                case "SamuelNuñez":
                    representantes = oRepresentantes.GetSN();
                    break;
                default:
                    MessageBox.Show("Nombre de líder no válido.");
                    return; 
            }

          
            cmbRepresentantes.Items.Clear();

       
            foreach (DataRow row in representantes.Rows)
            {
                string nombreRepresentante = row["Representante"].ToString();
                cmbRepresentantes.Items.Add(nombreRepresentante);
            }

        
            if (cmbRepresentantes.Items.Count > 0)
            {
                cmbRepresentantes.SelectedIndex = 0;
            }
        }

        private void BtnCambiar_Click(object sender, EventArgs e)
        {
            string nombreLider = cmbLideres.SelectedItem.ToString();

        
            string representanteSeleccionado = cmbRepresentantes.SelectedItem.ToString();

            if (string.IsNullOrEmpty(representanteSeleccionado))
            {
                MessageBox.Show("Por favor, seleccione un representante.");
                return;
            }

       
            string nombreLiderDestino = "";
            foreach (string nombre in cmbLideres.Items)
            {
                if (nombre != nombreLider)
                {
                    nombreLiderDestino = nombre;
                    break;
                }
            }

          
            if (oRepresentantes.IntercambiarRepresentantes(nombreLider, representanteSeleccionado, nombreLiderDestino))
            {
                MessageBox.Show($"Se ha realizado el intercambio del representante {representanteSeleccionado} correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al realizar el intercambio de representantes.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
