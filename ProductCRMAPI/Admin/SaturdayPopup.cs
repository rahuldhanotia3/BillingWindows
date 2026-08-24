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
    public partial class SaturdayPopup : Form
    {
        
        public SaturdayPopup()
        {
            InitializeComponent();
            this.Load += SaturdayPopup_Load;
            pictureBox1.Image = Properties.Resources.sunday;
        }
        private void SaturdayPopup_Load(object sender, EventArgs e)
        {
            
        }
        private void InitializeInvoiceGrid()
        {
            
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

        private void SaturdayPopup_Load_1(object sender, EventArgs e)
        {

        }

        private void lblMainHeader_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
