namespace xtreme
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.CourseCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StudentSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productPriceAdjustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.orderAgingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.top10OutstandingCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outstandingOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderAgingReport3060daysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderAgingReport6190daysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Customer = new System.Windows.Forms.Button();
            this.btn_Order = new System.Windows.Forms.Button();
            this.btn_Product = new System.Windows.Forms.Button();
            this.btn_Report = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CourseCToolStripMenuItem,
            this.StudentSToolStripMenuItem,
            this.OrderLineToolStripMenuItem,
            this.toolStripMenuItem1,
            this.SystemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(770, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CourseCToolStripMenuItem
            // 
            this.CourseCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerToolStripMenuItem,
            this.CustomerQueryToolStripMenuItem});
            this.CourseCToolStripMenuItem.Name = "CourseCToolStripMenuItem";
            this.CourseCToolStripMenuItem.Size = new System.Drawing.Size(161, 20);
            this.CourseCToolStripMenuItem.Text = "Customer Management(&C)";
            // 
            // CustomerToolStripMenuItem
            // 
            this.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem";
            this.CustomerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.CustomerToolStripMenuItem.Text = "Customer Information";
            this.CustomerToolStripMenuItem.Click += new System.EventHandler(this.CourseToolStripMenuItem_Click);
            // 
            // CustomerQueryToolStripMenuItem
            // 
            this.CustomerQueryToolStripMenuItem.Name = "CustomerQueryToolStripMenuItem";
            this.CustomerQueryToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.CustomerQueryToolStripMenuItem.Text = "Customer Query";
            this.CustomerQueryToolStripMenuItem.Click += new System.EventHandler(this.CourseQueryToolStripMenuItem_Click);
            // 
            // StudentSToolStripMenuItem
            // 
            this.StudentSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProductToolStripMenuItem,
            this.ProductQueryToolStripMenuItem,
            this.productPriceAdjustToolStripMenuItem});
            this.StudentSToolStripMenuItem.Name = "StudentSToolStripMenuItem";
            this.StudentSToolStripMenuItem.Size = new System.Drawing.Size(150, 20);
            this.StudentSToolStripMenuItem.Text = "Product Management(&P)";
            // 
            // ProductToolStripMenuItem
            // 
            this.ProductToolStripMenuItem.Name = "ProductToolStripMenuItem";
            this.ProductToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ProductToolStripMenuItem.Text = "Product Information";
            this.ProductToolStripMenuItem.Click += new System.EventHandler(this.StudentToolStripMenuItem_Click);
            // 
            // ProductQueryToolStripMenuItem
            // 
            this.ProductQueryToolStripMenuItem.Name = "ProductQueryToolStripMenuItem";
            this.ProductQueryToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ProductQueryToolStripMenuItem.Text = "Product Query";
            this.ProductQueryToolStripMenuItem.Click += new System.EventHandler(this.ProductQueryToolStripMenuItem_Click);
            // 
            // productPriceAdjustToolStripMenuItem
            // 
            this.productPriceAdjustToolStripMenuItem.Name = "productPriceAdjustToolStripMenuItem";
            this.productPriceAdjustToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.productPriceAdjustToolStripMenuItem.Text = "Product Price Adjust";
            this.productPriceAdjustToolStripMenuItem.Click += new System.EventHandler(this.productPriceAdjustToolStripMenuItem_Click);
            // 
            // OrderLineToolStripMenuItem
            // 
            this.OrderLineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrderToolStripMenuItem,
            this.OrderQueryToolStripMenuItem});
            this.OrderLineToolStripMenuItem.Name = "OrderLineToolStripMenuItem";
            this.OrderLineToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.OrderLineToolStripMenuItem.Text = "Order Management(&O)";
            // 
            // OrderToolStripMenuItem
            // 
            this.OrderToolStripMenuItem.Name = "OrderToolStripMenuItem";
            this.OrderToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.OrderToolStripMenuItem.Text = "Order Information";
            this.OrderToolStripMenuItem.Click += new System.EventHandler(this.OrderToolStripMenuItem_Click);
            // 
            // OrderQueryToolStripMenuItem
            // 
            this.OrderQueryToolStripMenuItem.Name = "OrderQueryToolStripMenuItem";
            this.OrderQueryToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.OrderQueryToolStripMenuItem.Text = "Order Query";
            this.OrderQueryToolStripMenuItem.Click += new System.EventHandler(this.GradeQueryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderAgingReportToolStripMenuItem,
            this.top10OutstandingCustomerToolStripMenuItem,
            this.outstandingOrderToolStripMenuItem,
            this.orderAgingReport3060daysToolStripMenuItem,
            this.orderAgingReport6190daysToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 20);
            this.toolStripMenuItem1.Text = "Report Manager(&R)";
            // 
            // orderAgingReportToolStripMenuItem
            // 
            this.orderAgingReportToolStripMenuItem.Name = "orderAgingReportToolStripMenuItem";
            this.orderAgingReportToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.orderAgingReportToolStripMenuItem.Text = "Order Aging Report (<30days)";
            this.orderAgingReportToolStripMenuItem.Click += new System.EventHandler(this.orderAgingReportToolStripMenuItem_Click);
            // 
            // top10OutstandingCustomerToolStripMenuItem
            // 
            this.top10OutstandingCustomerToolStripMenuItem.Name = "top10OutstandingCustomerToolStripMenuItem";
            this.top10OutstandingCustomerToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.top10OutstandingCustomerToolStripMenuItem.Text = "Top 10 Outstanding Customer";
            this.top10OutstandingCustomerToolStripMenuItem.Click += new System.EventHandler(this.top10OutstandingCustomerToolStripMenuItem_Click);
            // 
            // outstandingOrderToolStripMenuItem
            // 
            this.outstandingOrderToolStripMenuItem.Name = "outstandingOrderToolStripMenuItem";
            this.outstandingOrderToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.outstandingOrderToolStripMenuItem.Text = "Outstanding Order Report";
            this.outstandingOrderToolStripMenuItem.Click += new System.EventHandler(this.outstandingOrderToolStripMenuItem_Click);
            // 
            // orderAgingReport3060daysToolStripMenuItem
            // 
            this.orderAgingReport3060daysToolStripMenuItem.Name = "orderAgingReport3060daysToolStripMenuItem";
            this.orderAgingReport3060daysToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.orderAgingReport3060daysToolStripMenuItem.Text = "Order Aging Report(30-60days)";
            this.orderAgingReport3060daysToolStripMenuItem.Click += new System.EventHandler(this.orderAgingReport3060daysToolStripMenuItem_Click);
            // 
            // orderAgingReport6190daysToolStripMenuItem
            // 
            this.orderAgingReport6190daysToolStripMenuItem.Name = "orderAgingReport6190daysToolStripMenuItem";
            this.orderAgingReport6190daysToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.orderAgingReport6190daysToolStripMenuItem.Text = "Order Aging Report(>90days)";
            this.orderAgingReport6190daysToolStripMenuItem.Click += new System.EventHandler(this.orderAgingReport6190daysToolStripMenuItem_Click);
            // 
            // SystemToolStripMenuItem
            // 
            this.SystemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserToolStripMenuItem,
            this.exitQToolStripMenuItem});
            this.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem";
            this.SystemToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.SystemToolStripMenuItem.Text = "System(&S)";
            // 
            // UserToolStripMenuItem
            // 
            this.UserToolStripMenuItem.Name = "UserToolStripMenuItem";
            this.UserToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.UserToolStripMenuItem.Text = "User Information";
            this.UserToolStripMenuItem.Click += new System.EventHandler(this.UserToolStripMenuItem_Click);
            // 
            // exitQToolStripMenuItem
            // 
            this.exitQToolStripMenuItem.Name = "exitQToolStripMenuItem";
            this.exitQToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitQToolStripMenuItem.Text = "Exit(&Q)";
            this.exitQToolStripMenuItem.Click += new System.EventHandler(this.exitQToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 365);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(770, 117);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Customer
            // 
            this.btn_Customer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Customer.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Customer.Image = ((System.Drawing.Image)(resources.GetObject("btn_Customer.Image")));
            this.btn_Customer.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Customer.Location = new System.Drawing.Point(149, 103);
            this.btn_Customer.Name = "btn_Customer";
            this.btn_Customer.Size = new System.Drawing.Size(145, 65);
            this.btn_Customer.TabIndex = 4;
            this.btn_Customer.Text = "Customer";
            this.btn_Customer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_Customer.UseVisualStyleBackColor = true;
            this.btn_Customer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Order
            // 
            this.btn_Order.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Order.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Order.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Order.Image = ((System.Drawing.Image)(resources.GetObject("btn_Order.Image")));
            this.btn_Order.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Order.Location = new System.Drawing.Point(149, 230);
            this.btn_Order.Name = "btn_Order";
            this.btn_Order.Size = new System.Drawing.Size(145, 65);
            this.btn_Order.TabIndex = 5;
            this.btn_Order.Text = "Order";
            this.btn_Order.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_Order.UseVisualStyleBackColor = true;
            this.btn_Order.Click += new System.EventHandler(this.btn_Order_Click);
            // 
            // btn_Product
            // 
            this.btn_Product.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Product.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Product.Image = ((System.Drawing.Image)(resources.GetObject("btn_Product.Image")));
            this.btn_Product.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Product.Location = new System.Drawing.Point(443, 103);
            this.btn_Product.Name = "btn_Product";
            this.btn_Product.Size = new System.Drawing.Size(145, 65);
            this.btn_Product.TabIndex = 6;
            this.btn_Product.Text = "Product";
            this.btn_Product.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_Product.UseVisualStyleBackColor = true;
            this.btn_Product.Click += new System.EventHandler(this.btn_Product_Click);
            // 
            // btn_Report
            // 
            this.btn_Report.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Report.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Report.Image = ((System.Drawing.Image)(resources.GetObject("btn_Report.Image")));
            this.btn_Report.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Report.Location = new System.Drawing.Point(443, 230);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(145, 65);
            this.btn_Report.TabIndex = 7;
            this.btn_Report.Text = "Report";
            this.btn_Report.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_Report.UseVisualStyleBackColor = true;
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(770, 476);
            this.Controls.Add(this.btn_Report);
            this.Controls.Add(this.btn_Product);
            this.Controls.Add(this.btn_Order);
            this.Controls.Add(this.btn_Customer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CourseCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomerQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StudentSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProductQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrderLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrderQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitQToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Customer;
        private System.Windows.Forms.Button btn_Order;
        private System.Windows.Forms.Button btn_Product;
        private System.Windows.Forms.Button btn_Report;
        private System.Windows.Forms.ToolStripMenuItem productPriceAdjustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem orderAgingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem top10OutstandingCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outstandingOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderAgingReport3060daysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderAgingReport6190daysToolStripMenuItem;
    }
}