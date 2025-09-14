using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Drawing;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public  class YdsBaslikLabelControl : LabelControl
    {
        public YdsBaslikLabelControl()
        {
            Appearance.BackColor = Color.FromArgb(192, 255, 192);
            Appearance.BorderColor = Color.LimeGreen;
            this.Appearance.Font = new Font(this.Appearance.Font, FontStyle.Bold);
            this.ForeColor = Color.Black;
            AutoSizeMode = LabelAutoSizeMode.None;
            BackColor = Color.FromArgb(192, 255, 192);
            BorderStyle = BorderStyles.Simple;
            Size = new Size(125, 32);
            this.Text = " Baslik";

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
    }
}