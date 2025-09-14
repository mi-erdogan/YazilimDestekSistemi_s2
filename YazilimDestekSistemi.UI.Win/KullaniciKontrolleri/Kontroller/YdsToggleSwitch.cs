using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Drawing;
using YazilimDestekSistemi.UI.Win.Arayuzler;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsToggleSwitch : ToggleSwitch, IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public YdsToggleSwitch()
        {
            Name = "tglDurum";

            Properties.OffText = "Pasif";
            Properties.OnText = "Aktif";
            Properties.AutoHeight = false;
            Properties.AutoWidth = true;
            Properties.GlyphAlignment = HorzAlignment.Far;
            Properties.Appearance.ForeColor = Color.Maroon;
            Properties.BorderStyle = BorderStyles.Simple;
            Properties.Appearance.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);
            Properties.AppearanceFocused.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);
            Properties.AppearanceReadOnly.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);
            Properties.AppearanceDisabled.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);

            // Normal Arka Plan Rengi
            Properties.Appearance.BackColor = Color.LightYellow;
            Properties.Appearance.BorderColor = Color.Gold;

            // Üzerine gelindiğinde Arka Plan Rengi
            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 224, 192);
            Properties.AppearanceFocused.BorderColor = Color.FromArgb(255, 128, 0);

            // ReadOnly olduğu zaman Arka Plan Rengi
            Properties.AppearanceReadOnly.BackColor = Color.LightCyan;
            Properties.AppearanceReadOnly.BorderColor = Color.FromArgb(0, 192, 192);

            Size = new Size(100, 24);

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        protected override void OnEditValueChanged()
        {
            base.OnEditValueChanged();

            if (this.IsOn == true) { Properties.Appearance.ForeColor = Color.DarkGreen; }

            else { Properties.Appearance.ForeColor = Color.Maroon; }
        }

        // Enter'e basıldığında bir sonraki kontrole geçmesini sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarAciklama'dan Implament edildi.
        public string StatusBarAciklama { get; set; } = "Kartın Kullanım Durumu Bilgisini Seçiniz.";
        public bool Temizlenebilir { get; set; } = true;
    }
}