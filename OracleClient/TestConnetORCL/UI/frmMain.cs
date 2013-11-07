using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtreme
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
        }

        private void btn_Product_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.ShowDialog();
        }

        private void btn_Order_Click(object sender, EventArgs e)
        {
            frmOrderLine frm = new frmOrderLine();
            frm.ShowDialog();
        }

        private void productPriceAdjustToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmPrice frm = new frmPrice();
            frm.ShowDialog();
        }

        private void CourseQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerQuery frm = new frmCustomerQuery();
            frm.ShowDialog();
        }

        private void GradeQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderQuery frm = new frmOrderQuery();
            frm.ShowDialog();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            frmOrderQuery frm = new frmOrderQuery();
            frm.ShowDialog();
        }

        private void CourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
        }

        private void StudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.ShowDialog();
        }

        private void OrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderLine frm = new frmOrderLine();
            frm.ShowDialog();
        }

        private void ProductQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductQuery frm = new frmProductQuery();
            frm.ShowDialog();
        }

        private void outstandingOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
