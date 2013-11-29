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
    public partial class frmPrice : Form
    {
        public frmPrice()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Input the right price", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ProductsLAO.UpdateAllPrice(float.Parse(textBox1.Text));
                MessageBox.Show("Saved", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
