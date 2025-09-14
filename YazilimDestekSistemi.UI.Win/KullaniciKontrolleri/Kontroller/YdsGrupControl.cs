using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Drawing;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    public class YdsGrupControl : GroupControl
    {
        [ToolboxItem(true)]
        public YdsGrupControl()
        {
            //Appearance.BackColor = Color.FromArgb(192, 255, 192);
            this.Appearance.Font = new Font(this.Appearance.Font, FontStyle.Bold);
            this.Appearance.ForeColor = Color.Black;

            AppearanceCaption.ForeColor = Color.Maroon;
            AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //this.AppearanceCaption.Font = new Font(this.AppearanceCaption.Font.FontFamily, 21F,  FontStyle.Bold);
            this.AppearanceCaption.Font = new Font("Kelly Slab", 21F, FontStyle.Bold);

            this.AppearanceCaption.Options.UseBackColor = true;
            this.AppearanceCaption.Options.UseForeColor = true;
            this.AppearanceCaption.Options.UseFont = true;
            BorderStyle = BorderStyles.Simple;
            GroupStyle = DevExpress.Utils.GroupStyle.Title;
            Size = new Size(125, 32);
            this.Name = "ydsGrupControl";
            this.Text = "Grup";

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
    }
}