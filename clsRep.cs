using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace Presentismo
{
    class Representantes
    {
        private string cadena;
        private OleDbDataAdapter adaptador;

        public Representantes()
        {
            cadena = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ballesteros.mdb";
            adaptador = new OleDbDataAdapter();
        }
        //////////////////////////////////////////////////////////////LLAMADO DE TABLAS////////////////////////////////////////////////////////////
        public DataTable GetLC()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM LautaroCuello";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(tabla);


                        DataColumn[] vec = new DataColumn[1];
                        vec[0] = tabla.Columns["DNI"];
                        tabla.PrimaryKey = vec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los representantes: " + ex.Message);
            }

            return tabla;
        }
        public DataTable GetEJ()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM EnriqueJuarez";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(tabla);

                        DataColumn[] vec = new DataColumn[1];
                        vec[0] = tabla.Columns["DNI"];
                        tabla.PrimaryKey = vec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Enrique Juarez: " + ex.Message);
            }

            return tabla;
        }

        public DataTable GetFA()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM FrancoAlegranza";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(tabla);


                        DataColumn[] vec = new DataColumn[1];
                        vec[0] = tabla.Columns["DNI"];
                        tabla.PrimaryKey = vec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Franco Alegranza: " + ex.Message);
            }

            return tabla;
        }

        public DataTable GetSN()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM SamuelNuñez";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(tabla);

                        DataColumn[] vec = new DataColumn[1];
                        vec[0] = tabla.Columns["DNI"];
                        tabla.PrimaryKey = vec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Samuel Nuñez: " + ex.Message);
            }

            return tabla;
        }
        public DataTable GetPO()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM PaolaOviedo";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(tabla);

                        DataColumn[] vec = new DataColumn[1];
                        vec[0] = tabla.Columns["DNI"];
                        tabla.PrimaryKey = vec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Samuel Nuñez: " + ex.Message);
            }

            return tabla;
        }
        public DataTable GetSA()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM SofiaDeAsis";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(tabla);

                        DataColumn[] vec = new DataColumn[1];
                        vec[0] = tabla.Columns["DNI"];
                        tabla.PrimaryKey = vec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Samuel Nuñez: " + ex.Message);
            }

            return tabla;
        }
        public DataTable GetCG()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM CarolinaGomez";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(tabla);

                        DataColumn[] vec = new DataColumn[1];
                        vec[0] = tabla.Columns["DNI"];
                        tabla.PrimaryKey = vec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Samuel Nuñez: " + ex.Message);
            }

            return tabla;
        }
        public DataTable GetMB()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM MaximilianoBurgos";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(tabla);

                        DataColumn[] vec = new DataColumn[1];
                        vec[0] = tabla.Columns["DNI"];
                        tabla.PrimaryKey = vec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Samuel Nuñez: " + ex.Message);
            }

            return tabla;
        }
        public DataTable GetPF()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM PedroFernandez";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(tabla);

                        DataColumn[] vec = new DataColumn[1];
                        vec[0] = tabla.Columns["DNI"];
                        tabla.PrimaryKey = vec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Samuel Nuñez: " + ex.Message);
            }

            return tabla;
        }


        public DataTable GetLIC()
        {
            DataTable licencias = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM Licencias";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(licencias);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los estados: " + ex.Message);
            }

            return licencias;
        }


        public DataTable GetEstados()
        {
            DataTable estados = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM Estados";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(estados);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los estados: " + ex.Message);
            }

            return estados;
        }

        public DataTable GetArea()
        {
            DataTable estados = new DataTable();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT * FROM Area";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        conexion.Open();
                        adaptador.SelectCommand = comando;
                        adaptador.Fill(estados);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las areas: " + ex.Message);
            }

            return estados;
        }



        public int ObtenerDiasLicencia(int idLicencia)
        {
            int diasLicencia = 0;
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = "SELECT Dias FROM Licencias WHERE Licencia = @idLicencia";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idLicencia", idLicencia);
                        conexion.Open();
                        object resultado = comando.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            diasLicencia = Convert.ToInt32(resultado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los días de la licencia: " + ex.Message);
            }
            return diasLicencia;
        }












        //////////////////////////////////////////////////////////////ACTUALIZACIONES DE DATOS////////////////////////////////////////////////////////////






        public bool ActualizarEstadoEmpleado(string tabla, string dniEmpleado, int nuevoEstado, int diasLicencia, string fechaLicFormatted)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string consulta = $"UPDATE {tabla} SET Estado = @nuevoEstado, Dias = @diasLicencia, FechaLic = @fechaLic WHERE DNI = @dniEmpleado";
                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);
                        comando.Parameters.AddWithValue("@diasLicencia", diasLicencia);
                        comando.Parameters.AddWithValue("@fechaLic", fechaLicFormatted);
                        comando.Parameters.AddWithValue("@dniEmpleado", dniEmpleado);

                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado del empleado: " + ex.Message);
                return false;
            }
        }




        public bool IntercambiarRepresentantes(string nombreLiderOrigen, string representanteOrigen, string nombreLiderDestino)
        {
            try
            {

                DataTable representantesOrigen = null;
                DataTable representantesDestino = null;


                switch (nombreLiderOrigen)
                {
                    case "LautaroCuello":
                        representantesOrigen = GetLC();
                        break;
                    case "CarolinaGomez":
                        representantesOrigen = GetCG();
                        break;
                    case "PaolaOviedo":
                        representantesOrigen = GetPO();
                        break;
                    case "MaximilianoBurgos":
                        representantesOrigen = GetMB();
                        break;
                    case "PedroFernandez":
                        representantesOrigen = GetPF();
                        break;
                   
                    case "EnriqueJuarez":
                        representantesOrigen = GetEJ();
                        break;
                    case "FrancoAlegranza":
                        representantesOrigen = GetFA();
                        break;
                    case "SamuelNuñez":
                        representantesOrigen = GetSN();
                        break;
                    default:
                        MessageBox.Show("Nombre de líder origen no válido.");
                        return false;
                }


                switch (nombreLiderDestino)
                {
                    case "LautaroCuello":
                        representantesOrigen = GetLC();
                        break;
                    case "CarolinaGomez":
                        representantesOrigen = GetCG();
                        break;
                    case "PaolaOviedo":
                        representantesOrigen = GetPO();
                        break;
                    case "MaximilianoBurgos":
                        representantesOrigen = GetMB();
                        break;
                    case "PedroFernandez":
                        representantesOrigen = GetPF();
                        break;
                    case "EnriqueJuarez":
                        representantesOrigen = GetEJ();
                        break;
                    case "FrancoAlegranza":
                        representantesOrigen = GetFA();
                        break;
                    case "SamuelNuñez":
                        representantesOrigen = GetSN();
                        break;
                    default:
                        MessageBox.Show("Nombre de líder destino no válido.");
                        return false;
                }

                DataRow representanteRow = representantesOrigen.AsEnumerable()
                                            .FirstOrDefault(row => row.Field<string>("Representante") == representanteOrigen);

                if (representanteRow == null)
                {
                    MessageBox.Show("El representante no existe en el líder origen.");
                    return false;
                }


                DataRow nuevoRepresentante = representantesDestino.NewRow();
                nuevoRepresentante.ItemArray = representanteRow.ItemArray;
                representantesDestino.Rows.Add(nuevoRepresentante);


                representanteRow.Delete();

                ActualizarBaseDeDatos(representantesOrigen, nombreLiderOrigen);
                ActualizarBaseDeDatos(representantesDestino, nombreLiderDestino);

                representantesOrigen.AcceptChanges();
                representantesDestino.AcceptChanges();


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el intercambio de representantes: " + ex.Message);
                return false;
            }
        }

        private void ActualizarBaseDeDatos(DataTable representantes, string nombreLider)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {

                    string nombreTabla = "";
                    switch (nombreLider)
                    {
                        case "LautaroCuello":
                            nombreTabla = "LautaroCuello";
                            break;
                        case "EnriqueJuarez":
                            nombreTabla = "EnriqueJuarez";
                            break;
                        case "FrancoAlegranza":
                            nombreTabla = "FrancoAlegranza";
                            break;
                        case "SamuelNuñez":
                            nombreTabla = "SamuelNuñez";
                            break;
                        case "CarolinaGomez":
                            nombreTabla = "CarolinaGomez";
                            break;
                        case "PaolaOviedo":
                            nombreTabla = "PaolaOviedo";
                            break;
                        case "MaximilianoBurgos":
                            nombreTabla = "MaximilianoBurgos";
                            break;
                        case "PedroFernandez":
                            nombreTabla = "SamuelNuñez";
                            break;
                        default:
                            MessageBox.Show("Nombre de líder no válido.");
                            return;
                    }


                    using (OleDbDataAdapter adapter = new OleDbDataAdapter($"SELECT * FROM {nombreTabla}", conexion))
                    {
                        OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                        adapter.Update(representantes);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la base de datos: " + ex.Message);
            }
        }





    }
}