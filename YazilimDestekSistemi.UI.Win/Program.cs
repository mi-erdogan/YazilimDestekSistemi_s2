using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazilimDestekSistemi.UI.Win.Formlar;
using YazilimDestekSistemi.UI.Win.Formlar.Genel;
using YazilimDestekSistemi.UI.Win.Formlar.Genel.TemelFormlar;
using NLog;

namespace YazilimDestekSistemi.UI.Win
{
    internal static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                LogManager.LoadConfiguration("nlog.config");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmYDS_G_SistemGiris());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Uygulama beklenmeyen bir hatayla sonlandı.");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}