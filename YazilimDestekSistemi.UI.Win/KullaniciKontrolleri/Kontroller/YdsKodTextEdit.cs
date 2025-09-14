using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsKodTextEdit : YdsTextEdit
    {
        [ToolboxItem(true)]
        public YdsKodTextEdit()
        {
            Properties.BorderStyle = BorderStyles.Simple;
            Properties.ReadOnly = true;
            // Normal Arka Plan Rengi
            Properties.Appearance.BackColor = Color.PaleVioletRed;
            Properties.Appearance.BorderColor = Color.DarkRed;
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.Properties.Appearance.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);
            this.Properties.Appearance.ForeColor = Color.Black;

            // Üzerine gelindiğinde Arka Plan Rengi
            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 224, 192);
            Properties.AppearanceFocused.BorderColor = Color.FromArgb(255, 128, 0);
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.Properties.Appearance.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);
            this.Properties.Appearance.ForeColor = Color.Black;

            // ReadOnly olduğu zaman Arka Plan Rengi
            Properties.Appearance.BackColor = Color.PaleVioletRed;
            Properties.Appearance.BorderColor = Color.DarkRed;
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.Properties.Appearance.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);
            this.Properties.Appearance.ForeColor = Color.Black;

            StatusBarAciklama = "Kod Bilgisini Giriniz.";

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
    }
}