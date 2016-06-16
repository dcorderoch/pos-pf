using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
