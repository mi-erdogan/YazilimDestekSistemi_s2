using DevExpress.Utils;
using System.Drawing;

namespace YazilimDestekSistemi.UI.Win.Fonksiyonlar
{
    public class SuperToolTip
    {
        public static DevExpress.Utils.SuperToolTip SuperToolTipOlustur(string baslik, string aciklama)
        {
            // SuperToolTip nesnesini oluşturma
            DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();

            // Başlık oluşturma
            ToolTipTitleItem titleItem = new ToolTipTitleItem();
            titleItem.Text = baslik;
            titleItem.Appearance.Font = new Font("Kelly Slab", 11, FontStyle.Bold); // Yeni font ve kalın
                                                                                    // Başlık için bir resim ekleme (yourTitleImage değişkeni tanımlanmalı)
            titleItem.Image = Properties.Resources.comment_16x16;

            // Seperator oluşturma
            ToolTipSeparatorItem separatorItem = new ToolTipSeparatorItem();

            // İçerik oluşturma
            ToolTipItem contentItem = new ToolTipItem();
            // İçerik için bir resim ekleme (yourContentImage değişkeni tanımlanmalı)
            contentItem.Image = Properties.Resources.suggestion_16x16;
            contentItem.Text = aciklama;
            contentItem.Appearance.Font = new Font("Jura", 13, FontStyle.Bold);

            // Başlık, Separator ve İçerik öğelerini SuperToolTip'e ekleme
            superToolTip.Items.Add(titleItem);
            superToolTip.Items.Add(separatorItem);
            superToolTip.Items.Add(contentItem);

            // SuperToolTip nesnesini geri döndürme
            return superToolTip;
        }
    }
}