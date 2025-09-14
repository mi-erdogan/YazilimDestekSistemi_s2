using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;
using System.Drawing;
using YazilimDestekSistemi.UI.Win.Arayuzler;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsDateEdit : DateEdit, IStatusBarKisaYol
    {
        [ToolboxItem(true)]
        public YdsDateEdit()
        {
            Properties.BorderStyle = BorderStyles.Simple;

            // Normal Arka Plan Rengi
            Properties.Appearance.BackColor = Color.LightYellow;
            Properties.Appearance.BorderColor = Color.Gold;

            // Üzerine gelindiğinde Arka Plan Rengi
            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 224, 192);
            Properties.AppearanceFocused.BorderColor = Color.FromArgb(255, 128, 0);

            // ReadOnly olduğu zaman Arka Plan Rengi
            Properties.AppearanceReadOnly.BackColor = Color.LightCyan;
            Properties.AppearanceReadOnly.BorderColor = Color.FromArgb(0, 192, 192);

            Properties.AllowNullInput = DefaultBoolean.False;

            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;

            // Tarihi girdikçe gün ay yıl a otomatik geçiş
            Properties.Mask.MaskType = MaskType.DateTimeAdvancingCaret;

            Properties.LookAndFeel.UseDefaultLookAndFeel = false;

            Properties.AutoHeight = false;
            Size = new Size(100, 32);

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
        // Enter'e basıldığında bir sonraki kontrole geçmesini sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol'dan Implament edildi.
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Tarih Seçiniz.";
        public string StatusBarAciklama { get; set; }

        public bool Temizlenebilir { get; set; } = true;
    }
}