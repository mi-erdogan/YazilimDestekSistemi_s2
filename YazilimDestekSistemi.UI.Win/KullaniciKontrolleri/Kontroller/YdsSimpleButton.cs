using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsSimpleButton : SimpleButton
    {
        [ToolboxItem(true)]
        public YdsSimpleButton()
        {
            Appearance.ForeColor = Color.Maroon;
            this.Appearance.Font = new Font(this.Appearance.Font.FontFamily, 12F, FontStyle.Bold);
            Size = new Size(150, 32);
           

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        // IStatusBarAciklama'dan Implament edildi.
        public string StatusBarAciklama { get; set; }
    }
}