using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Drawing;
using YazilimDestekSistemi.UI.Win.Arayuzler;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsMemoEdit : MemoEdit, IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public YdsMemoEdit()
        {
            Properties.BorderStyle = BorderStyles.Simple;
            // Normal Arka Plan Rengi
            Properties.Appearance.BackColor = Color.LightYellow;
            Properties.Appearance.BorderColor = Color.Gold;
            this.Properties.Appearance.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);

            // Üzerine gelindiğinde Arka Plan Rengi
            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 224, 192);
            Properties.AppearanceFocused.BorderColor = Color.FromArgb(255, 128, 0);
            this.Properties.AppearanceFocused.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);

            // ReadOnly olduğu zaman Arka Plan Rengi
            Properties.AppearanceReadOnly.BackColor = Color.LightCyan;
            Properties.AppearanceReadOnly.BorderColor = Color.FromArgb(0, 192, 192);
            this.Properties.AppearanceReadOnly.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);

            Properties.AutoHeight = false;
            Size = new Size(150, 64);

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
        // Enter'e basıldığında bir sonraki kontrole geçmesini sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarAciklama'dan Implament edildi.
        public string StatusBarAciklama { get; set; } = "Açıklama Bilgisini Giriniz.";
        public bool Temizlenebilir { get; set; } = true;
    }
}