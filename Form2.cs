using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;


namespace Presentismo
{
    public partial class FrmRep : Form
    {
        private Representantes oCuello;
        private string nombreUsuario;
        Representantes oRepresentantes;
        private string dniEmpleado;
        private string nombreEmpleado;

        public FrmRep(string nombreUsuario)
        {
            InitializeComponent();
            oCuello = new Representantes();
            oRepresentantes = new Representantes();
            this.nombreUsuario = nombreUsuario;
            DgvRep.CellDoubleClick += DgvRep_CellDoubleClick;
            Load += FrmRep_Load;
        }

        private void FrmRep_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarComboBoxEstados();



        }

        private void CargarDatos()
        {
            DataTable representantes = null;

            switch (nombreUsuario)
            {
                case "LautaroCuello":
                    representantes = oCuello.GetLC();
                    break;
                case "EnriqueJuarez":
                    representantes = oCuello.GetEJ();
                    break;
                case "FrancoAlegranza":
                    representantes = oCuello.GetFA();
                    break;
                case "CarolinaGomez":
                    representantes = oCuello.GetCG();
                    break;
                case "PaolaOviedo":
                    representantes = oCuello.GetPO();
                    break;
                case "MaximilianoBurgos":
                    representantes = oCuello.GetMB();
                    break;
                case "PedroFernandez":
                    representantes = oCuello.GetPF();
                    break;

                case "SamuelNuñez":
                    representantes = oCuello.GetSN();
                    break;
                default:
                    MessageBox.Show("Nombre de usuario no válido.");
                    return;
            }

            DataTable estados = oCuello.GetEstados();
            DataTable area = oCuello.GetArea();

            DgvRep.Rows.Clear();

            foreach (DataRow representanteRow in representantes.Rows)
            {
                string dniEmpleado = representanteRow["DNI"].ToString();
                string nombreEmpleado = representanteRow["Representante"].ToString();
                int estadoCodigo = Convert.ToInt32(representanteRow["Estado"]);
                DataRow[] estadoRows = estados.Select($"Estado = {estadoCodigo}");
                string nombreEstado = estadoRows.Length > 0 ? estadoRows[0]["Nombre"].ToString() : "Estado Desconocido";
                DateTime ingreso = Convert.ToDateTime(representanteRow["Ingreso"]);
                TimeSpan horaIngreso = ingreso.TimeOfDay;
                int diasLicencia = 0;
                if (!Convert.IsDBNull(representanteRow["Dias"]))
                {
                    diasLicencia = Convert.ToInt32(representanteRow["Dias"]);
                }
                int areaCodigo = Convert.ToInt32(representanteRow["Area"]);
                DataRow[] areaRows = area.Select($"Area = {areaCodigo}");
                string nombreArea = areaRows.Length > 0 ? areaRows[0]["Nombre"].ToString() : "Área Desconocida";

                DateTime fechaLicencia;
                if (!Convert.IsDBNull(representanteRow["FechaLic"]))
                {
                    fechaLicencia = Convert.ToDateTime(representanteRow["FechaLic"]);
                    int diasRestantes = diasLicencia - (int)(DateTime.Today - fechaLicencia).TotalDays;
                    diasRestantes = Math.Max(diasRestantes, 0);

                    DgvRep.Rows.Add(dniEmpleado, nombreEmpleado, nombreEstado, horaIngreso, diasRestantes, nombreArea);
                }
                else
                {
                    DgvRep.Rows.Add(dniEmpleado, nombreEmpleado, nombreEstado, horaIngreso, diasLicencia, nombreArea);
                }
            }


        }

        public void ActualizarDataGridView()
        {
            CargarDatos();
        }

        private void DgvRep_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DgvRep.Columns["DNI"].Index)
            {
                DataGridViewRow row = DgvRep.Rows[e.RowIndex];
                dniEmpleado = row.Cells["DNI"].Value.ToString();
                nombreEmpleado = row.Cells["Representante"].Value.ToString();
                LblNombre.Text = nombreEmpleado;
            }
        }


        private void DgvRep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





        private void FrmEstados_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActualizarDataGridView();
        }

        private void CargarComboBoxEstados()
        {
            DataTable estados = oRepresentantes.GetEstados();

            CmbEstado.Items.Clear();

            foreach (DataRow row in estados.Rows)
            {
                int estado = Convert.ToInt32(row["Estado"]);
                string nombre = row["Nombre"].ToString();
                CmbEstado.Items.Add(new KeyValuePair<int, string>(estado, nombre));
            }

            if (CmbEstado.Items.Count > 0)
            {
                CmbEstado.SelectedIndex = 0;
            }
        }

        private void CmbEstado_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (CmbEstado.SelectedItem != null)
            {
                KeyValuePair<int, string> estadoSeleccionado = (KeyValuePair<int, string>)CmbEstado.SelectedItem;

                if (estadoSeleccionado.Value == "Licencia")
                {
                    CargarComboBoxTabla();
                }

            }


            if (CmbEstado.SelectedItem != null)
            {
                KeyValuePair<int, string> estadoSeleccionado = (KeyValuePair<int, string>)CmbEstado.SelectedItem;

                if (estadoSeleccionado.Value == "Cambio")
                {
                    FrmCambio cambio = new FrmCambio();
                    cambio.ShowDialog();

                }

            }

        }

        private void CmbLicencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarComboBoxTabla()
        {
            DataTable licencias = oRepresentantes.GetLIC();

            CmbLicencia.Items.Clear();

            foreach (DataRow row in licencias.Rows)
            {
                int idLicencia = Convert.ToInt32(row["Licencia"]);
                string nombreLicencia = row["Nombre"].ToString();
                CmbLicencia.Items.Add(new KeyValuePair<int, string>(idLicencia, nombreLicencia));
            }
            if (CmbLicencia.Items.Count > 0)
            {
                CmbLicencia.SelectedIndex = 0;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (CmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un estado.");
                return;
            }

            KeyValuePair<int, string> estadoSeleccionado = (KeyValuePair<int, string>)CmbEstado.SelectedItem;
            int idEstado = estadoSeleccionado.Key;
            string nombreEstado = estadoSeleccionado.Value;

            int idLicencia = 0;
            int diasLicencia = 0;
            string nombreLicencia = "";

            if (estadoSeleccionado.Value == "Licencia" && CmbLicencia.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una licencia.");
                return;
            }

            if (estadoSeleccionado.Value == "Licencia")
            {
                KeyValuePair<int, string> licenciaSeleccionada = (KeyValuePair<int, string>)CmbLicencia.SelectedItem;
                idLicencia = licenciaSeleccionada.Key;
                nombreLicencia = licenciaSeleccionada.Value;

                diasLicencia = oRepresentantes.ObtenerDiasLicencia(idLicencia);
            }
            DateTime fechaLic = DtpDia.Value;
            string fechaLicFormatted = fechaLic.ToString("dd/MM/yyyy");

            if (oRepresentantes.ActualizarEstadoEmpleado("LautaroCuello", dniEmpleado, idEstado, diasLicencia, fechaLicFormatted) &&
                oRepresentantes.ActualizarEstadoEmpleado("EnriqueJuarez", dniEmpleado, idEstado, diasLicencia, fechaLicFormatted) &&
                oRepresentantes.ActualizarEstadoEmpleado("CarolinaGomez", dniEmpleado, idEstado, diasLicencia, fechaLicFormatted) &&
                 oRepresentantes.ActualizarEstadoEmpleado("MaximilianoBurgos", dniEmpleado, idEstado, diasLicencia, fechaLicFormatted) &&
                 oRepresentantes.ActualizarEstadoEmpleado("PedroFernandez", dniEmpleado, idEstado, diasLicencia, fechaLicFormatted) &&
                 oRepresentantes.ActualizarEstadoEmpleado("PaolaOviedo", dniEmpleado, idEstado, diasLicencia, fechaLicFormatted) &&
                oRepresentantes.ActualizarEstadoEmpleado("FrancoAlegranza", dniEmpleado, idEstado, diasLicencia, fechaLicFormatted) &&
                oRepresentantes.ActualizarEstadoEmpleado("SamuelNuñez", dniEmpleado, idEstado, diasLicencia, fechaLicFormatted))
            {
                MessageBox.Show($"Estado del empleado {nombreEmpleado} actualizado correctamente a {nombreEstado}.");

                ActualizarDataGridView();


            }
            else
            {
                MessageBox.Show("Error al actualizar el estado del empleado.");
            }
        }
        private void BtnSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 sesion = new Form1();
            sesion.Show();
            this.Close();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            FrmExportar exportar = new FrmExportar(DgvRep);
            exportar.Show();
            this.Hide();
        }
        

    }
}







