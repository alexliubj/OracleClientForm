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
    public partial class frmCustomerQuery : Form
    {
        private List<Customer> customer = new List<Customer>();
        private Customer cust;
        public frmCustomerQuery()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if (textBox_code.Text != string.Empty)
            {
                cust = CustomerLAO.getCustoemerById(Int32.Parse(textBox_code.Text));
                customer.Add(cust);
            }
            else
            {
                customer = CustomerLAO.GetAllCustomers();
                
            }
            dataGridView1.DataSource = customer;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet1.CustomerDataTable dt = new DataSet1.CustomerDataTable();
            dt = (DataSet1.CustomerDataTable) SetCustomerDetails(customer);
            ReportForm rf = new ReportForm(dt);
            rf.Show();
        }

        public static DataTable SetCustomerDetails(List<Customer> listCustomer)
        {
            DataSet1.CustomerDataTable dt = new DataSet1.CustomerDataTable();
            try
            {
                foreach (var cust in listCustomer)
                {
                    DataRow newRow = dt.NewRow();
                    foreach (PropertyInfo property in cust.GetType().GetProperties())
                    {
                        if (property.Name != "ShipInfo")
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
