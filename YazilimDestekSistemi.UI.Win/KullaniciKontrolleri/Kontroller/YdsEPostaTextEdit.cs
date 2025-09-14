using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;
using System.Drawing;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    public class YdsEPostaTextEdit : YdsTextEdit
    {
        [ToolboxItem(true)]
        public YdsEPostaTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.RegEx;
            // Sola yatık slashı \ tanıması için başına @ işareti koyuyoruz. d değer, ? null olabilir.
            Properties.Mask.EditMask = @"((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_-])+)+";
            // Otomatik tamamlamayı kapat. 
            Properties.Mask.AutoComplete = AutoCompleteType.Strong;
            StatusBarAciklama = "E-Posta Adresi Bilgisini Giriniz.";
            Properties.AutoHeight = false;
            Size = new Size(125, 32);

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
    }
}