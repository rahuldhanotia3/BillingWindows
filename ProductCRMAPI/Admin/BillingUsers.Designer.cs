using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Windows.Forms;

namespace ProductCRMAPI
{
    partial class BillingUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.textBoxArray1 = new Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(this.components);
            this.txtGSTINNumber = new System.Windows.Forms.TextBox();
            this.txtPOS = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtBillTo = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblMainHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.txtSNO = new System.Windows.Forms.TextBox();
            this.listBoxBillingSearch = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxArray1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(14, 300);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 62;
            this.dgvUsers.RowTemplate.Height = 28;
            this.dgvUsers.Size = new System.Drawing.Size(1759, 193);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            // 
            // txtGSTINNumber
            // 
            this.txtGSTINNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGSTINNumber.BackColor = System.Drawing.Color.White;
            this.txtGSTINNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGSTINNumber.ForeColor = System.Drawing.Color.Black;
            this.txtGSTINNumber.Location = new System.Drawing.Point(14, 167);
            this.txtGSTINNumber.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtGSTINNumber.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtGSTINNumber.MaxLength = 350;
            this.txtGSTINNumber.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtGSTINNumber.Name = "txtGSTINNumber";
            this.txtGSTINNumber.Size = new System.Drawing.Size(350, 30);
            this.txtGSTINNumber.TabIndex = 1;
            // 
            // txtPOS
            // 
            this.txtPOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPOS.BackColor = System.Drawing.Color.White;
            this.txtPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPOS.ForeColor = System.Drawing.Color.Black;
            this.txtPOS.Location = new System.Drawing.Point(14, 234);
            this.txtPOS.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPOS.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtPOS.MaxLength = 350;
            this.txtPOS.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtPOS.Name = "txtPOS";
            this.txtPOS.Size = new System.Drawing.Size(350, 30);
            this.txtPOS.TabIndex = 4;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactNo.BackColor = System.Drawing.Color.White;
            this.txtContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.ForeColor = System.Drawing.Color.Black;
            this.txtContactNo.Location = new System.Drawing.Point(443, 99);
            this.txtContactNo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtContactNo.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtContactNo.MaxLength = 350;
            this.txtContactNo.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(350, 30);
            this.txtContactNo.TabIndex = 1;
            // 
            // txtBillTo
            // 
            this.txtBillTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBillTo.BackColor = System.Drawing.Color.White;
            this.txtBillTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillTo.ForeColor = System.Drawing.Color.Black;
            this.txtBillTo.Location = new System.Drawing.Point(14, 99);
            this.txtBillTo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBillTo.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtBillTo.MaxLength = 350;
            this.txtBillTo.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtBillTo.Name = "txtBillTo";
            this.txtBillTo.Size = new System.Drawing.Size(350, 30);
            this.txtBillTo.TabIndex = 1;
            this.txtBillTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBillTo_KeyUp);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceNo.BackColor = System.Drawing.Color.White;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.ForeColor = System.Drawing.Color.Black;
            this.txtInvoiceNo.Location = new System.Drawing.Point(443, 169);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtInvoiceNo.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtInvoiceNo.MaxLength = 350;
            this.txtInvoiceNo.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(350, 30);
            this.txtInvoiceNo.TabIndex = 8;
            // 
            // txtState
            // 
            this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtState.BackColor = System.Drawing.Color.White;
            this.txtState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.ForeColor = System.Drawing.Color.Black;
            this.txtState.Location = new System.Drawing.Point(879, 99);
            this.txtState.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtState.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtState.MaxLength = 350;
            this.txtState.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(350, 30);
            this.txtState.TabIndex = 1;
            // 
            // lblMainHeader
            // 
            this.lblMainHeader.AutoSize = true;
            this.lblMainHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainHeader.ForeColor = System.Drawing.Color.Black;
            this.lblMainHeader.Location = new System.Drawing.Point(604, 9);
            this.lblMainHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMainHeader.Name = "lblMainHeader";
            this.lblMainHeader.Size = new System.Drawing.Size(162, 29);
            this.lblMainHeader.TabIndex = 10;
            this.lblMainHeader.Text = "Billing Users";
            this.lblMainHeader.Click += new System.EventHandler(this.lblMainHeader_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Bill To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(444, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Contact No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(875, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "State";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "GSTIN Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(444, 145);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Invoice No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(875, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Invoice Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(15, 210);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Place Of Supply";
            // 
            // txtInvoiceDate
            // 
            this.txtInvoiceDate.BackColor = System.Drawing.Color.White;
            this.txtInvoiceDate.CustomFormat = "dd/MM/yyyy";
            this.txtInvoiceDate.ForeColor = System.Drawing.Color.Black;
            this.txtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtInvoiceDate.Location = new System.Drawing.Point(879, 169);
            this.txtInvoiceDate.MaximumSize = new System.Drawing.Size(350, 30);
            this.txtInvoiceDate.MinimumSize = new System.Drawing.Size(350, 30);
            this.txtInvoiceDate.Name = "txtInvoiceDate";
            this.txtInvoiceDate.Size = new System.Drawing.Size(350, 30);
            this.txtInvoiceDate.TabIndex = 39;
            // 
            // txtSNO
            // 
            this.txtSNO.Location = new System.Drawing.Point(1231, 362);
            this.txtSNO.Name = "txtSNO";
            this.txtSNO.Size = new System.Drawing.Size(0, 35);
            this.txtSNO.TabIndex = 41;
            this.txtSNO.Visible = false;
            // 
            // listBoxBillingSearch
            // 
            this.listBoxBillingSearch.FormattingEnabled = true;
            this.listBoxBillingSearch.ItemHeight = 29;
            this.listBoxBillingSearch.Location = new System.Drawing.Point(14, 136);
            this.listBoxBillingSearch.Name = "listBoxBillingSearch";
            this.listBoxBillingSearch.Size = new System.Drawing.Size(345, 120);
            this.listBoxBillingSearch.TabIndex = 43;
            this.listBoxBillingSearch.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(609, 500);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 35);
            this.button4.TabIndex = 44;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BillingUsers
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1787, 1044);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listBoxBillingSearch);
            this.Controls.Add(this.txtSNO);
            this.Controls.Add(this.txtInvoiceDate);
            this.Controls.Add(this.txtBillTo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMainHeader);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.txtPOS);
            this.Controls.Add(this.txtGSTINNumber);
            this.Controls.Add(this.dgvUsers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BillingUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billing System";
            this.Load += new System.EventHandler(this.BillingUsers_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxArray1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray textBoxArray1;
        private System.Windows.Forms.TextBox txtGSTINNumber;
        private System.Windows.Forms.TextBox txtPOS;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.TextBox txtBillTo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        public System.Windows.Forms.TextBox txtState;
        public System.Windows.Forms.Label lblMainHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker txtInvoiceDate;
        private TextBox txtSNO;
        private ListBox listBoxBillingSearch;
        private Button button4;
    }
}

