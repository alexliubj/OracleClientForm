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

namespace xtreme
{
    public partial class frmOrderLine : Form
    {
        private List<Order> listOrder = new List<Order>();
        private List<OrderLines> orderLine = new List<OrderLines>();
        private FormStatus currentStatus = FormStatus.nonstatus;

        private enum FormStatus
        {
            nonstatus =0,
            adding = 1,
            editing = 2,
            deleting = 3,
            updating = 4,
        };

        public frmOrderLine()
        {
            InitializeComponent();
            InitializeAllData();

            this.comb_prod.SelectedIndexChanged +=
            new System.EventHandler(ComboBox1_SelectedIndexChanged);
        }

        private void CleanAllComponets()
        { 
        }

        private void UpdateBottomInformation()
        { 
        }
        private void ComboBox1_SelectedIndexChanged(object sender,
            System.EventArgs e)
        {

            ComboBox comboBox = (ComboBox)sender;
            string selectedEmployee = (string)comb_prod.SelectedItem;
            int selectIndex = comb_prod.SelectedIndex;
            this.prod_qnt.Text = orderLine[selectIndex].Quantity.ToString();
        }
        private void SetAllProductInformation()
        {
            OrderLines[] arr = orderLine.ToArray();
            string[] productNameString = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                productNameString[i] = ((OrderLines)arr[i]).ProductInfo.ProductName;
            }
            this.comb_prod.Items.AddRange(productNameString);
            this.comb_prod.SelectedIndex = 0;
            this.prod_qnt.Text = ((OrderLines)arr[0]).Quantity.ToString();
        }
        private void SetCustomerInformation(Customer customer)
        {
            e_cust.Text = customer.CustomerId.ToString();
            txt_Add.Text = customer.Street;
            txt_State.Text = customer.State;
            txt_Phone.Text = customer.Phone.ToString();
            txt_City.Text = customer.City;
            txt_ln.Text = customer.CustLastName;
            txt_fn.Text = customer.CustFirstName.ToString();
            e_custName.Text = customer.CustFirstName + " " + customer.CustLastName;
            txt_post.Text = customer.PostCode;
            //cb_Rate.Text = customer.DiscountRate.ToString();

            if (String.Compare(customer.MutiAddress, "Y") == 0)
            {
                chk_ship.Checked = true;
            }
            else
            {
                chk_ship.Checked = false;

                m_address.Text = customer.ShipInfo.ShippingStreet;
                m_city.Text = customer.ShipInfo.ShippingCity;
                m_first.Text = customer.ShipInfo.ShippingFirstName;
                m_last.Text = customer.ShipInfo.ShippingLastName;
                m_postcode.Text = customer.ShipInfo.ShipppingPost;
                m_state.Text = customer.ShipInfo.ShippingState;
                m_Phone.Text = customer.ShipInfo.ShippingPhone.ToString();
            }
        }
        private void SetOrderInformation(Order aOrder)
        {
          //  o_date.Text = aOrder.OrderDate;
            o_emp.Text = aOrder.EmployeeId.ToString();
            o_number.Text = aOrder.OrderId.ToString();
            o_status.Text = aOrder.Status.ToString();
            txt_Rate.Text = aOrder.Discount.ToString();
        }

        private void InitializeAllData()
        {
            listOrder = OrderLAO.GetAllOrders();
            dataGridView1.DataSource = listOrder;
        }
        /// <summary>
        /// add order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentStatus = FormStatus.adding;
            CleanAllComponets();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            if (currentStatus == FormStatus.adding)
            {
                //OrderLAO.CreateNewOrder(
            }
        }

        /// <summary>
        /// Save an order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Cancle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //get customer by customer first name
        private void but_GetCustomer_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectIndex = dataGridView1.CurrentRow.Index;
            Order aOrder = new Order();
            aOrder = listOrder[selectIndex];
            SetOrderInformation(aOrder);
            Customer cusotmerInformation = new Customer();
            cusotmerInformation = CustomerLAO.getCustoemerById(aOrder.customerId);
            SetCustomerInformation(cusotmerInformation);
            orderLine = new List<OrderLines>();
            orderLine = OrderLAO.GetLinesByOrderId(aOrder.OrderId);
            SetAllProductInformation();
        }

        /// <summary>
        /// print a report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
