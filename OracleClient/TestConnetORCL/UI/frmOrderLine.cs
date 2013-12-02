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
        private List<Customer> listcostomer = new List<Customer>();
        private List<Product> listProduct = new List<Product>();
        private List<ShowProdut> showProdut = new List<ShowProdut>();
        private int selectIndexOfProduct = 0;
        private BindingSource bindingSource = new BindingSource();
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

        private void UpdateBottomInformationEdit()
        {
            float grantPrcie = 0.0f;
            float totalPrice = 0.0f;
            if (currentStatus == FormStatus.adding)
            {
                foreach (ShowProdut ol in showProdut)
                {
                    grantPrcie += ol.UnitPrice;
                }
            }
            if (currentStatus == FormStatus.editing || currentStatus == FormStatus.nonstatus)
            {
                foreach (OrderLines ol in orderLine)
                {
                    grantPrcie += ol.UnitPrice;
                }
            }
            totalPrice = grantPrcie * ((txt_Rate.Text == string.Empty) ? 1 : float.Parse(txt_Rate.Text)) * 1.13f;
            txt_hst.Text = "13%";
            txt_GrandTotal.Text = grantPrcie.ToString();
            txt_Total.Text = totalPrice.ToString();
        }


        private void UpdateBottomInformation()
        {
            float grantPrcie = 0.0f;
            float totalPrice = 0.0f;
            if (currentStatus == FormStatus.adding)
            {
                foreach (ShowProdut ol in showProdut)
                {
                    grantPrcie += ol.UnitPrice;
                }
            }
            if (currentStatus == FormStatus.editing || currentStatus == FormStatus.nonstatus)
            {
                foreach (OrderLines ol in orderLine)
                {
                    grantPrcie += ol.UnitPrice;
                }
            }
            totalPrice = grantPrcie * ((txt_Rate.Text == string.Empty || txt_Rate.Text == "0") ? 1 : float.Parse(txt_Rate.Text)) * 1.13f;
            txt_hst.Text = "13%";
            txt_GrandTotal.Text = grantPrcie.ToString();
            txt_Total.Text = totalPrice.ToString();
        }
        private void ComboBox1_SelectedIndexChanged(object sender,
            System.EventArgs e)
        {
            if (currentStatus != FormStatus.adding)
            {
                ComboBox comboBox = (ComboBox)sender;
                string selectedEmployee = (string)comb_prod.SelectedItem;
                int selectIndex = comb_prod.SelectedIndex;
                this.prod_qnt.Text = orderLine[selectIndex].Quantity.ToString();
            }
            else
            {
 
            }
        }
        private void SetAllProductInformation()
        {
            OrderLines[] arr = orderLine.ToArray();
            if (arr.Length > 0)
            {
                string[] productNameString = new string[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    productNameString[i] = ((OrderLines)arr[i]).ProductInfo.ProductName;
                }
                this.comb_prod.Items.Clear();
                this.comb_prod.Items.AddRange(productNameString);
                this.comb_prod.SelectedIndex = 0;
                this.prod_qnt.Text = ((OrderLines)arr[0]).Quantity.ToString();
            }
            
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
            o_date.Value = aOrder.OrderDate;
           // o_date_shp.Value = aOrder.ShipDate;
            if(aOrder.Status <=2)
            this.o_status.SelectedIndex = aOrder.Status;
        }

        private void InitializeAllData()
        {
            listOrder = OrderLAO.GetAllOrders();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listOrder;
            but_GetCustomer.Enabled = false;
            cb_cusId.Visible = false;
            cb_cusId.Enabled = false;
            btn_add.Enabled = false;
            btn_delete.Enabled = false;
            e_custName.Enabled = false;
            e_custName.ReadOnly = true;
            o_number.Enabled = false;
            listProduct = ProductsLAO.GetAllProducts();
        }
        /// <summary>
        /// add order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            showProdut.Clear();
            currentStatus = FormStatus.adding;
            CleanAllComponets();
            but_GetCustomer.Enabled = true;
            cb_cusId.Enabled = true;
            cb_cusId.Visible = true;
            btn_add.Enabled = true;
            btn_delete.Enabled = true;
            e_custName.Enabled = true;
            comb_prod.Items.Clear();
            comb_prod.Text = string.Empty;
            e_custName.Enabled = true;
            e_custName.ReadOnly = false;
            extenstions.ClearControls(Controls);
            o_number.Enabled = false;
            o_number.Text = OrderLAO.getOrderNextValue().ToString();
            if (listProduct.Count > 0)
            {
                this.comb_prod.Items.Clear();
                string[] productNameString = new string[listProduct.Count];
                for (int i = 0; i < listProduct.Count; i++)
                {
                    productNameString[i] = listProduct[i].ProductName;
                }
                
                this.comb_prod.Items.AddRange(productNameString);

                this.comb_prod.SelectedIndex = 0;
            }
            listcostomer = CustomerLAO.GetAllCustomers();
            if (listcostomer.Count > 0)
            {
                string[] customerIdlist = new string[listcostomer.Count];
                for (int i = 0; i < listcostomer.Count; i++)
                {
                    customerIdlist[i] = ((Customer)(listcostomer[i])).CustomerId.ToString();
                }

                this.cb_cusId.Items.AddRange(customerIdlist);
                this.cb_cusId.SelectedIndex = 0;
                Customer aCusotomer = new Customer();
                aCusotomer = listcostomer[0];
                SetCustomerInformation(aCusotomer);
            }
            setAddressEnable(true);
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
            if (prod_qnt.Text == string.Empty)
            {
                MessageBox.Show("Empty quantity", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (o_emp.Text == string.Empty)
            {
                MessageBox.Show("Empty Employee id", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (currentStatus == FormStatus.adding)
                {
                    currentStatus = FormStatus.nonstatus;
                    cb_cusId.Enabled = false;
                    cb_cusId.Visible = false;
                    btn_add.Enabled = false;
                    btn_delete.Enabled = false;
                    e_custName.Enabled = false;
                    e_custName.ReadOnly = true;
                    o_number.Enabled = false;
                    OrderLAO.CreateNewOrder(GenerateOrder(), GenerateOrderLine());
                    e_custName.Text = string.Empty;
                    e_cust.Text = string.Empty;
                    cb_cusId.Text = string.Empty;
                    setAddressEnable(false);
                    listOrder = OrderLAO.GetAllOrders();
                }
                if (currentStatus == FormStatus.editing)
                {
                    OrderLAO.UpdateOrderStatus(o_status.SelectedIndex, Int32.Parse(o_number.Text));
                    listOrder = OrderLAO.GetAllOrders();
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listOrder;
                listcostomer.Clear();
            }
        }


        private Order GenerateOrder()
        {
            Order retOrder = new Order();
            retOrder.customerId = Int32.Parse(e_cust.Text);
            retOrder.Discount = float.Parse((txt_Rate.Text == string.Empty) ? "0" : txt_Rate.Text);
            retOrder.EmployeeId = Int32.Parse(o_emp.Text==string.Empty ? "0" : o_emp.Text);
            retOrder.OrderDate = DateTime.Now;
            retOrder.OrderDate = o_date.Value.Date;
            retOrder.ShipDate = o_date_shp.Value.Date;
            retOrder.OrderId = Int32.Parse(o_number.Text);
            if (o_status.Text == string.Empty)
            {
                retOrder.Status = 0;
            }
            else
            {
                retOrder.Status = o_status.SelectedIndex;
            }
            return retOrder;
        }

        private List<OrderLines> GenerateOrderLine()
        {
            List<OrderLines> listOrderLine = new List<OrderLines>();

            foreach (ShowProdut sp in showProdut)
            {
                OrderLines ol = new OrderLines();
                ol.Quantity = sp.Quantiy;
                ol.UnitPrice = sp.UnitPrice;
                ol.ProductId = sp.ProductId;
                ol.OrderId = Int32.Parse(o_number.Text);
                listOrderLine.Add(ol);
            }
            return listOrderLine;
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
            if (e_custName.Text == string.Empty)
            {
                listcostomer = CustomerLAO.GetAllCustomers();
            }
            else
                listcostomer = CustomerLAO.GetCustomerByName(e_custName.Text);

            cb_cusId.Items.Clear();
            cb_cusId.Enabled = true;
            cb_cusId.Visible = true;

            if (listcostomer.Count > 0)
            {
                string[] customerIdlist = new string[listcostomer.Count];
                for (int i = 0; i < listcostomer.Count; i++)
                {
                    customerIdlist[i] = ((Customer)(listcostomer[i])).CustomerId.ToString();
                }

                this.cb_cusId.Items.AddRange(customerIdlist);
                this.cb_cusId.SelectedIndex = 0;

                Customer aCusotomer = new Customer();
                aCusotomer = listcostomer[0];
                SetCustomerInformation(aCusotomer);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentStatus == FormStatus.editing || currentStatus == FormStatus.nonstatus)
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
                currentStatus = FormStatus.editing;
                UpdateBottomInformation();

            }
            if (currentStatus == FormStatus.adding)
            {
                selectIndexOfProduct = dataGridView1.CurrentRow.Index;
            }
        }

        /// <summary>
        /// print a report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butPrint_Click(object sender, EventArgs e)
        {

        }

        private void cb_cusId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer aCusotomer = new Customer();
            aCusotomer = listcostomer[cb_cusId.SelectedIndex];
            SetCustomerInformation(aCusotomer);
        }

        private void o_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comb_prod_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndexOfProduct = comb_prod.SelectedIndex;
        }

        private void setAddressEnable(bool status)
        {
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control a in c.Controls)
                    {
                        if ((a is GroupBox) && a.HasChildren)
                        {
                            foreach (Control b in a.Controls)
                            {
                                if (b is TextBox)
                                {
                                    b.Text = string.Empty;
                                   // b.Enabled = status;
                                   // ((TextBox)b).ReadOnly = !status;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// add a product for the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {

            if (prod_qnt.Text == string.Empty)
            {
                MessageBox.Show("Empty quantity", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Int32.Parse(prod_qnt.Text) > 0)
                {
                    bool inList = false;
                    foreach (ShowProdut sp in showProdut)
                    {
                        if (listProduct[selectIndexOfProduct].ProductId == sp.ProductId)
                            inList = true;
                    }

                    if (!inList)
                    {
                        showProdut.Add(new ShowProdut()
                        {
                            Name = listProduct[selectIndexOfProduct].ProductName,
                            ProductId = listProduct[selectIndexOfProduct].ProductId,
                            Quantiy = Int32.Parse(prod_qnt.Text),
                            UnitPrice = listProduct[selectIndexOfProduct].UnitPrice
                        });
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = showProdut;
                UpdateBottomInformation();
            }
        }

        /// <summary>
        /// delete a product from list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            showProdut.RemoveAt(dataGridView1.CurrentRow.Index);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = showProdut;
            UpdateBottomInformation();
        }
    }
    public static class extenstions
    {
        private static Dictionary<Type, Action<Control>> controldefaults = new Dictionary<Type, Action<Control>>() { 
            {typeof(TextBox), c => ((TextBox)c).Clear()},
            {typeof(CheckBox), c => ((CheckBox)c).Checked = false},
            {typeof(ListBox), c => ((ListBox)c).Items.Clear()},
            {typeof(RadioButton), c => ((RadioButton)c).Checked = false},
            {typeof(GroupBox), c => ((GroupBox)c).Controls.ClearControls()},
            {typeof(Panel), c => ((Panel)c).Controls.ClearControls()},
            {typeof(DataGridView), c => ((DataGridView)c).DataSource= null}
    };

        private static void FindAndInvoke(Type type, Control control)
        {
            if (controldefaults.ContainsKey(type))
            {
                controldefaults[type].Invoke(control);
            }
        }

        public static void ClearControls(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                FindAndInvoke(control.GetType(), control);
            }
        }

        public static void ClearControls<T>(this Control.ControlCollection controls) where T : class
        {
            if (!controldefaults.ContainsKey(typeof(T))) return;

            foreach (Control control in controls)
            {
                if (control.GetType().Equals(typeof(T)))
                {
                    FindAndInvoke(typeof(T), control);
                }
            }

        }

    }

    class ShowProdut
    {
        public int ProductId { get; set;}
        public string Name { get; set; }
        public int Quantiy { get; set; }
        public float UnitPrice { get; set; }
    }
        
}
