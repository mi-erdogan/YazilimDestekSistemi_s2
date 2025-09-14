using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using YazilimDestekSistemi.UI.Win.Arayuzler;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsButtonEdit : ButtonEdit, IStatusBarKisaYol
    {
        public YdsButtonEdit()
        {
            Properties.BorderStyle = BorderStyles.Simple;

            // Text Edit kısmında yazı yazılmasını engeller
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            // Normal Arka Plan Rengi
            Properties.Appearance.BackColor = Color.LightYellow;
            Properties.Appearance.BorderColor = Color.Gold;
            Properties.Appearance.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);
            // Üzerine gelindiğinde Arka Plan Rengi
            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 224, 192);
            Properties.AppearanceFocused.BorderColor = Color.FromArgb(255, 128, 0);
            Properties.AppearanceFocused.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);
            // ReadOnly olduğu zaman Arka Plan Rengi
            Properties.AppearanceReadOnly.BackColor = Color.LightCyan;
            Properties.AppearanceReadOnly.BorderColor = Color.FromArgb(0, 192, 192);
            Properties.AppearanceReadOnly.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);

            // 0. İndexte yer alan buton (ilk buton) iconunu Mercek Yap
            this.Properties.Buttons[0].Kind = ButtonPredefines.Search;

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
        public string TabloKolonDegeri { get; set; }

        #region Eventler

        private long? _id;

        [Browsable(false)] // Properties kısmında gösterme
        public long? Id
        {
            get => _id; // get { return _id } return yerine => kullanıyoruz. Süslü paranteze de gerek kalmıyor.
            set
            {
                var eskiDeger = _id;
                var yeniDeger = value;

                if (yeniDeger == eskiDeger) return;

                _id = value;

                IdChanced?.Invoke(this, new IdChancedEventArgs(eskiDeger, yeniDeger)); // IdChanced null değilse (?) Invoke Çağır, çağırıyor.
            }
        }

        

        public event EventHandler<IdChancedEventArgs> IdChanced = delegate { }; // IdChancedEventArgs Null olmamasını sağlıyor. delegate fonksiyonu 

        #endregion
    }

    public class IdChancedEventArgs : EventArgs
    {
        public IdChancedEventArgs(long? eskiDeger, long? yeniDeger)
        {
            EskiDeger = eskiDeger;
            YeniDeger = yeniDeger;
        }

        public long? EskiDeger { get; }
        public long? YeniDeger { get; }

    }
}