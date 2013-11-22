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

        private void SetCheckboxGroup(bool status)
        {
            Control[] c = this.Controls.Find("groupBox3", true);
            foreach (Control a in c)
            {
                foreach (Control g in a.Controls)
                {
                    if (g is TextBox)
                        g.Enabled = !status;
                }
            }
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
            txt_Name.Text = customer.CustFirstName + " " + customer.CustLastName;
            txt_post.Text = customer.PostCode;
            cb_Rate.Text = customer.DiscountRate.ToString();
            txt_Name.Text = customer.CUSTNAME.ToString();
            if (String.Compare(customer.MutiAddress, "Y") == 0)
            {
                chk_ship.Checked = true;
                SetCheckboxGroup(true);
            }
            else
            {
                chk_ship.Checked = false;
                SetCheckboxGroup(false);
                

                m_address.Text = customer.ShipInfo.ShippingStreet;
                m_city.Text = customer.ShipInfo.ShippingCity;
                m_first.Text = customer.ShipInfo.ShippingFirstName;
                m_last.Text = customer.ShipInfo.ShippingLastName;
                m_postcode.Text = customer.ShipInfo.ShipppingPost;
                m_state.Text = customer.ShipInfo.ShippingState;
                m_Phone.Text = customer.ShipInfo.ShippingPhone.ToString();
            }
        }

        private Customer GetAllCustomerFromComponents()
        {
            Customer aCustomer = new Customer();
            aCustomer.CustomerId = Int32.Parse(txt_id.Text);
            aCustomer.Street = txt_Add.Text;
            aCustomer.State = txt_State.Text;
            aCustomer.Phone = txt_Phone.Text;
            aCustomer.City = txt_City.Text;
            aCustomer.CustLastName = txt_ln.Text;
            aCustomer.CustFirstName = txt_fn.Text;
            aCustomer.PostCode = txt_post.Text;
            aCustomer.DiscountRate = float.Parse(cb_Rate.Text);
            aCustomer.CUSTNAME = txt_Name.Text;
            if (!chk_ship.Checked)
            {
                aCustomer.MutiAddress = "N";
                ShippingInfo aInfo = new ShippingInfo();
                aInfo.CustosmerId = aCustomer.CustomerId;
                aInfo.ShippingStreet = m_address.Text;
                aInfo.ShippingCity = m_city.Text;
                aInfo.ShippingFirstName = m_first.Text;
                aInfo.ShippingLastName = m_last.Text;
                aInfo.ShipppingPost = m_postcode.Text;
                aInfo.ShippingState = m_state.Text;
                aInfo.ShippingPhone = Int32.Parse(m_Phone.Text.ToString());
                aCustomer.ShipInfo = aInfo;
            }
            else
            {
                aCustomer.MutiAddress = "Y";
            }
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

        private void SetPrice()
        { 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectIndex = dataGridView1.CurrentRow.Index;
           // int selectIndex = Int32.Parse( this.dataGridView1.SelectedCells[0].Value.ToString());
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
                        if (!chk_ship.Checked)
                        {
                            if (m_address.Text != string.Empty &&
                                m_city.Text != string.Empty &&
                                m_first.Text != string.Empty &&
                                m_last.Text != string.Empty &&
                                m_Phone.Text != string.Empty &&
                                m_postcode.Text != string.Empty &&
                                m_state.Text != string.Empty)
                            {
                                Customer insertCustomer = GetAllCustomerFromComponents();
                                CustomerLAO.addNewCustomer(insertCustomer);
                            }
                            else
                            {

                                MessageBox.Show("Address Error", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            Customer insertCustomer = GetAllCustomerFromComponents();
                            CustomerLAO.addNewCustomer(insertCustomer);
                        }
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

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //cancle
            this.Close();
        }

        private void chk_ship_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ship.Checked == false)
            {
                SetCheckboxGroup(false);
            }
            else
            {
                SetCheckboxGroup(true);
            }

        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            
        }
    }
}
