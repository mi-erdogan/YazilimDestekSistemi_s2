using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Drawing;
using YazilimDestekSistemi.UI.Win.Arayuzler;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsCheckedComboBoxEdit : CheckedComboBoxEdit, IStatusBarKisaYol
    {
        [ToolboxItem(true)]
        public YdsCheckedComboBoxEdit()
        {
            Properties.BorderStyle = BorderStyles.Simple;

            // Text Edit kısmında yazı yazılmasını engeller
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            // Normal Arka Plan Rengi
            Properties.Appearance.BackColor = Color.LightYellow;
            Properties.Appearance.BorderColor = Color.Gold;

            // Üzerine gelindiğinde Arka Plan Rengi
            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 224, 192);
            Properties.AppearanceFocused.BorderColor = Color.FromArgb(255, 128, 0);

            // ReadOnly olduğu zaman Arka Plan Rengi
            Properties.AppearanceReadOnly.BackColor = Color.LightCyan;
            Properties.AppearanceReadOnly.BorderColor = Color.FromArgb(0, 192, 192);

            Properties.LookAndFeel.UseDefaultLookAndFeel = false;

            Properties.AutoHeight = false;
            Size = new Size(100, 32);

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        // Enter'e basıldığında bir sonraki kontrole geçmesini sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol'dan Implament edildi.
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        public bool Temizlenebilir { get; set; } = true;
        public string TabloDegeri { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}