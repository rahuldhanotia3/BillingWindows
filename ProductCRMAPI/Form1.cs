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
using static QuestPDF.Helpers.Colors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ProductCRMAPI
{
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Close();
            //InitializeInvoiceGrid();
            txtInvoiceDate.Format = DateTimePickerFormat.Custom;
            txtInvoiceDate.CustomFormat = "dd/MM/yyyy";
            txtInvoiceDate.MinDate = new DateTime(1900, 1, 1);
            txtInvoiceDate.Value = DateTime.Now;
            txtInvoiceDate.MaxDate = DateTime.Today;
            dgvItems.CellEndEdit += dgvItems_CellEndEdit;
            cmbUnit.Items.AddRange(new string[]
            {
                "KG",
                "LITER",
                "Pcs",
                "Boxes",
                "GRAM",
                "METER",
                "HOURS"
            });

            cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnit.SelectedIndex = 0;

            txtQty.TextChanged += Input_TextChanged;
            txtPrice.TextChanged += Input_TextChanged;
            txtDiscount.TextChanged += Input_TextChanged;
            txtGST.TextChanged += Input_TextChanged;

            InitializeInvoiceGrid();
            txtInvoiceNo.Text = GenerateInvoiceNumber();
            listBoxBillingSearch.MouseClick += listBoxBilling_Click;
            txtItemName.KeyUp += txtItemName_KeyUp;
            txtlistbox.MouseClick += listBoxItems_Click;
        }
        private void InitializeInvoiceGrid()
        {
            dgvItems.Columns.Clear();

            dgvItems.Columns.Add("txtItemName", "Item Name");
            dgvItems.Columns.Add("txtHSN", "HSN/SAC");
            dgvItems.Columns.Add("txtQty", "Quantity");
            dgvItems.Columns.Add("txtUnit", "Unit");
            dgvItems.Columns.Add("txtPrice", "Price/Unit");
            dgvItems.Columns.Add("txtDiscount", "Discount %");
            dgvItems.Columns.Add("txtGST", "GST %");
            dgvItems.Columns.Add("txtAmount", "Amount");

            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiscount.Text))
                txtDiscount.Text = "0";

            decimal qty = Convert.ToDecimal(txtQty.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);

            decimal discount = 0;
            decimal.TryParse(txtDiscount.Text, out discount);

            decimal gst = 0;
            decimal.TryParse(txtGST.Text, out gst);

            decimal baseAmount = qty * price;

            decimal discountAmt = baseAmount * discount / 100;

            decimal taxableAmount = baseAmount - discountAmt;

            decimal gstAmt = taxableAmount * gst / 100;

            decimal finalAmount = taxableAmount + gstAmt;

            dgvItems.Rows.Add(
                txtItemName.Text,
                txtHSN.Text,
                qty,
                cmbUnit.Text,
                price,
                discount == 0m ? "" : discount.ToString("0.##"),
                gst,
                finalAmount
            );

            ClearItemFields();
        }
        private void CalculateAmount()
        {
            decimal qty = 0;
            decimal price = 0;
            decimal discount = 0;
            decimal gst = 0;

            decimal.TryParse(txtQty.Text, out qty);
            decimal.TryParse(txtPrice.Text, out price);
            decimal.TryParse(txtDiscount.Text, out discount);
            decimal.TryParse(txtGST.Text, out gst);

            decimal baseAmount = qty * price;

            decimal discountAmt = baseAmount * discount / 100;

            decimal taxableAmount = baseAmount - discountAmt;

            decimal gstAmt = taxableAmount * gst / 100;

            decimal finalAmount = taxableAmount + gstAmt;

            txtAmount.Text = finalAmount.ToString("0.00");
        }
        private void Input_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }
        private void ClearItemFields()
        {
            txtItemName.Clear();
            txtHSN.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            txtDiscount.Clear();
            txtGST.Clear();
            txtAmount.Clear();
        }
        private void dgvItems_CellEndEdit(object sender,DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvItems.Rows[e.RowIndex];

            decimal qty = Convert.ToDecimal(row.Cells["Qty"].Value ?? 0);
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);
            decimal discount = Convert.ToDecimal(row.Cells["Discount"].Value ?? 0);

            decimal amount = qty * price;
            amount -= amount * discount / 100;

            row.Cells["Amount"].Value = amount.ToString("0.00");
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSGST9_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void CalculateSummary()
        {
            SubTotal = 0;
            TotalDiscount = 0;
            TotalSGST = 0;
            TotalCGST = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow)
                    continue;

                decimal qty = Convert.ToDecimal(row.Cells["txtQty"].Value ?? 0);
                decimal price = Convert.ToDecimal(row.Cells["txtPrice"].Value ?? 0);
                decimal discount = decimal.TryParse(Convert.ToString(row.Cells["txtDiscount"].Value),out var d)? d: 0;
                decimal gst = Convert.ToDecimal(row.Cells["txtGST"].Value ?? 0);

                decimal baseAmount = qty * price;

                decimal discountAmt = baseAmount * discount / 100;
                TotalDiscount += discountAmt;

                decimal taxableAmount = baseAmount - discountAmt;

                SubTotal += taxableAmount;

                decimal sgst = taxableAmount * (gst / 2) / 100;
                decimal cgst = taxableAmount * (gst / 2) / 100;

                TotalSGST += sgst;
                TotalCGST += cgst;
            }

            Saved = TotalDiscount;

            Total = SubTotal + TotalSGST + TotalCGST;

            Balance = Total - Received;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            string pin = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter Admin PIN",
                "Admin Login",
                "");

            if (pin == "696969") // Your PIN
            {
                Inventory inventoryForm = new Inventory();
                inventoryForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Invalid PIN",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public static string ConvertAmountToWords(decimal amount)
        {
            long rupees = (long)Math.Floor(amount);
            int paise = (int)((amount - rupees) * 100);

            string result = "Rupees " + NumberToWords(rupees);

            if (paise > 0)
            {
                result += " and " + NumberToWords(paise) + " Paise";
            }

            return result + " Only";
        }
        public static string NumberToWords(long number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "";

                string[] unitsMap =
                {
            "Zero","One","Two","Three","Four","Five","Six","Seven","Eight","Nine",
            "Ten","Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen",
            "Seventeen","Eighteen","Nineteen"
        };

                string[] tensMap =
                {
            "Zero","Ten","Twenty","Thirty","Forty","Fifty",
            "Sixty","Seventy","Eighty","Ninety"
        };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];

                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            return words.Trim();
        }
        private void FetchItemDetails(string itemName)
        {
            string excelFile = Path.Combine(Application.StartupPath, "Uploads", "Inventory.xlsx");
            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets[0];

                int rows = sheet.Dimension.Rows;

                for (int i = 2; i <= rows; i++)
                {
                    if (sheet.Cells[i, 2].Text.ToUpper() == itemName.ToUpper())
                    {
                        txtSNO.Text = sheet.Cells[i, 1].Text;
                        txtItemName.Text = sheet.Cells[i, 2].Text;
                        txtHSN.Text = sheet.Cells[i, 3].Text;
                        cmbUnit.SelectedItem = sheet.Cells[i, 4].Text;
                        txtQty.Text = sheet.Cells[i, 5].Text;
                        txtPrice.Text = sheet.Cells[i, 6].Text;
                        //txtSPrice.Text = sheet.Cells[i, 6].Text;
                        txtGST.Text = sheet.Cells[i, 8].Text;
                        break;
                    }
                }
            }
        }
        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            string excelFile = Path.Combine(Application.StartupPath, "Uploads", "Inventory.xlsx");
            txtlistbox.Items.Clear();

            string searchText = txtItemName.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                txtlistbox.Visible = false;
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
                        txtlistbox.Items.Add(itemName.ToUpper());
                    }
                }
            }

            txtlistbox.Visible = txtlistbox.Items.Count > 0;
        }
        private void listBoxItems_Click(object sender, EventArgs e)
        {
            if (txtlistbox.SelectedItem != null)
            {
                txtItemName.Text = txtlistbox.SelectedItem.ToString();

                FetchItemDetails(txtItemName.Text.ToUpper());

                txtlistbox.Visible = false;
            }
        }
        private void listBoxItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtlistbox.SelectedItem != null)
                {
                    txtItemName.Text = txtlistbox.SelectedItem.ToString();

                    FetchItemDetails(txtItemName.Text);

                    txtlistbox.Visible = false;
                }
            }
        }
        private void lblMainHeader_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private string GenerateInvoiceNumber()
        {
            string excelFile = Path.Combine(Application.StartupPath, "Uploads", "Invoice.xlsx");
            int nextNumber = 1;

            if (File.Exists(excelFile))
            {
                ExcelPackage.License.SetNonCommercialPersonal("Rahul");

                using (var package = new ExcelPackage(new FileInfo(excelFile)))
                {
                    var sheet = package.Workbook.Worksheets[0];

                    if (sheet.Dimension != null)
                    {
                        int lastRow = sheet.Dimension.Rows;

                        if (lastRow > 1)
                        {
                            string lastInvoice =
                                sheet.Cells[lastRow, 2].Text; // Column A

                            if (!string.IsNullOrEmpty(lastInvoice))
                            {
                                string numberPart = lastInvoice.Split('/')[0];

                                if (int.TryParse(numberPart, out int lastNo))
                                {
                                    nextNumber = lastNo + 1;
                                }
                            }
                        }
                    }
                }
            }

            return $"{nextNumber:D4}/26-27";
        }
        private void btnAddUpdate_Click()
        {
            //CreateExcelIfNotExists();
            string excelFile = Path.Combine(Application.StartupPath,"Uploads","Invoice.xlsx");
            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            {
                var sheet = package.Workbook.Worksheets["Invoice"];

                int lastRow = sheet.Dimension?.Rows ?? 1;
                int nextRow = lastRow + 1;

                sheet.Cells[nextRow, 1].Value = nextRow;
                sheet.Cells[nextRow, 2].Value = txtInvoiceNo.Text;
                sheet.Cells[nextRow, 3].Value = txtBillTo.Text;
                sheet.Cells[nextRow, 4].Value = txtContactNo.Text;
                sheet.Cells[nextRow, 5].Value = txtGSTINNumber.Text;
                sheet.Cells[nextRow, 6].Value = txtState.Text;
                sheet.Cells[nextRow, 7].Value = txtPOS.Text;
                sheet.Cells[nextRow, 8].Value = txtInvoiceDate.Text;

                package.Save();
            }
        }
        private void FetchBillingDetails(string itemName)
        {
            string excelFile = Path.Combine(Application.StartupPath, "Uploads", "Invoice.xlsx");
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
                    txtSNO.Text = sheet.Cells[lastMatchedRow, 1].Text;
                    txtBillTo.Text = sheet.Cells[lastMatchedRow, 3].Text;
                    txtContactNo.Text = sheet.Cells[lastMatchedRow, 4].Text;
                    txtGSTINNumber.Text = sheet.Cells[lastMatchedRow, 5].Text;
                    txtState.Text = sheet.Cells[lastMatchedRow, 6].Text;
                    txtPOS.Text = sheet.Cells[lastMatchedRow, 7].Text;
                }
            }
        }
        private void txtBillTo_KeyUp(object sender, KeyEventArgs e)
        {
            string excelFile = Path.Combine(Application.StartupPath, "Uploads", "Invoice.xlsx");

            listBoxBillingSearch.Items.Clear();

            string searchText = txtBillTo.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                listBoxBillingSearch.Visible = false;
                return;
            }

            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            HashSet<string> uniqueItems = new HashSet<string>();

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
                    txtBillTo.Text = sheet.Cells[lastMatchedRow, 3].Text;
                    txtContactNo.Text = sheet.Cells[lastMatchedRow, 4].Text;
                    txtGSTINNumber.Text = sheet.Cells[lastMatchedRow, 5].Text;
                    txtState.Text = sheet.Cells[lastMatchedRow, 6].Text;
                    txtInvoiceNo.Text = sheet.Cells[lastMatchedRow, 2].Text;
                    txtPOS.Text = sheet.Cells[lastMatchedRow, 7].Text;
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
            txtInvoiceNo.Text = GenerateInvoiceNumber();
            dgvItems.Rows.Clear();
            ClearItemFields();
        }

        private void UpdateItem()
        {

            string excelFile = Path.Combine(Application.StartupPath, "Uploads", "Inventory.xlsx");
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CalculateSummary();

            QuestPDF.Settings.License = LicenseType.Community;

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(20);

                    page.Header().Column(col =>
                    {
                        col.Item().Text("AARAV ENTERPRISES")
                            .FontSize(22)
                            .Bold();

                        col.Item().Text("Dal Bazar Lashkar, Gwalior");
                        col.Item().Text("GSTIN : 23CYSPB9884R1Z8");
                        col.Item().Text("Contact : +91 9977422337");
                    });

                    page.Content().PaddingVertical(15).Column(col =>
                    {
                        col.Spacing(10);

                        col.Item().AlignCenter().Text("Tax Invoice")
                            .FontSize(12).FontColor("#9B7AD9")
                            .Bold();

                        col.Item().Row(row =>
                        {
                            row.RelativeItem(4).Border(0).Padding(10).Column(left =>
                            {
                                left.Item().Text("Bill To").Bold();

                                left.Item().Text(txtBillTo.Text);
                                left.Item().Text("Contact : " + txtContactNo.Text);
                                left.Item().Text("GSTIN : " + txtGSTINNumber.Text);
                                left.Item().Text("State : " + txtState.Text);
                            });

                            row.RelativeItem(4).AlignRight().Border(0).Padding(10).Column(right =>
                            {
                                right.Item().Text($"Invoice No : {txtInvoiceNo.Text}");
                                right.Item().Text($"Invoice Date : {txtInvoiceDate.Value.ToString("dd/MM/yyyy")}");
                                right.Item().Text($"Place Of Supply : {txtPOS.Text}");
                            });
                        });

                        col.Item().PaddingTop(5);

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(4);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(1).Background("#9B7AD9").Padding(3).Text("Item");
                                header.Cell().Border(1).Background("#9B7AD9").Padding(3).Text("HSN");
                                header.Cell().Border(1).Background("#9B7AD9").Padding(3).Text("Qty");
                                header.Cell().Border(1).Background("#9B7AD9").Padding(3).Text("Unit");
                                header.Cell().Border(1).Background("#9B7AD9").Padding(3).Text("Rate");
                                if (TotalDiscount > 0)
                                    header.Cell().Border(1).Background("#9B7AD9").Padding(3).Text("Discount %");
                                header.Cell().Border(1).Background("#9B7AD9").Padding(3).Text("GST %");
                                header.Cell().Border(1).Background("#9B7AD9").Padding(3).Text("Amount");
                            });

                            foreach (DataGridViewRow row in dgvItems.Rows)
                            {
                                if (row.IsNewRow)
                                    continue;

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtItemName"].Value?.ToString() ?? "");

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtHSN"].Value?.ToString() ?? "");

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtQty"].Value?.ToString() ?? "");

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtUnit"].Value?.ToString() ?? "");

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtPrice"].Value?.ToString() ?? "");

                                if (TotalDiscount > 0)
                                    table.Cell().Border(1).Padding(3).Text(row.Cells["txtDiscount"].Value?.ToString() ?? "");

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtGST"].Value?.ToString() ?? "");

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtAmount"].Value?.ToString() ?? "");

                                productList.Add(row.Cells["txtItemName"].Value.ToString(), row.Cells["txtQty"].Value.ToString());

                            }
                        });

                        string ttlAmt = ConvertAmountToWords(Total);
                        col.Item().PaddingTop(5);

                        col.Item().Row(mainRow =>
                        {
                            // Left Side
                            mainRow.RelativeItem().Column(left =>
                            {
                                left.Item().Text("Invoice Amount In Words").Bold().FontSize(10);
                                left.Item().PaddingTop(5);
                                left.Item().Text(ttlAmt);
                                left.Item().PaddingTop(5);
                                left.Item().Text("Terms & Conditions").Bold().FontSize(10);
                                left.Item().PaddingTop(5);
                                left.Item().Text("Thank you for doing business with us.");
                            });

                            // Right Side
                            mainRow.ConstantItem(150).Column(summary =>
                            {
                                void AddRow(string title, string value)
                                {
                                    summary.Item().Row(row =>
                                    {
                                        row.ConstantItem(80)
                                           .Text(title)
                                           .Bold();

                                        row.ConstantItem(60)
                                           .AlignRight()
                                           .Text(value);
                                    });
                                }

                                AddRow("Sub Total", SubTotal.ToString("0.00"));

                                if (TotalDiscount > 0)
                                    AddRow("Discount", TotalDiscount.ToString("0.00"));

                                AddRow("Total SGST", TotalSGST.ToString("0.00"));
                                AddRow("Total CGST", TotalCGST.ToString("0.00"));
                                AddRow("Total", Total.ToString("0.00"));
                                AddRow("You Saved", Saved.ToString("0.00"));
                            });
                        });

                        col.Item().PaddingTop(15);

                        col.Item().Row(row =>
                        {
                            row.RelativeItem();

                            row.ConstantItem(200)
                                .Column(x =>
                                {
                                    //x.Item().Text("For Your Company");
                                    //x.Item().Height(60);
                                    x.Item().AlignCenter().Text("Authorized Signatory");
                                });
                        });
                    });

                    //page.Footer()
                    //    .AlignCenter()
                    //    .Text(text =>
                    //    {
                    //        text.Span("Thank you for your business!").SemiBold();
                    //    });
                });
            }).GeneratePdf();
            UpdateItem();
            // Save PDF
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveDialog.FileName = "Invoice_" + txtBillTo.Text + ".pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveDialog.FileName, pdf);

                //MessageBox.Show("PDF saved successfully!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

                // Open PDF automatically
                Process.Start(new ProcessStartInfo
                {
                    FileName = saveDialog.FileName,
                    UseShellExecute = true
                });
            }
            btnAddUpdate_Click();
        }

        private void btnBillingUsers_Click(object sender, EventArgs e)
        {
            string pin = Microsoft.VisualBasic.Interaction.InputBox(
            "Enter Admin PIN",
            "Admin Login",
            "");

            if (pin == "696969") // Your PIN
            {
                BillingUsers UsersForm = new BillingUsers();
                UsersForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Invalid PIN",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
