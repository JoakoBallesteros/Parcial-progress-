using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml.Linq;

namespace Presentismo
{
    public partial class FrmExportar : Form
    {
        private DataGridView DgvRep; // DataGridView de donde exportar los datos

        public FrmExportar(DataGridView dgvDatos)
        {
            InitializeComponent();
            this.DgvRep = dgvDatos; // Asigna el DataGridView recibido como parámetro
        }

        private void FrmExportar_Load(object sender, EventArgs e)
        {
            CargarComboBoxFormatosExportacion();
        }

        private void CargarComboBoxFormatosExportacion()
        {
            CmbExportar.Items.Add("CSV");
            CmbExportar.Items.Add("Excel");
            CmbExportar.Items.Add("PDF");
            CmbExportar.SelectedIndex = 0; // Selecciona el primer formato por defecto
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            string formatoSeleccionado = CmbExportar.SelectedItem.ToString();

            switch (formatoSeleccionado)
            {
                case "CSV":
                    ExportarCSV();
                    break;
                case "Excel":
                    ExportarExcel();
                    break;
                case "PDF":
                    ExportarPDF();
                    break;
                default:
                    MessageBox.Show("Formato de exportación no válido.");
                    break;
            }
        }

        private void ExportarCSV()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            sfd.FileName = "exporte.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Encabezados
                    foreach (DataGridViewColumn column in DgvRep.Columns)
                    {
                        sb.Append(column.HeaderText).Append(',');
                    }
                    sb.AppendLine();

                    // Contenido
                    foreach (DataGridViewRow row in DgvRep.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sb.Append(cell.Value).Append(',');
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Datos exportados correctamente a CSV.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar a CSV: {ex.Message}");
                }
            }
        }

        private void ExportarExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = "exporte.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Configura el contexto de licencia
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // O LicenseContext.Commercial si tienes una licencia comercial

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Datos");

                        // Encabezados
                        for (int i = 0; i < DgvRep.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = DgvRep.Columns[i].HeaderText;
                        }

                        // Contenido
                        for (int i = 0; i < DgvRep.Rows.Count; i++)
                        {
                            for (int j = 0; j < DgvRep.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = DgvRep.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        FileInfo excelFile = new FileInfo(sfd.FileName);
                        excelPackage.SaveAs(excelFile);
                    }

                    MessageBox.Show("Datos exportados correctamente a Excel."); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar a Excel: {ex.Message}");
                }
            }
        }


        private void ExportarPDF()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.FileName = "exporte.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                    doc.Open();

                    PdfPTable pdfTable = new PdfPTable(DgvRep.ColumnCount);

                    // Encabezados
                    for (int i = 0; i < DgvRep.Columns.Count; i++)
                    {
                        pdfTable.AddCell(DgvRep.Columns[i].HeaderText);
                    }

                    // Contenido
                    for (int i = 0; i < DgvRep.Rows.Count; i++)
                    {
                        for (int j = 0; j < DgvRep.Columns.Count; j++)
                        {
                            pdfTable.AddCell(DgvRep[j, i].Value?.ToString());
                        }
                    }

                    doc.Add(pdfTable);
                    doc.Close();

                    MessageBox.Show("Datos exportados correctamente a PDF.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar a PDF: {ex.Message}");
                }
            }
        }
    }
}
