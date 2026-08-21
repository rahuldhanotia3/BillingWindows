using Newtonsoft.Json;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static QuestPDF.Helpers.Colors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ProductCRMAPI
{
    public partial class BillingUsers : Form
    {
        decimal SubTotal = 0;
        decimal TotalDiscount = 0;
        decimal TotalSGST = 0;
        decimal TotalCGST = 0;
        decimal Total = 0;
        decimal Received = 0;
        decimal Balance = 0;
        decimal Saved = 0;
        string excelFile = Path.Combine(Application.StartupPath, "Uploads", "Invoice.xlsx");
        Dictionary<string, string> productList = new Dictionary<string, string>();
        public BillingUsers()
        {
            InitializeComponent();
            this.Load += BillingUsers_Load;
        }
        private void BillingUsers_Load(object sender, EventArgs e)
        {
            //this.Close();
            //InitializeInvoiceGrid();
            txtInvoiceDate.Format = DateTimePickerFormat.Custom;
            txtInvoiceDate.CustomFormat = "dd/MM/yyyy";

            InitializeInvoiceGrid();
            LoadUsers();
            listBoxBillingSearch.MouseClick += listBoxBilling_Click;
        }
        private void InitializeInvoiceGrid()
        {
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add("txtSNO", "SNO");
            dgvUsers.Columns.Add("txtInvoiceNo", "InvoiceNo");
            dgvUsers.Columns.Add("txtBillTo", "BillTo");
            dgvUsers.Columns.Add("txtContactNo", "Contact");
            dgvUsers.Columns.Add("txtGSTINNumber", "GSTIN");
            dgvUsers.Columns.Add("txtState", "State");
            dgvUsers.Columns.Add("txtPOS", "Place Of Supply");

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadUsers()
        {
            dgvUsers.Rows.Clear();

            if (!File.Exists(excelFile))
                return;

            ExcelPackage.License.SetNonCommercialPersonal("Rahul");
            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];

                int rowCount = sheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    dgvUsers.Rows.Add(
                        sheet.Cells[row, 1].Text,
                        sheet.Cells[row, 2].Text,
                        sheet.Cells[row, 3].Text,
                        sheet.Cells[row, 4].Text,
                        sheet.Cells[row, 5].Text,
                        sheet.Cells[row, 6].Text,
                        sheet.Cells[row, 7].Text
                    );
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYouSaved_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCGST25_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSGST9_TextChanged(object sender, EventArgs e)
        {

        }

        private void BillingUsers_Load_1(object sender, EventArgs e)
        {

        }

        private void lblMainHeader_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        
        
        private void FetchBillingDetails(string itemName)
        {
            DateTime invoiceDate;
            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];

                int rows = sheet.Dimension.Rows;
                int lastMatchedRow = -1;
                for (int i = rows; i >= 2; i--)
                {
                    string BillTo = sheet.Cells[i, 3].Text.Trim();
                    if (itemName.Equals(BillTo, StringComparison.OrdinalIgnoreCase))
                    {
                        lastMatchedRow = i;
                        break;
                    }
                }
                if (lastMatchedRow > 0)
                {
                    txtInvoiceNo.Enabled = true;
                    txtSNO.Text = sheet.Cells[lastMatchedRow, 1].Text;
                    txtInvoiceNo.Text = sheet.Cells[lastMatchedRow, 2].Text;
                    txtBillTo.Text = sheet.Cells[lastMatchedRow, 3].Text;
                    txtContactNo.Text = sheet.Cells[lastMatchedRow, 4].Text;
                    txtGSTINNumber.Text = sheet.Cells[lastMatchedRow, 5].Text;
                    txtState.Text = sheet.Cells[lastMatchedRow, 6].Text;
                    txtPOS.Text = sheet.Cells[lastMatchedRow, 7].Text;
                    if (DateTime.TryParseExact(sheet.Cells[lastMatchedRow, 8].Text.Trim(),"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out invoiceDate))
                    {
                        txtInvoiceDate.Value = invoiceDate;
                    }
                }
            }
        }
        private void txtBillTo_KeyUp(object sender, KeyEventArgs e)
        {
            listBoxBillingSearch.Items.Clear();

            string searchText = txtBillTo.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                listBoxBillingSearch.Visible = false;
                return;
            }

            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            HashSet<string> uniqueItems = new HashSet<string>();
            DateTime invoiceDate;
            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];
                int rows = sheet.Dimension.Rows;
                int lastMatchedRow = -1;
                for (int i = 2; i <= rows; i++)
                {
                    string itemName = sheet.Cells[i, 3].Text.Trim();

                    if (itemName.ToLower().Contains(searchText))
                    {
                        if (uniqueItems.Add(itemName))
                        {
                            listBoxBillingSearch.Items.Add(itemName);
                        }
                    }
                    if (itemName.Equals(searchText, StringComparison.OrdinalIgnoreCase))
                    {
                        lastMatchedRow = i;
                    }
                }
                if (lastMatchedRow > 0)
                {
                    txtInvoiceNo.Enabled = true;
                    txtBillTo.Text = sheet.Cells[lastMatchedRow, 3].Text;
                    txtContactNo.Text = sheet.Cells[lastMatchedRow, 4].Text;
                    txtGSTINNumber.Text = sheet.Cells[lastMatchedRow, 5].Text;
                    txtState.Text = sheet.Cells[lastMatchedRow, 6].Text;
                    txtInvoiceNo.Text = sheet.Cells[lastMatchedRow, 2].Text;
                    txtPOS.Text = sheet.Cells[lastMatchedRow, 7].Text;

                    if (DateTime.TryParseExact(sheet.Cells[lastMatchedRow, 8].Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out invoiceDate))
                    {
                        txtInvoiceDate.Value = invoiceDate;
                    }
                }
            }

            listBoxBillingSearch.Visible = listBoxBillingSearch.Items.Count > 0;
        }
        private void listBoxBilling_Click(object sender, EventArgs e)
        {
            if (listBoxBillingSearch.SelectedItem != null)
            {
                txtBillTo.Text = listBoxBillingSearch.SelectedItem.ToString();

                FetchBillingDetails(txtBillTo.Text.ToUpper());

                listBoxBillingSearch.Visible = false;
            }
        }
        private void listBoxBilling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBoxBillingSearch.SelectedItem != null)
                {
                    txtBillTo.Text = listBoxBillingSearch.SelectedItem.ToString();

                    FetchBillingDetails(txtBillTo.Text);

                    listBoxBillingSearch.Visible = false;
                }
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBillTo.Clear();
            txtContactNo.Clear();
            txtGSTINNumber.Clear();
            txtPOS.Clear();
            txtState.Clear();
            txtInvoiceNo.Clear();
        }

        private void UpdateItem()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];

                int rows = sheet.Dimension.Rows;
                foreach (var product in productList)
                {
                    string productName = product.Key;
                    string qty = product.Value;

                    for (int i = 2; i <= rows; i++)
                    {
                        if (sheet.Cells[i, 2].Text.ToLower() == productName.ToLower())
                        {
                            int temp = Convert.ToInt32(sheet.Cells[i, 5].Value.ToString());
                            sheet.Cells[i, 5].Value = temp - Convert.ToInt32(qty);
                        }
                    }
                }

                package.Save();
                productList.Clear();
                return;
            }
        }
    }
}
