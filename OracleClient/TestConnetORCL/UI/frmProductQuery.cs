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
    public partial class frmProductQuery : Form
    {
        List<Product> prod = new List<Product>();
        public frmProductQuery()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            prod.Clear();
            if (comboBox1.Text == string.Empty || textBox1.Text == string.Empty)
            {
                prod = ProductsLAO.GetAllProducts();
               
            }
            else {

                if (comboBox1.Text.ToLower() == "product id")
                {
                    Product p = new Product();
                    p =  ProductsLAO.getProductById(Int32.Parse(textBox1.Text));
                    prod.Add(p);
                }
                else // product name 
                {
                    Product p = new Product();
                    p = ProductsLAO.getProductByName(textBox1.Text);
                    prod.Add(p);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = prod;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet1.ProductDataTable dt = new DataSet1.ProductDataTable();
            dt = (DataSet1.ProductDataTable)SetProductInfo(prod);
            ProductForm rf = new ProductForm(dt);
            rf.Show();
        }

        public static DataTable SetProductInfo(List<Product> list)
        {
            DataSet1.ProductDataTable dt = new DataSet1.ProductDataTable();
            try
            {
                foreach (var cust in list)
                {
                    DataRow newRow = dt.NewRow();
                    foreach (PropertyInfo property in cust.GetType().GetProperties())
                    {
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
