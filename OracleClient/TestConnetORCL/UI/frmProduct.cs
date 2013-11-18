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
    public partial class frmProduct : Form
    {
        private List<Product> listProducts = new List<Product>();
        private FormStatus currentStatus;
        private int currentSelectedIndex = 0;
        private enum FormStatus
        {
            nonstatus = 0,
            adding = 1,
            editing = 2,
            deleting = 3,
            updating = 4,
        };
        public frmProduct()
        {
            InitializeComponent();
            InitializeAllData();
        }

        /// <summary>
        /// init all data
        /// </summary>
        private void InitializeAllData()
        {
            listProducts = ProductsLAO.GetAllProducts();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listProducts;
            currentStatus = FormStatus.nonstatus;
        }

        private void RemoveOneProduct(Product p)
        { }

        private void UpdateOneProdut(Product p)
        { }

        private void InsertNewProduct(Product p)
        { }

        /// <summary>
        /// add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentStatus = FormStatus.adding;
            extenstions.ClearControls(Controls);
            dataGridView1.DataSource = listProducts;

        }

        /// <summary>
        /// delete button onclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product temProduct = new Product();
            temProduct = listProducts[currentSelectedIndex];
            ProductsLAO.RemoveProductById(temProduct.ProductId);
            listProducts.RemoveAt(currentSelectedIndex);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listProducts;
        }
        /// <summary>
        /// save button onclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentStatus == FormStatus.editing)
            {
                Product p = new Product();
                p.Instruction = txt_descrip.Text;
                p.ProductId = Int32.Parse(txt_id.Text);
                p.ProductName = txt_Name.Text;
                p.UnitPrice = float.Parse(txt_Price.Text);
                p.UnitType = txt_Unit.Text.ToString();
                ProductsLAO.UpdateProduct(p);
            }
            if (currentStatus == FormStatus.adding)
            {
                Product p = new Product();
                p.Instruction = txt_descrip.Text;
                p.ProductId = Int32.Parse(txt_id.Text);
                p.ProductName = txt_Name.Text;
                p.UnitPrice = float.Parse(txt_Price.Text);
                p.UnitType = txt_Unit.Text.ToString();
                ProductsLAO.AddNewProduct(p);
            }
            listProducts = ProductsLAO.GetAllProducts();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listProducts;
        }

        /// <summary>
        /// cancel button onclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// print onclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butPrint_Click(object sender, EventArgs e)
        {
        
        }

        private void CleanAllData()
        {
            extenstions.ClearControls(Controls);
        }

        private void SetDataValue(Product p)
        {
            txt_descrip.Text = p.Instruction;
            txt_id.Text = p.ProductId.ToString();
            txt_Name.Text = p.ProductName;
            txt_Price.Text = p.UnitPrice.ToString();
            txt_Unit.Text = p.UnitType.ToString();
        }

        /// <summary>
        /// select one product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentStatus == FormStatus.editing || currentStatus == FormStatus.nonstatus)
            {
                currentStatus = FormStatus.editing;
                int selectIndex = dataGridView1.CurrentRow.Index;
                currentSelectedIndex = selectIndex;
                Product p = listProducts[selectIndex];
                SetDataValue(p);
            }
        } 
    }
}
