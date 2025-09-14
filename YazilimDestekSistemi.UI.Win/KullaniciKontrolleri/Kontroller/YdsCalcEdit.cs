using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Drawing;
using YazilimDestekSistemi.UI.Win.Arayuzler;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsCalcEdit : CalcEdit, IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public YdsCalcEdit()
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

            // Asla Null olamaz. Bir Rakam olmak zorunda
            Properties.AllowNullInput = DefaultBoolean.False;

            // binlik haneleri ayırıp, virgülden sonra 2 hane işlem yapılabilir.
            Properties.EditMask = "n2";

            Properties.LookAndFeel.UseDefaultLookAndFeel = false;

            Properties.AutoHeight = false;
            Size = new Size(100, 32);

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        // Enter'e basıldığında bir sonraki kontrole geçmesini sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol'dan Implament edildi.
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Hesap Makinesini açınız.";
        public string StatusBarAciklama { get; set; }
        public bool Temizlenebilir { get; set; } = true;
    }
}