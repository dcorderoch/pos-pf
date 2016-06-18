using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WEBAPI.Reports
{
    public partial class LowInventoryReport : Form
    {
        public LowInventoryReport()
        {
            InitializeComponent();
        }

        private void LowInventoryReport_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ReportDataset.Product' Puede moverla o quitarla según sea necesario.
            this.ProductTableAdapter.Fill(this.ReportDataset.Product);

            this.reportViewer1.RefreshReport();
        }

        private void CreatePDF(string fileName)
        {
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;


            // Setup the report viewer object and get the array of bytes
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "YourReportHere.rdlc";


            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download
        }
    }
}
