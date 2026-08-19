using System.Drawing;

namespace ProductCRMAPI
{
    partial class Inventory
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxArray1 = new Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(this.components);
            this.txtunit = new System.Windows.Forms.TextBox();
            this.txtSPrice = new System.Windows.Forms.TextBox();
            this.txtHsn = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtPPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblMainHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddUpdate = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.textGst = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSNO = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxArray1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInventory
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.dgvInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.HSN,
            this.Unit,
            this.Qty,
            this.PurchasePrice,
            this.SalePrice,
            this.GST});
            this.dgvInventory.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvInventory.Location = new System.Drawing.Point(14, 296);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowHeadersWidth = 200;
            this.dgvInventory.RowTemplate.Height = 20;
            this.dgvInventory.Size = new System.Drawing.Size(1759, 242);
            this.dgvInventory.TabIndex = 0;
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.btnAddUpdate_Click);
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.MinimumWidth = 8;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // HSN
            // 
            this.HSN.HeaderText = "HSN";
            this.HSN.MinimumWidth = 8;
            this.HSN.Name = "HSN";
            this.HSN.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.MinimumWidth = 8;
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.MinimumWidth = 8;
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.HeaderText = "Purchase Price";
            this.PurchasePrice.MinimumWidth = 8;
            this.PurchasePrice.Name = "PurchasePrice";
            this.PurchasePrice.ReadOnly = true;
            // 
            // SalePrice
            // 
            this.SalePrice.HeaderText = "Sale Price";
            this.SalePrice.MinimumWidth = 8;
            this.SalePrice.Name = "SalePrice";
            this.SalePrice.ReadOnly = true;
            // 
            // GST
            // 
            this.GST.HeaderText = "GST";
            this.GST.MinimumWidth = 8;
            this.GST.Name = "GST";
            this.GST.ReadOnly = true;
            // 
            // txtunit
            // 
            this.txtunit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtunit.BackColor = System.Drawing.Color.White;
            this.txtunit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtunit.ForeColor = System.Drawing.Color.Black;
            this.txtunit.Location = new System.Drawing.Point(14, 167);
            this.txtunit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtunit.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtunit.MaxLength = 350;
            this.txtunit.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtunit.Name = "txtunit";
            this.txtunit.Size = new System.Drawing.Size(350, 30);
            this.txtunit.TabIndex = 1;
            // 
            // txtSPrice
            // 
            this.txtSPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSPrice.BackColor = System.Drawing.Color.White;
            this.txtSPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSPrice.ForeColor = System.Drawing.Color.Black;
            this.txtSPrice.Location = new System.Drawing.Point(14, 234);
            this.txtSPrice.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSPrice.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtSPrice.MaxLength = 350;
            this.txtSPrice.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtSPrice.Name = "txtSPrice";
            this.txtSPrice.Size = new System.Drawing.Size(350, 30);
            this.txtSPrice.TabIndex = 4;
            // 
            // txtHsn
            // 
            this.txtHsn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHsn.BackColor = System.Drawing.Color.White;
            this.txtHsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHsn.ForeColor = System.Drawing.Color.Black;
            this.txtHsn.Location = new System.Drawing.Point(443, 99);
            this.txtHsn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHsn.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtHsn.MaxLength = 350;
            this.txtHsn.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtHsn.Name = "txtHsn";
            this.txtHsn.Size = new System.Drawing.Size(350, 30);
            this.txtHsn.TabIndex = 1;
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.ForeColor = System.Drawing.Color.Black;
            this.txtItemName.Location = new System.Drawing.Point(14, 99);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtItemName.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtItemName.MaxLength = 350;
            this.txtItemName.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(350, 30);
            this.txtItemName.TabIndex = 1;
            // 
            // txtPPrice
            // 
            this.txtPPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPPrice.BackColor = System.Drawing.Color.White;
            this.txtPPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPPrice.ForeColor = System.Drawing.Color.Black;
            this.txtPPrice.Location = new System.Drawing.Point(443, 169);
            this.txtPPrice.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPPrice.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtPPrice.MaxLength = 350;
            this.txtPPrice.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtPPrice.Name = "txtPPrice";
            this.txtPPrice.Size = new System.Drawing.Size(350, 30);
            this.txtPPrice.TabIndex = 8;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.BackColor = System.Drawing.Color.White;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.Black;
            this.txtQuantity.Location = new System.Drawing.Point(879, 99);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtQuantity.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtQuantity.MaxLength = 350;
            this.txtQuantity.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(350, 30);
            this.txtQuantity.TabIndex = 1;
            // 
            // lblMainHeader
            // 
            this.lblMainHeader.AutoSize = true;
            this.lblMainHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainHeader.ForeColor = System.Drawing.Color.Black;
            this.lblMainHeader.Location = new System.Drawing.Point(604, 9);
            this.lblMainHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMainHeader.Name = "lblMainHeader";
            this.lblMainHeader.Size = new System.Drawing.Size(163, 29);
            this.lblMainHeader.TabIndex = 10;
            this.lblMainHeader.Text = "INVENTORY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Item Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(444, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "HSN Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(875, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Unit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(444, 145);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Purchase Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(875, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(15, 210);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Sale Price";
            // 
            // btnAddUpdate
            // 
            this.btnAddUpdate.Location = new System.Drawing.Point(436, 573);
            this.btnAddUpdate.Name = "btnAddUpdate";
            this.btnAddUpdate.Size = new System.Drawing.Size(158, 35);
            this.btnAddUpdate.TabIndex = 38;
            this.btnAddUpdate.Text = "Add";
            this.btnAddUpdate.UseVisualStyleBackColor = true;
            this.btnAddUpdate.Click += new System.EventHandler(this.btnAddUpdate_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1671, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 38);
            this.button3.TabIndex = 40;
            this.button3.Text = "Admin";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(875, 145);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 20);
            this.label17.TabIndex = 41;
            this.label17.Text = "GST %";
            // 
            // textGst
            // 
            this.textGst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textGst.BackColor = System.Drawing.Color.White;
            this.textGst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGst.ForeColor = System.Drawing.Color.Black;
            this.textGst.Location = new System.Drawing.Point(879, 169);
            this.textGst.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textGst.MaximumSize = new System.Drawing.Size(350, 30);
            this.textGst.MaxLength = 350;
            this.textGst.MinimumSize = new System.Drawing.Size(350, 30);
            this.textGst.Name = "textGst";
            this.textGst.Size = new System.Drawing.Size(350, 30);
            this.textGst.TabIndex = 42;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(609, 573);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(158, 35);
            this.btnSearch.TabIndex = 43;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(782, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 35);
            this.button1.TabIndex = 44;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtSNO
            // 
            this.txtSNO.Location = new System.Drawing.Point(957, 573);
            this.txtSNO.Name = "txtSNO";
            this.txtSNO.Size = new System.Drawing.Size(100, 35);
            this.txtSNO.TabIndex = 45;
            this.txtSNO.Visible = false;
            // 
            // Inventory
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1787, 1044);
            this.Controls.Add(this.txtSNO);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textGst);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAddUpdate);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMainHeader);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtPPrice);
            this.Controls.Add(this.txtHsn);
            this.Controls.Add(this.txtSPrice);
            this.Controls.Add(this.txtunit);
            this.Controls.Add(this.dgvInventory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billing System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxArray1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventory;
        private Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray textBoxArray1;
        private System.Windows.Forms.TextBox txtunit;
        private System.Windows.Forms.TextBox txtSPrice;
        private System.Windows.Forms.TextBox txtHsn;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtPPrice;
        public System.Windows.Forms.TextBox txtQuantity;
        public System.Windows.Forms.Label lblMainHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddUpdate;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textGst;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn GST;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSNO;
    }
}

