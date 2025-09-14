using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Drawing;
using YazilimDestekSistemi.UI.Win.Arayuzler;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsBaslikTextEdit : TextEdit, IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public YdsBaslikTextEdit()
        {
            Properties.Appearance.BackColor = Color.FromArgb(192, 255, 192);
            Properties.Appearance.BorderColor = Color.LimeGreen;
            this.Properties.Appearance.Font = new Font(new FontFamily("Kelly Slab"), 13f, FontStyle.Bold);
            this.Properties.Appearance.ForeColor = Color.Black;

            Properties.AppearanceDisabled.BackColor = Color.FromArgb(192, 255, 192);
            Properties.AppearanceDisabled.BorderColor = Color.LimeGreen;
            this.Properties.AppearanceDisabled.Font = new Font(new FontFamily("Kelly Slab"), 13f, FontStyle.Bold);
            this.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.ForeColor = Color.Black;
            BorderStyle = BorderStyles.Simple;
            Enabled = false;
            this.TabStop = false;
            Size = new Size(125, 32);
            this.Name = "ydsB";
            this.Text = "Başlık";

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        // Enter'e basıldığında bir sonraki kontrole geçmesini sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarAciklama'dan Implament edildi.
        public string StatusBarAciklama { get; set; }

        public string TabloKolonDegeri { get; set; }

        public bool Temizlenebilir { get; set; } = false;
    }
}