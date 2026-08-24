using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductCRMAPI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                using (SaturdayPopup popup = new SaturdayPopup())
                {
                    popup.StartPosition = FormStartPosition.CenterScreen;
                    popup.ShowDialog();
                }
            }
            Application.Run(new Form1());
        }
    }
}
