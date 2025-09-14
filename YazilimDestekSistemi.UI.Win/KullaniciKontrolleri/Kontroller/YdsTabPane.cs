using DevExpress.XtraBars.Navigation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    [ToolboxItem(true)]
    public class YdsTabPane : TabPane
    {
        [ToolboxItem(true)]
        public YdsTabPane()
        {
            this.Dock = DockStyle.Fill;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.SkinName = "DevExpress Style";


            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            AppearanceButton.Normal.ForeColor = Color.Black;
            AppearanceButton.Normal.Font = new Font(this.Appearance.Font, FontStyle.Bold);
            AppearanceButton.Normal.Font = new Font("Kelly Slab", 15);

            AppearanceButton.Hovered.ForeColor = Color.DarkRed;
            AppearanceButton.Hovered.Font = new Font(this.Appearance.Font, FontStyle.Regular);
            AppearanceButton.Hovered.Font = new Font("Jura", 15);

            AppearanceButton.Pressed.ForeColor = Color.DarkRed;
            AppearanceButton.Pressed.Font = new Font(this.Appearance.Font, FontStyle.Bold);
            AppearanceButton.Pressed.Font = new Font("Kelly Slab", 15);

            this.SelectedPageChanged += YdsTabPane_SelectedPageChanged; // Seçili sayfa değiştiğinde olayı dinlemek için

            // Default olarak oluşturulan sayfaları kaldırmak için
            if (Pages.Count > 0)
            {
                List<TabNavigationPage> pagesToRemove = new List<TabNavigationPage>((IEnumerable<TabNavigationPage>)Pages); // Koleksiyonu kopyala

                foreach (TabNavigationPage page in pagesToRemove)
                {
                    Pages.Remove(page);
                }
            }


            //// Constructor içinde sayfa oluşturulması
            //TabNavigationPage pageGenelBilgiler = new TabNavigationPage();
            //pageGenelBilgiler.Caption = "Genel Bilgiler";
            //pageGenelBilgiler.Name = "tnpGenelBilgiler";
            //pageGenelBilgiler.Properties.ShowMode = ItemShowMode.ImageAndText;
            //this.Pages.Add(pageGenelBilgiler);
            //this.SelectedPage = pageGenelBilgiler;

            //TabNavigationPage pageOzelKodBilgileri = new TabNavigationPage();
            //pageOzelKodBilgileri.Caption = "Özel Kod Bilgileri";
            //pageOzelKodBilgileri.Name = "tnpOzelKodBilgileri";
            //pageOzelKodBilgileri.Properties.ShowMode = ItemShowMode.ImageAndText;
            //this.Pages.Add(pageOzelKodBilgileri);
        }

        private void YdsTabPane_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
           
        }
    }
}