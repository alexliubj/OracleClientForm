using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLogic.DataAccessLayer;
using DataLogic.LogicLayer;
using DataLogic.Model;
using TestConnetORCL.Report;
using System.Reflection;


namespace xtreme
{
    public partial class frmOrderQuery : Form
    {
        private List<Order> listOrder = new List<Order>();
        private List<Reports> listReports = new List<Reports>();
        public frmOrderQuery()
        {
            InitializeComponent();


            listOrder = OrderLAO.GetAllOrders();
            if (listOrder.Count > 0)
            {
                string[] orderIdList = new string[listOrder.Count];
                for (int i = 0; i < listOrder.Count; i++)
                {
                    orderIdList[i] = ((Order)listOrder[i]).OrderId.ToString();
                }
                this.cbx_id.Items.AddRange(orderIdList);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listReports.Clear();
            if (cbx_id.Text == string.Empty)
            {
                listReports = OrderLAO.GetAllOrderWithInfo(0, chk_Pending.Checked);
            }
            else {
                Order o = new Order();
                listReports = OrderLAO.GetAllOrderWithInfo(Int32.Parse(cbx_id.Text), chk_Pending.Checked);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listReports;
        }

        private void butGPA_Click(object sender, EventArgs e)
        {
            DataSet1.ReportsDataTable dt = new DataSet1.ReportsDataTable();
            dt = (DataSet1.ReportsDataTable)SetOrderDetails(listReports);
            ReportForm rf = new ReportForm(dt);
            rf.Show();
        }

        public static DataTable SetOrderDetails(List<Reports> orderlist)
        {
            DataSet1.ReportsDataTable dt = new DataSet1.ReportsDataTable();
            try
            {
                foreach (var cust in orderlist)
                {
                    DataRow newRow = dt.NewRow();
                    foreach (PropertyInfo property in cust.GetType().GetProperties())
                    {
                        if (property.Name != "discount")
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
