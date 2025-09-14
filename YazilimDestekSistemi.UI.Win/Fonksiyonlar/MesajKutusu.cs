using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace YazilimDestekSistemi.UI.Win.Fonksiyonlar
{
    public static class MesajKutusu
    {
        private static SvgImageCollection svgImageCollection = new SvgImageCollection();

        public static void Tamam(int? resim, string mesaj, string baslik, int otomatikKapanmaSuresiMiliSaniye)
        {
            Image icon;

            switch (resim)
            {
                case 1:
                    //icon = Properties.Resources.info_32x32; // Bilgi ikonu
                    break;
                case 2:
                    //icon = Properties.Resources.warning_32x32; // Uyarı ikonu
                    break;
                case 3:
                    //icon = Properties.Resources.error_32x32; // Hata ikonu
                    break;
                default:
                    //icon = Properties.Resources.info_32x32; // Hata ikon (opsiyonel)
                    break;
            }

            // Mesaj kutusu argümanlarını oluştur
            var args = new XtraMessageBoxArgs()
            {
                Caption = baslik,
                Text = mesaj,
                Buttons = new DialogResult[] { DialogResult.OK },
                DefaultButtonIndex = 0,
                ImageOptions = new MessageBoxImageOptions()
                {
                    //Image = icon
                },
                AutoCloseOptions = new AutoCloseOptions()
                {
                    Delay = otomatikKapanmaSuresiMiliSaniye, // Otomatik kapanma süresi (milisaniye cinsinden)
                    ShowTimerOnDefaultButton = true // Varsayılan buton üzerinde zamanlayıcı göstermek
                }
            };

            XtraMessageBox.Show(args);
        }

        public static DialogResult EvetSeciliEvetHayir(string mesaj, string baslik, int otomatikKapanmaSuresiMiliSaniye)
        {
            // Mesaj kutusu argümanlarını oluştur
            var args = new XtraMessageBoxArgs()
            {
                Caption = baslik,
                Text = mesaj,
                Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No },
                DefaultButtonIndex = 0, // "Evet" butonunu varsayılan olarak seçili yapar
                ImageOptions = new MessageBoxImageOptions()
                {
                    //SvgImage = svgImageCollection.Count > 0 ? svgImageCollection[0] : null, // SVG ikonunuzu burada ayarlayın
                    //SvgImageSize = new Size(32, 32)
                    Image = Properties.Resources.windows_32x32
                },
                AutoCloseOptions = new AutoCloseOptions()
                {
                    Delay = otomatikKapanmaSuresiMiliSaniye, // Otomatik kapanma süresi (milisaniye cinsinden)
                    ShowTimerOnDefaultButton = true // Varsayılan buton üzerinde zamanlayıcı göstermek
                }
            };

            return XtraMessageBox.Show(args);
        }

        public static DialogResult HayirSeciliEvetHayir(string mesaj, string baslik, int otomatikKapanmaSuresiMiliSaniye)
        {
            // Mesaj kutusu argümanlarını oluştur
            var args = new XtraMessageBoxArgs()
            {
                Caption = baslik,
                Text = mesaj,
                Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No },
                DefaultButtonIndex = 1,
                ImageOptions = new MessageBoxImageOptions()
                {
                    SvgImage = svgImageCollection.Count > 0 ? svgImageCollection[0] : null,
                    SvgImageSize = new Size(32, 32)
                },
                AutoCloseOptions = new AutoCloseOptions()
                {
                    Delay = otomatikKapanmaSuresiMiliSaniye,
                    ShowTimerOnDefaultButton = true
                }
            };

            return XtraMessageBox.Show(args);
        }
    }
}