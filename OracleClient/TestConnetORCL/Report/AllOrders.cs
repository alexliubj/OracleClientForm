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
using DataLogic.Model;
using DataLogic.DataAccessLayer;
using DataLogic.LogicLayer;
using System.Reflection;
namespace TestConnetORCL.Report
{
    public partial class AllOrders : Form
    {
        private List<Reports> listReport =new List<Reports>();
        public AllOrders()
        {
            InitializeComponent();
        }
        public AllOrders(int reportType)
        {
            InitializeComponent();
            DataTable dt = GetReportFromDS(reportType);
            
            AllReport cr = new AllReport();
            cr.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cr;
        }

        public DataTable GetReportFromDS(int reportType)
        {
            DataSet1.ReportsDataTable dt = new DataSet1.ReportsDataTable();
            switch (reportType)
            {
                case 1: // aging < 30
                    listReport = OrderLAO.GetOrderByDate(1);
                    break;
                case 2: //outstanding
                   
                    listReport = OrderLAO.GetOutStandingReport(1);
                    break;
                case 3: //top customers
                    listReport = OrderLAO.GetTopCustomers(10);
                    break;
                case 4: // aging > 30 < 60
                    listReport = OrderLAO.GetOrderByDate(2);
                    break;
                case 5: // aging > 90
                    listReport = OrderLAO.GetOrderByDate(3);
                    break;
                default:
                    
                    break;
            }

             dt = (DataSet1.ReportsDataTable)SetReprots(listReport);
             return dt;
        }

        public static DataTable SetReprots(List<Reports> listReprots)
        {
            DataSet1.ReportsDataTable dt = new DataSet1.ReportsDataTable();
            try
            {
                foreach (var cust in listReprots)
                {
                    DataRow newRow = dt.NewRow();
                    foreach (PropertyInfo property in cust.GetType().GetProperties())
                    {
                        if(property.Name != "discount")
                            newRow[property.Name] = cust.GetType().GetProperty(property.Name).GetValue(cust, null);
                    }
                   dt.Rows.Add(newRow);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
