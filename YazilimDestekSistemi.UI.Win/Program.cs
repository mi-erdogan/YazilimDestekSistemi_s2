using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using YazilimDestekSistemi.UI.Win.Formlar;
using YazilimDestekSistemi.UI.Win.Formlar.Genel;
using YazilimDestekSistemi.UI.Win.Formlar.Genel.TemelFormlar;
using NLog;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;

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

                // DevExpress global UI settings
                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                WindowsFormsSettings.ForceDirectXPaint();
                UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");

                // Optionally align default font for a consistent look
                WindowsFormsSettings.DefaultFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

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