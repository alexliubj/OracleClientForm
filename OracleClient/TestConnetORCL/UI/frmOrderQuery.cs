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
    public partial class frmOrderQuery : Form
    {
        private List<Order> listOrder = new List<Order>();
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
            listOrder.Clear();
            if (cbx_id.Text == string.Empty)
            {
                listOrder = OrderLAO.GetAllOrders();
            }
            else {
                Order o = new Order();
                listOrder.Add(OrderLAO.GetOrderById(Int32.Parse(cbx_id.Text)));
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listOrder;
        }

        private void butGPA_Click(object sender, EventArgs e)
        {

        }
    }
}
