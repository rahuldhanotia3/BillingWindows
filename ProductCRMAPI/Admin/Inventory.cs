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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ProductCRMAPI
{
    public partial class Inventory : Form
    {
        string excelFile = Path.Combine(Application.StartupPath, "Uploads", "Inventory.xlsx");
        public Inventory()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Close();
            //InitializeInvoiceGrid();
            InventoryForm_Load(sender,e);
        }
        private void InventoryForm_Load(object sender, EventArgs e)
        {
            LoadInventory();
            txtItemName.KeyUp += txtItemName_KeyUp;
            txtItemName.KeyDown += listBoxItems_KeyDown;
            listboxItem.MouseClick += listBoxItems_Click;
        }
        private void LoadInventory()
        {
            dgvInventory.Rows.Clear();

            if (!File.Exists(excelFile))
                return;

            ExcelPackage.License.SetNonCommercialPersonal("Rahul");
            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];

                int rowCount = sheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    dgvInventory.Rows.Add(
                        sheet.Cells[row, 2].Text,
                        sheet.Cells[row, 3].Text,
                        sheet.Cells[row, 4].Text,
                        sheet.Cells[row, 5].Text,
                        sheet.Cells[row, 6].Text,
                        sheet.Cells[row, 7].Text,
                        sheet.Cells[row, 8].Text,
                        sheet.Cells[row, 9].Text
                    );
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FetchItemDetails(txtItemName.Text);
        }

        private void CreateExcelIfNotExists()
        {
            if (File.Exists(excelFile))
                return;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Inventory");

                sheet.Cells[1, 1].Value = "SNO";
                sheet.Cells[1, 2].Value = "ItemName";
                sheet.Cells[1, 3].Value = "HSN";
                sheet.Cells[1, 4].Value = "Unit";
                sheet.Cells[1, 5].Value = "Qty";
                sheet.Cells[1, 6].Value = "MRP";
                sheet.Cells[1, 7].Value = "PurchasePrice";
                sheet.Cells[1, 8].Value = "SalePrice";
                sheet.Cells[1, 9].Value = "GST";

                package.SaveAs(new FileInfo(excelFile));
            }
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            CreateExcelIfNotExists();

            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];

                int lastRow = sheet.Dimension?.Rows ?? 1;
                int nextRow = lastRow + 1;

                sheet.Cells[nextRow, 1].Value = nextRow;
                sheet.Cells[nextRow, 2].Value = txtItemName.Text;
                sheet.Cells[nextRow, 3].Value = txtHsn.Text;
                sheet.Cells[nextRow, 4].Value = txtunit.Text;
                sheet.Cells[nextRow, 5].Value = txtQuantity.Text;
                sheet.Cells[nextRow, 6].Value = txtMRP.Text;
                sheet.Cells[nextRow, 7].Value = txtPPrice.Text;
                sheet.Cells[nextRow, 8].Value = txtSPrice.Text;
                sheet.Cells[nextRow, 9].Value = textGst.Text;

                package.Save();
            }

            LoadInventory();

            //MessageBox.Show("Item Added");
        }
        private void UpdateItem()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];

                int rows = sheet.Dimension.Rows;

                for (int i = 2; i <= rows; i++)
                {
                    if (sheet.Cells[i, 1].Text == txtSNO.Text)
                    {
                        sheet.Cells[i, 2].Value = txtItemName.Text;
                        sheet.Cells[i, 3].Value = txtHsn.Text;
                        sheet.Cells[i, 4].Value = txtunit.Text;
                        sheet.Cells[i, 5].Value = txtQuantity.Text;
                        sheet.Cells[i, 6].Value = txtMRP.Text;
                        sheet.Cells[i, 7].Value = txtPPrice.Text;
                        sheet.Cells[i, 8].Value = txtSPrice.Text;
                        sheet.Cells[i, 9].Value = textGst.Text;

                        package.Save();

                        MessageBox.Show("Updated Successfully");
                        LoadInventory();
                        return;
                    }
                }
            }
        }

        private void FetchItemDetails(string itemName)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];

                int rows = sheet.Dimension.Rows;

                for (int i = 2; i <= rows; i++)
                {
                    if (sheet.Cells[i, 2].Text.ToLower() == itemName.ToLower())
                    {
                        txtSNO.Text = sheet.Cells[i, 1].Text;
                        txtItemName.Text = sheet.Cells[i, 2].Text;
                        txtHsn.Text = sheet.Cells[i, 3].Text;
                        txtunit.Text = sheet.Cells[i, 4].Text;
                        txtQuantity.Text = sheet.Cells[i, 5].Text;
                        txtMRP.Text = sheet.Cells[i, 6].Text;
                        txtPPrice.Text = sheet.Cells[i, 7].Text;
                        txtSPrice.Text = sheet.Cells[i, 8].Text;
                        textGst.Text = sheet.Cells[i, 9].Text;
                        break;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateItem();
        }
        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            listboxItem.Items.Clear();

            string searchText = txtItemName.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                listboxItem.Visible = false;
                return;
            }

            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];
                int rows = sheet.Dimension.Rows;

                for (int i = 2; i <= rows; i++)
                {
                    string itemName = sheet.Cells[i, 2].Text;

                    if (itemName.ToLower().Contains(searchText))
                    {
                        listboxItem.Items.Add(itemName.ToUpper());
                    }
                }
            }

            listboxItem.Visible = listboxItem.Items.Count > 0;
        }
        private void listBoxItems_Click(object sender, EventArgs e)
        {
            if (listboxItem.SelectedItem != null)
            {
                txtItemName.Text = listboxItem.SelectedItem.ToString();

                FetchItemDetails(txtItemName.Text.ToUpper());

                listboxItem.Visible = false;
            }
        }
        private void listBoxItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listboxItem.SelectedItem != null)
                {
                    txtItemName.Text = listboxItem.SelectedItem.ToString();

                    FetchItemDetails(txtItemName.Text.ToUpper());

                    listboxItem.Visible = false;
                }
            }
        }
    }
}
