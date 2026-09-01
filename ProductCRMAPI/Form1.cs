using Newtonsoft.Json;
using OfficeOpenXml;
using QRCoder;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static QuestPDF.Helpers.Colors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Color = System.Drawing.Color;
using Label = System.Windows.Forms.Label;
using LicenseContext = OfficeOpenXml.LicenseContext;
using Panel = System.Windows.Forms.Panel;
using Size = System.Drawing.Size;
using TextBox = System.Windows.Forms.TextBox;

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
        string excelInvoice = ConfigurationManager.AppSettings["excelInvoice"];
        string excelInventory = ConfigurationManager.AppSettings["excelInventory"];

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
            txtBillTo.Leave += txtBillTo_Leave;
            listBoxBillingSearch.MouseDown += listBoxBillingSearch_MouseDown;
            dgvItems.CellClick += dgvItems_CellClick;
            //txtItemName.Leave += txtListBox_LeaveClick;

            //Validation for numeric
            txtContactNo.KeyPress += NumericTextBox_KeyPress;
            txtQty.KeyPress += NumericTextBox_KeyPress;
            txtPrice.KeyPress += NumericTextBox_KeyPress;
            txtDiscount.KeyPress += NumericTextBox_KeyPress;
            txtGST.KeyPress += NumericTextBox_KeyPress;
            txtAmount.KeyPress += NumericTextBox_KeyPress;
            //validation for required
            //txtContactNo.Tag = "Required";
            txtBillTo.Tag = "Required";
            txtState.Tag = "Required";
            txtInvoiceDate.Tag = "Required";
            //txtGSTINNumber.Tag = "Required";
            txtPOS.Tag = "Required";
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

            DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
            deleteColumn.Name = "Delete";
            deleteColumn.HeaderText = "";
            deleteColumn.Image = new Bitmap(Properties.Resources.delete);
            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dgvItems.Columns.Add(deleteColumn);
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.AllowUserToAddRows = false;
        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private bool ValidateRequiredFields()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt &&
                    txt.Tag?.ToString() == "Required")
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        ShowMessage($"{txt.Name} is required", Color.FromArgb(220, 53, 69));
                        txt.Focus();
                        return false;
                    }
                }
            }
            return true;
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
            decimal qty = Convert.ToDecimal(txtQty.Text);
            //decimal price = Convert.ToDecimal(txtPrice.Text);

            //decimal discount = 0;
            //decimal.TryParse(txtDiscount.Text, out discount);

            //decimal gst = 0;
            //decimal.TryParse(txtGST.Text, out gst);

            //decimal baseAmount = qty * price;

            //decimal gstMultiplier = 1 + (gst / 100);

            //price = baseAmount / gstMultiplier;


            
            //TotalDiscount += price * discount / 100;

            //decimal finalAmount = price - TotalDiscount;
            //SubTotal += finalAmount;

            //price = price - TotalDiscount;

            //decimal gstAmnt = price * gst / 100;

            //TotalCGST += gstAmnt / 2;
            //TotalSGST += gstAmnt / 2;

            //finalAmount = Convert.ToDecimal(txtAmount.Text);
            int QtyCheck = Convert.ToInt32(txtQty.Text);

            //Total += finalAmount;
            if (QtyCheck > Convert.ToInt32(txtAvailableQty.Text))
            {
                ShowMessage("You don't have enough quantity!", Color.FromArgb(220, 53, 69));
                return;
            }
            var result = UpdateTotals(Convert.ToDecimal(txtQty.Text),Convert.ToDecimal(txtPrice.Text),Convert.ToDecimal(txtGST.Text),
                 string.IsNullOrWhiteSpace(txtDiscount.Text)
                     ? 0
                     : Convert.ToDecimal(txtDiscount.Text),
                 true
             );
            decimal productPrice = result.ProductPrice;
            decimal finalAmount = result.FinalAmount;
            dgvItems.Rows.Add(
                txtItemName.Text,
                txtHSN.Text,
                qty,
                cmbUnit.Text,
                productPrice.ToString("0.00"),
                txtDiscount.Text,
                txtGST.Text,
                finalAmount.ToString("0.00")
            );

            ClearItemFields();
        }
        private (decimal ProductPrice, decimal FinalAmount) UpdateTotals(decimal qty,decimal price,decimal gst,decimal discount,bool isAdd)
        {
            decimal baseAmount = qty * price;

            decimal taxableAmount = baseAmount / (1 + (gst / 100));

            decimal discountAmount = taxableAmount * discount / 100;

            decimal netAmount = taxableAmount - discountAmount;

            decimal gstAmount = netAmount * gst / 100;

            decimal finalAmount = netAmount + gstAmount;

            int factor = isAdd ? 1 : -1;

            TotalDiscount += factor * discountAmount;
            SubTotal += factor * netAmount;
            TotalCGST += factor * (gstAmount / 2);
            TotalSGST += factor * (gstAmount / 2);
            Total += factor * finalAmount;

            return (netAmount, finalAmount);
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

            decimal taxableAmount = baseAmount / (1 + (gst / 100));

            decimal discountAmount = taxableAmount * discount / 100;

            decimal netAmount = taxableAmount - discountAmount;

            decimal gstAmount = netAmount * gst / 100;

            decimal finalAmount = netAmount + gstAmount;

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
        public static string ConvertAmountToWords(string amount)
        {
            decimal finalTotal = Math.Floor(Convert.ToDecimal(amount) * 100) / 100;

            long rupees = (long)Math.Floor(finalTotal);
            int paise = (int)((finalTotal - rupees) * 100);

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
            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelInventory)))
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
                        txtAvailableQty.Text = sheet.Cells[i, 5].Text;
                        txtPrice.Text = sheet.Cells[i, 8].Text;
                        //txtSPrice.Text = sheet.Cells[i, 6].Text;
                        txtGST.Text = sheet.Cells[i, 9].Text;
                        break;
                    }
                }
            }
        }
        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            txtlistbox.Items.Clear();

            string searchText = txtItemName.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                txtlistbox.Visible = false;
                return;
            }

            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelInventory)))
            {
                var sheet = package.Workbook.Worksheets[0];
                int rows = sheet.Dimension.Rows;

                for (int i = 2; i <= rows; i++)
                {
                    string itemName = sheet.Cells[i, 2].Text;

                    if (itemName.ToLower().Contains(searchText.ToLower()))
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
            int nextNumber = 1;

            if (File.Exists(excelInvoice))
            {
                ExcelPackage.License.SetNonCommercialPersonal("Rahul");

                using (var package = new ExcelPackage(new FileInfo(excelInvoice)))
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
            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelInvoice)))
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
            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelInvoice)))
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
            listBoxBillingSearch.Items.Clear();

            string searchText = txtBillTo.Text.Trim();

            txtContactNo.Clear();
            txtGSTINNumber.Clear();
            txtPOS.Clear();
            txtState.Clear();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                listBoxBillingSearch.Visible = false;
                return;
            }

            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            HashSet<string> uniqueItems = new HashSet<string>();

            using (var package = new ExcelPackage(new FileInfo(excelInvoice)))
            {
                var sheet = package.Workbook.Worksheets[0];

                int rows = sheet.Dimension.Rows;
                int lastMatchedRow = -1;

                for (int i = 2; i <= rows; i++)
                {
                    string itemName = sheet.Cells[i, 3].Text.Trim();
                    string address = sheet.Cells[i, 7].Text.Trim();

                    // Search matching names
                    if (itemName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        if (uniqueItems.Add(itemName))
                        {
                            listBoxBillingSearch.Items.Add(
                                itemName + " : " + address
                            );
                        }
                    }

                    // Exact match
                    if (itemName.Equals(searchText, StringComparison.OrdinalIgnoreCase))
                    {
                        lastMatchedRow = i;
                    }
                }

                // Fill other fields when exact customer is found
                if (lastMatchedRow > 0)
                {
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
                string[] parts = listBoxBillingSearch.SelectedItem.ToString().Split(':');

                if (parts.Length >= 2)
                {
                    string firstName = parts[0].Trim();
                    string secAddress = parts[1].Trim();

                    txtBillTo.Text = firstName;

                    FetchBillingDetails(firstName);

                    listBoxBillingSearch.Visible = false;
                }
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
            txtAvailableQty.Clear();
            txtInvoiceNo.Text = GenerateInvoiceNumber();
            dgvItems.Rows.Clear();
            ClearItemFields();
            Total = 0;
            SubTotal = 0;
            TotalDiscount = 0;
            TotalCGST = 0;
            TotalSGST = 0;
        }

        private void UpdateItem()
        {

            ExcelPackage.License.SetNonCommercialPersonal("Rahul");

            using (var package = new ExcelPackage(new FileInfo(excelInventory)))
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
        byte[] ImageToBytes(System.Drawing.Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!ValidateRequiredFields())
                return;
            if (dgvItems.Rows.Count == 0)
            {
                ShowMessage($"At least one item is required", Color.FromArgb(220, 53, 69));
                return;
            }
            //CalculateSummary();

            QuestPDF.Settings.License = LicenseType.Community;

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5.Landscape());
                    
                    page.Margin(5);

                    page.Header().Row(row =>
                    {
                        //row.ConstantItem(40).Height(40).Image(ImageToBytes(Properties.Resources.logo));
                        
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("AARAV ENTERPRISES")
                                .FontSize(11)
                                .Bold();

                            col.Item().Text("Dal Bazar Lashkar, Gwalior").FontSize(10);
                            col.Item().Text("GSTIN : 23CYSPB9884R1Z8").FontSize(10);
                            col.Item().Text("Contact : +91 9977422337").FontSize(10);
                        });

                        //row.ConstantItem(60).Width(60)
                        //    .Height(60).MaxHeight(60).MaxWidth(60)
                        //    .Image(ImageToBytes(Properties.Resources.logo));

                        var upiUrl = "upi://pay?pa=merchant@upi&pn=ABC Store&am=1300&cu=INR";
                        //var qrCodeBytes = GenerateQrCode(upiUrl);
                    });

                    page.Content().PaddingVertical(1).Column(col =>
                    {
                        col.Spacing(5);

                        col.Item().AlignCenter().Text("Tax Invoice")
                            .FontSize(11).FontColor("#9B7AD9")
                            .Bold();

                        col.Item().Row(row =>
                        {
                            row.RelativeItem(4).Border(0).Padding(1).Column(left =>
                            {
                                left.Item().Text("Bill To").FontSize(10).Bold();

                                left.Item().Text(txtBillTo.Text).FontSize(9);
                                left.Item().Text("Contact : " + txtContactNo.Text).FontSize(9);
                                left.Item().Text("GSTIN : " + txtGSTINNumber.Text).FontSize(9);
                                left.Item().Text("State : " + txtState.Text).FontSize(9);
                            });

                            row.RelativeItem(4).AlignRight().Border(0).Padding(1).Column(right =>
                            {
                                right.Item().Text($"Invoice No : {txtInvoiceNo.Text}").FontSize(9);
                                right.Item().Text($"Invoice Date : {txtInvoiceDate.Value.ToString("dd/MM/yyyy")}").FontSize(9);
                                right.Item().Text($"Place Of Supply : {txtPOS.Text}").FontSize(9);
                            });
                        });

                        col.Item().PaddingTop(1);

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
                                header.Cell().Border(1).Background("#9B7AD9").Padding(1).Text("Item").FontSize(8);
                                header.Cell().Border(1).Background("#9B7AD9").Padding(1).Text("HSN").FontSize(8);
                                header.Cell().Border(1).Background("#9B7AD9").Padding(1).Text("Qty").FontSize(8);
                                header.Cell().Border(1).Background("#9B7AD9").Padding(1).Text("Unit").FontSize(8);
                                header.Cell().Border(1).Background("#9B7AD9").Padding(1).Text("Rate").FontSize(8);
                                //if (TotalDiscount > 0)
                                    header.Cell().Border(1).Background("#9B7AD9").Padding(1).Text("Discount %").FontSize(8);
                                header.Cell().Border(1).Background("#9B7AD9").Padding(1).Text("GST %").FontSize(8);
                                header.Cell().Border(1).Background("#9B7AD9").Padding(1).Text("Amount").FontSize(8);
                            });

                            foreach (DataGridViewRow row in dgvItems.Rows)
                            {
                                if (row.IsNewRow)
                                    continue;

                                table.Cell().Border(1).Padding(1)
                                    .Text(row.Cells["txtItemName"].Value?.ToString() ?? "").FontSize(8);

                                table.Cell().Border(1).Padding(1)
                                    .Text(row.Cells["txtHSN"].Value?.ToString() ?? "").FontSize(8);

                                table.Cell().Border(1).Padding(1)
                                    .Text(row.Cells["txtQty"].Value?.ToString() ?? "").FontSize(8);

                                table.Cell().Border(1).Padding(1)
                                    .Text(row.Cells["txtUnit"].Value?.ToString() ?? "").FontSize(8);

                                table.Cell().Border(1).Padding(1)
                                    .Text(Convert.ToDecimal(row.Cells["txtPrice"].Value ?? 0).ToString("0.00")).FontSize(8);

                                if (TotalDiscount < 0)
                                    table.Cell().Border(1).Padding(1).Text("").FontSize(8);
                                else
                                    table.Cell().Border(1).Padding(1).Text(row.Cells["txtDiscount"].Value?.ToString() ?? "").FontSize(8);

                                table.Cell().Border(1).Padding(1)
                                        .Text(row.Cells["txtGST"].Value?.ToString() ?? "").FontSize(8);

                                table.Cell().Border(1).Padding(1)
                                    .Text(row.Cells["txtAmount"].Value?.ToString() ?? "").FontSize(8);
                                try {
                                    productList.Add(row.Cells["txtItemName"].Value.ToString(), row.Cells["txtQty"].Value.ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Item already exists!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        });
                        decimal finalTotal = Math.Floor(Total * 100) / 100;
                        string ttlAmt = ConvertAmountToWords(finalTotal.ToString("0.00"));
                        col.Item().PaddingTop(2);

                        col.Item().Row(mainRow =>
                        {
                            // Left Side
                            mainRow.RelativeItem().Column(left =>
                            {
                                left.Item().Text("Invoice Amount In Words").Bold().FontSize(9);
                                left.Item().PaddingTop(1);
                                left.Item().Text(ttlAmt).FontSize(8);
                                left.Item().PaddingTop(1);
                                left.Item().Text("Terms & Conditions").Bold().FontSize(9);
                                left.Item().PaddingTop(1);
                                left.Item().Text("Thank you for doing business with us.").FontSize(8);
                            });

                            // Right Side
                            mainRow.ConstantItem(150).Column(summary =>
                            {
                                void AddRow(string title, string value)
                                {
                                    summary.Item().Row(row =>
                                    {
                                        row.ConstantItem(75)
                                           .Text(title).FontSize(10)
                                           .Bold();

                                        row.ConstantItem(40)
                                           .AlignRight()
                                           .Text(value).FontSize(10);
                                    });
                                }
                                decimal finalTotal1 = Math.Floor(Total * 100) / 100;
                                AddRow("Sub Total", SubTotal.ToString("0.00"));

                                if (TotalDiscount > 0)
                                    AddRow("Discount", TotalDiscount.ToString("0.00"));

                                AddRow("Total SGST", TotalSGST.ToString("0.00"));
                                AddRow("Total CGST", TotalCGST.ToString("0.00"));
                                AddRow("Total", finalTotal1.ToString("0.00"));
                            });
                        });

                        col.Item().PaddingTop(12);

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
            string convertedInvoiceNo = txtInvoiceNo.Text.Replace("/", "_").Replace("-", "_");
            saveDialog.FileName = "Invoice_" + convertedInvoiceNo + ".pdf";

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
        
        private void txtBillTo_Leave(object sender, EventArgs e)
        {
            if (listBoxBillingSearch.ContainsFocus)
                return;

            listBoxBillingSearch.Visible = false;
        }
        private void listBoxBillingSearch_MouseDown(object sender, MouseEventArgs e)
        {
            listBoxBillingSearch.Focus();
        }
        private void ShowMessage(string message, Color headerColor)
        {
            Form popup = new Form();
            popup.Size = new Size(350, 170);
            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.FormBorderStyle = FormBorderStyle.FixedDialog;
            popup.Text = "";

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 25;
            header.BackColor = headerColor;

            // Left Icon
            PictureBox picLeft = new PictureBox();
            picLeft.Size = new Size(32, 32);
            picLeft.Location = new Point(15, 45);
            picLeft.Image = Properties.Resources.sunday;
            picLeft.SizeMode = PictureBoxSizeMode.StretchImage;

            // Right Icon
            PictureBox picRight = new PictureBox();
            picRight.Size = new Size(32, 32);
            picRight.Location = new Point(290, 45);
            picRight.Image = Properties.Resources.sunday;
            picRight.SizeMode = PictureBoxSizeMode.StretchImage;

            Label lbl = new Label();
            lbl.Text = message;
            lbl.Size = new Size(220, 40);
            lbl.Location = new Point(60, 40);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            Button btn = new Button();
            btn.Text = "OK";
            btn.Width = 80;
            btn.Height = 30;
            btn.Location = new Point(130, 90);

            btn.BackColor = Color.FromArgb(155, 122, 217);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.Click += (s, e) => popup.Close();

            popup.Controls.Add(header);
            popup.Controls.Add(picLeft);
            popup.Controls.Add(picRight);
            popup.Controls.Add(lbl);
            popup.Controls.Add(btn);

            popup.ShowDialog();
        }
        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dgvItems.Columns[e.ColumnIndex].Name == "Delete")
            {

                    DataGridViewRow row = dgvItems.Rows[e.RowIndex];

                    string cellValue = row.Cells[5].Value?.ToString();
                    decimal tempDiscnt = string.IsNullOrWhiteSpace(cellValue) ? 0 : Convert.ToDecimal(cellValue);

                    decimal tempQty = Convert.ToDecimal(row.Cells[2].Value ?? 0);
                    decimal tempPrice = Convert.ToDecimal(row.Cells[4].Value ?? 0);
                    decimal tempDiscount = tempDiscnt;
                    decimal tempGst = Convert.ToDecimal(row.Cells[6].Value ?? 0);
                    decimal tempAmount = Convert.ToDecimal(row.Cells[7].Value ?? 0);

                    
                    UpdateTotals(
                        Convert.ToDecimal(tempQty),
                        Convert.ToDecimal(tempAmount/ tempQty),
                        Convert.ToDecimal(tempGst),
                        tempDiscount,
                        false
                    );
                
                dgvItems.Rows.RemoveAt(e.RowIndex);
            }
        }

        private byte[] GenerateQrCode(string paymentData)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(
                paymentData,
                QRCodeGenerator.ECCLevel.Q);

            var pngQrCode = new PngByteQRCode(qrCodeData);

            return pngQrCode.GetGraphic(20);
        }
    }
}
