using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsTcKimlikNoTextEdit : YdsTextEdit
    {
        [ToolboxItem(true)]
        public YdsTcKimlikNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.Regular;
            // Sola yatık slashı \ tanıması için başına @ işareti koyuyoruz. d değer, ? null olabilir.
            Properties.Mask.EditMask = @"\d?\d?\d? \d?\d?\d? \d?\d?\d? \d?\d?";
            // Otomatik tamamlamayı kapat. 
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "TC Kimlik No Bilgisini Giriniz.";
            Properties.MaxLength = 11; // 16 KartNo, 3 tane -
            Properties.AutoHeight = false;
            Size = new Size(110, 32);

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
    }
}