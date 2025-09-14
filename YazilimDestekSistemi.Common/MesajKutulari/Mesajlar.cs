using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace YazilimDestekSistemi.Common.MesajKutulari
{
    public class Mesajlar
    {
        public static void HataMesaji(string hataMesaji)
        {
            XtraMessageBox.Show(hataMesaji, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void UyariMesaji(string uyariMesaji)
        {
            XtraMessageBox.Show(uyariMesaji, "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult EvetSeciliEvetHayir(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult HayirSeciliEvetHayir(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult EvetSeciliEvetHayirIptal(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult HayirSeciliEvetHayirIptal(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult Sil(string kartAdi)
        {
            return HayirSeciliEvetHayir($"Seçtiğiniz {kartAdi} Silinecektir. Onaylıyor Musunuz :?", "Silme Onayı");
        }

        public static DialogResult KapanisMesaji()
        {
            return EvetSeciliEvetHayirIptal($"Yapılan Değişiklikler Kayıt Edilecektir. Onaylıyor Musunuz :?", "Çıkış Onayı");
        }

        public static DialogResult KayitMesaji()
        {
            return EvetSeciliEvetHayir($"Yapılan Değişiklikler Kayıt Edilecektir. Onaylıyor Musunuz :?", "Kayıt Onayı");
        }

        public static void KartSecmemeUyariMesaji()
        {
            UyariMesaji("Lütfen bir Kart seçiniz.");
        }


    }
}