using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace TestConnetORCL.Report
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(DataTable dt)
        {
            InitializeComponent();

            ProductReport cr = new ProductReport();
            cr.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cr;
        }

    }
}
