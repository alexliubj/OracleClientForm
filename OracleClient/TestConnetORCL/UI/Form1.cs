using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DataLogic.LogicLayer;
using DataLogic.Model;
namespace TestConnetORCL
{
    public partial class Form1 : Form
    {
        private List<Employee> employeeList;
        public Form1()
        {
            InitializeComponent();
        }

        private void bindListView()
        {
            listView1.Items.Clear();
            foreach (Employee result in employeeList)
            {

                ListViewItem lvi = new ListViewItem(result.EmployeeId.ToString());
                ListViewItem lvi2 = new ListViewItem(result.FirstName.ToString());
                ListViewItem lvi3 = new ListViewItem(result.LastName.ToString());
                ListViewItem lvi4 = new ListViewItem(result.Dept.ToString());

                this.listView1.Items.AddRange(new ListViewItem[] { lvi, lvi2,lvi3,lvi4 });
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //service name : SQLD
            //comp214_f13_3 / password@cencol
            //port:1521
            //Host name : oracle1.centannialcollege.ca
            //TCPss

            employeeList = new List<Employee>();
            string connstring = "user id=comp214_f13_102;password=password;data source=" +
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                "(HOST=oracle1.centennialcollege.ca)(PORT=1521))(CONNECT_DATA=" +
                "(SERVICE_NAME=SQLD)))";
            this.label2.Text = connstring;
            string slqCmd = "select * from orderline";
            this.textBox1.Text = slqCmd;
            
            OracleConnection conn = new OracleConnection(connstring);
            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = this.textBox1.Text;
                OracleDataReader odr = cmd.ExecuteReader();
                while (odr.Read())
                {
                    Employee em = new Employee();
                    em.EmployeeId = odr.GetInt32(0);
                    em.FirstName = odr.GetString(1);
                    em.LastName = odr.GetString(2);
                    em.Dept = odr.GetString(3);
                    employeeList.Add(em);
                }
                odr.Close();
            }
            catch
            {
                MessageBox.Show("erro");
            }
            finally
            {
                conn.Close();
            }

            this.bindListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerLAO dao = new CustomerLAO();
            Customer cus = new Customer();
            cus = dao.getCustoemerById(1);
            this.label3.Text = cus.CustomerId.ToString();
            Console.WriteLine(cus.CustomerId);
        }
    }
}
