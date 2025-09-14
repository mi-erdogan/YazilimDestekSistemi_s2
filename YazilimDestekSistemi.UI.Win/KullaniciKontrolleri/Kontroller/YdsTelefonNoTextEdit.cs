using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;
using System.Drawing;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsTelefonNoTextEdit : YdsTextEdit
    {
        [ToolboxItem(true)]
        public YdsTelefonNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.Regular;
            // Sola yatık slashı \ tanıması için başına @ işareti koyuyoruz. d değer, ? null olabilir.
            Properties.Mask.EditMask = @"(\d?\d?\d?) \d?\d?\d? \d?\d? \d?\d?";
            // Otomatik tamamlamayı kapat. 
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "Telefon No Bilgisini Giriniz.";
            Properties.AutoHeight = false;
            Size = new Size(125, 32);

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
    }
}