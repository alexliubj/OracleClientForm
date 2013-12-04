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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        public ReportForm(DataTable dt)
        {
            InitializeComponent();

            ReportOrder cr = new ReportOrder();
            cr.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cr;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
