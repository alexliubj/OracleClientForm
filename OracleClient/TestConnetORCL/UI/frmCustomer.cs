using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLogic.Model;
using DataLogic;
using DataLogic.DataAccessLayer;
using DataLogic.LogicLayer;
namespace xtreme
{
    public partial class frmCustomer : Form
    {
        private int datagridSlect = 0;
        private Customer selectCucstoemr = new Customer();
        private List<Customer> listCustomer = new List<Customer>();
        currentStatusEnum currentStatus = currentStatusEnum.nonStatus;
        enum currentStatusEnum
        {
            nonStatus = 0,
            addingStatus = 1,
            editingStatus = 2,
        };
        public frmCustomer()
        {
            InitializeComponent();
            InitCustomerList();
            InitAllComponetsStatus(false);
        }

        private void SetAllComponetsValues(Customer customer)
        {
            txt_id.Text = customer.CustomerId.ToString();
            txt_Add.Text = customer.Street;
            txt_State.Text = customer.State;
            txt_Phone.Text = customer.Phone.ToString();
            txt_City.Text = customer.City.ToString();
            txt_ln.Text = customer.CustLastName;
            txt_fn.Text = customer.CustFirstName.ToString();
            txt_Name.Text = customer.CustFirstName + customer.CustLastName;
        }

        private Customer GetAllCustomerFromComponents()
        {
            Customer aCustomer = new Customer();
            aCustomer.CustomerId = Int32.Parse(txt_id.Text);
            aCustomer.Street = txt_Add.Text;
            aCustomer.State = txt_State.Text;
            aCustomer.Phone = Int32.Parse(txt_Phone.Text);
            aCustomer.City = txt_City.Text;
            aCustomer.CustLastName = txt_ln.Text;
            aCustomer.CustFirstName = txt_fn.Text;

            return aCustomer;
        }

        private void CleanAllTheComponest()
        {
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control a in c.Controls)
                    {
                        if (a is TextBox)
                        {
                            a.Text = "";
                        }
                        if (a is GroupBox)
                        {
                            foreach (Control g in a.Controls)
                            {
                                if (g is TextBox)
                                {
                                    g.Text = "";
                                }
                            }

                        }
                    }
                }
            
            }
        }
        private void InitAllComponetsStatus(bool status)
        {
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control a in c.Controls)
                    {
                        if (a is DataGridView)
                            a.Enabled = true;
                        else
                        {
                             a.Enabled = status;
                        }
                    }
                }
            }
        }
        private void InitCustomerList()
        {
            listCustomer = CustomerLAO.GetAllCustomers();
            dataGridView1.DataSource = listCustomer;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectIndex = dataGridView1.CurrentRow.Index;
            datagridSlect = selectIndex;
            InitAllComponetsStatus(true);
            Customer aCustomer = new Customer();
            aCustomer = listCustomer[selectIndex];
            SetAllComponetsValues(aCustomer);
            currentStatus = currentStatusEnum.editingStatus;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentStatus = currentStatusEnum.addingStatus;
            InitAllComponetsStatus(true);
            CleanAllTheComponest();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (currentStatus)
            {
                case currentStatusEnum.addingStatus:
                    {
                        Customer insertCustomer = GetAllCustomerFromComponents();
                        CustomerLAO.addNewCustomer(insertCustomer);
                    }
                    break;
                case currentStatusEnum.editingStatus:
                    {
                        Customer updateCustomer = GetAllCustomerFromComponents();
                        CustomerLAO.UpdateCustomer(updateCustomer);
                    }
                    break;
                case currentStatusEnum.nonStatus:
                    { }
                    break;
                default:
                    break;
            }
            InitCustomerList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //cancle
            this.Close();
        }
    }
}
