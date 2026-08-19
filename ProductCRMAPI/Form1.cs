using Newtonsoft.Json;
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

namespace ProductCRMAPI
{
    public partial class Form1 : Form
    {
        decimal SubTotal = 0;
        decimal TotalDiscount = 0;
        decimal SGST25 = 0;
        decimal CGST25 = 0;
        decimal SGST9 = 0;
        decimal CGST9 = 0;
        decimal Received = 0;
        decimal Balance = 0;
        decimal Saved = 0;
        decimal Total = 0;
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
                "NO",
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
            decimal qty = Convert.ToDecimal(txtQty.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);
            decimal discount = Convert.ToDecimal(txtDiscount.Text);
            decimal gst = Convert.ToDecimal(txtGST.Text);

            decimal amount = qty * price;
            amount -= amount * discount / 100;
            decimal discountAmt = amount * discount / 100; 
            decimal gstAmt = amount * gst / 100;
            decimal finalAmount = amount + gstAmt;
            txtAmount.Text = finalAmount.ToString("0.00");

            dgvItems.Rows.Add(
                txtItemName.Text,
                txtHSN.Text,
                qty,
                cmbUnit.SelectedItem.ToString(),
                price,
                discount,
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

            decimal amount = qty * price;

            decimal discountAmt = amount * discount / 100;
            amount -= discountAmt;

            decimal gstAmt = amount * gst / 100;
            decimal finalAmount = amount + gstAmt;

            //txtDiscount.Text = discountAmt.ToString("0.00");
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

        private void button2_Click(object sender, EventArgs e)
        {
            CalculateSummary();
            QuestPDF.Settings.License = LicenseType.Community;

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
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
                            row.RelativeItem(3).Border(0).Padding(10).Column(left =>
                            {
                                left.Item().Text("Bill To").Bold();

                                left.Item().Text(txtBillTo.Text);
                                left.Item().Text("Contact : " + txtContactNo.Text);
                                left.Item().Text("GSTIN : " + txtGSTINNumber.Text);
                                left.Item().Text("State : " + txtState.Text);
                            });

                            row.RelativeItem(2).AlignRight().Border(0).Padding(10).Column(right =>
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

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtDiscount"].Value?.ToString() ?? "");

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtGST"].Value?.ToString() ?? "");

                                table.Cell().Border(1).Padding(3)
                                    .Text(row.Cells["txtAmount"].Value?.ToString() ?? "");
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
                            mainRow.ConstantItem(250).Column(summary =>
                            {
                                void AddRow(string title, string value)
                                {
                                    summary.Item().Row(row =>
                                    {
                                        row.RelativeItem().Text(title).Bold();
                                        row.ConstantItem(80).AlignRight().Text(value);
                                    });
                                }

                                AddRow("Sub Total", SubTotal.ToString("0.00"));
                                AddRow("Discount", TotalDiscount.ToString("0.00"));
                                AddRow("SGST @ 9%", SGST9.ToString("0.00"));
                                AddRow("CGST @ 9%", CGST9.ToString("0.00"));
                                AddRow("Total", Total.ToString("0.00"));
                                AddRow("Received", Received.ToString("0.00"));
                                AddRow("Balance", Balance.ToString("0.00"));
                                AddRow("You Saved", Saved.ToString("0.00"));
                            });
                        });

                        col.Item().PaddingTop(15);

                        col.Item().PaddingTop(20);

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

                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.Span("Thank you for your business!").SemiBold();
                        });
                });
            }).GeneratePdf();

            // Save PDF
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveDialog.FileName = "Invoice.pdf";

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
        }
        private void CalculateSummary()
        {
            //SubTotal = 0;
            //TotalDiscount = 0;
            //SGST25 = 0;
            //CGST25 = 0;
            //SGST9 = 0;
            //CGST9 = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow)
                    continue;

                decimal qty = Convert.ToDecimal(row.Cells["txtQty"].Value ?? 0);
                decimal price = Convert.ToDecimal(row.Cells["txtPrice"].Value ?? 0);
                decimal discount = Convert.ToDecimal(row.Cells["txtDiscount"].Value ?? 0);
                decimal gst = Convert.ToDecimal(row.Cells["txtGST"].Value ?? 0);

                decimal baseAmount = qty * price;

                decimal discountAmt = baseAmount * discount / 100;
                TotalDiscount += discountAmt;

                decimal taxableAmount = baseAmount - discountAmt;

                SubTotal += taxableAmount;

                if (gst > 0)
                {
                    //SGST25 += taxableAmount * 2.5m / 100;
                    //CGST25 += taxableAmount * 2.5m / 100;

                    SGST9 += taxableAmount * 9m / 100;
                    CGST9 += taxableAmount * 9m / 100;
                }
            }

            Saved = TotalDiscount;

            decimal grandTotal =
                SubTotal +
                SGST25 +
                CGST25 +
                SGST9 +
                CGST9;

            decimal.TryParse(Received.ToString(), out Received);

            Balance = grandTotal - Received;
            Total = grandTotal;
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

        private void lblMainHeader_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
