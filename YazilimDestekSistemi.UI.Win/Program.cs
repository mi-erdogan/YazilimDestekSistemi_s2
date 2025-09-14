using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazilimDestekSistemi.UI.Win.Formlar;
using YazilimDestekSistemi.UI.Win.Formlar.Genel;
using YazilimDestekSistemi.UI.Win.Formlar.Genel.TemelFormlar;

namespace YazilimDestekSistemi.UI.Win
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
            Application.Run(new frmYDS_G_SistemGiris());
        }
    }
}