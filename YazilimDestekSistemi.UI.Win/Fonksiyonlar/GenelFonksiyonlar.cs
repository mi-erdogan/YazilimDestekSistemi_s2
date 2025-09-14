using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System;
using YazilimDestekSistemi.Common.MesajKutulari;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.Model.Veriler.Temel;
using YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller;

namespace YazilimDestekSistemi.UI.Win.Fonksiyonlar
{
    public static class GenelFonksiyonlar
    {
        public static long GetRowId(this GridView tablo)
        {
            if (tablo.FocusedRowHandle > -1)
                return (long)tablo.GetFocusedRowCellValue("Id");

            Mesajlar.HataMesaji("Veri satırı dışında bir alan seçilmiştir. Lütfen veri satırı olan bir alan seçiniz.");

            //frmMOS_G_MesajKutusu frmMOS_G_MK = new frmMOS_G_MesajKutusu(4, 1, "Uyarı Mesajı", "", "Mühür OS", " U00001", "Tablo Satır Seçmeme",
            //                                                                                                                                                                                                      " Seçilen Kart Bulunamadı",
            //                                                                                                                                                                                                      " Tabloda veri bulunmamaktadır." +
            //                                                                                                                                                                                                      Environment.NewLine +
            //                                                                                                                                                                                                      " Veri satırı dışında bir alan seçilmiştir.",
            //                                                                                                                                                                                                      " Veri satırı olan bir alan seçiniz.");
            //frmMOS_G_MK.ShowDialog();
            return -1;
        }

        public static T GetRow<T>(this GridView tablo, bool mesajVer = true)
        {
            if (tablo.FocusedRowHandle > -1)
                return (T)tablo.GetRow(tablo.FocusedRowHandle);

            if (mesajVer)
            {
                Mesajlar.HataMesaji("Veri satırı dışında bir alan seçilmiştir. Lütfen veri satırı olan bir alan seçiniz.");

                //frmMOS_G_MesajKutusu frmMOS_G_MK = new frmMOS_G_MesajKutusu(4, 1, "Uyarı Mesajı", "", "Mühür OS", " U00001", "Tablo Satır Seçmeme",
                //                                                                                                                                                                                                  " Seçilen Kart Bulunamadı",
                //                                                                                                                                                                                                  " Tabloda veri bulunmamaktadır." +
                //                                                                                                                                                                                                  Environment.NewLine +
                //                                                                                                                                                                                                  " Veri satırı dışında bir alan seçilmiştir.",
                //                                                                                                                                                                                                  " Veri satırı olan bir alan seçiniz.");
                //frmMOS_G_MK.ShowDialog();
            }

            return default(T);
        }
        private static VeriDegisimYeri VeriDegisimYeriGetir<T>(T eskiVeri, T yeniVeri)
        {
            foreach (var prop in yeniVeri.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic")
                {
                    continue;
                }
                var eskiDeger = prop.GetValue(eskiVeri) ?? string.Empty;
                var yeniDeger = prop.GetValue(yeniVeri) ?? string.Empty;

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(eskiDeger.ToString()))
                        eskiDeger = new byte[] { 0 };
                    if (string.IsNullOrEmpty(yeniDeger.ToString()))
                        yeniDeger = new byte[] { 0 };

                    if (((byte[])eskiDeger).Length != ((byte[])yeniDeger).Length)
                        return VeriDegisimYeri.Alan;
                }
                else if (!yeniDeger.Equals(eskiDeger))
                    return VeriDegisimYeri.Alan;
            }

            return VeriDegisimYeri.VeriDegisimiYok;
        }

        public static void EtkinButonDurumu<T>(YdsSimpleButton btnYeni, YdsSimpleButton btnDuzenle, YdsSimpleButton btnKaydet, YdsSimpleButton btnVazgec, T eskiVeri, T yeniVeri)
        {
            var veriDegisimYeri = VeriDegisimYeriGetir(eskiVeri, yeniVeri);
            var etkinButonDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;

            btnKaydet.Enabled = etkinButonDurumu;
            btnVazgec.Enabled = etkinButonDurumu;

            btnYeni.Enabled = !etkinButonDurumu;
            btnDuzenle.Enabled = !etkinButonDurumu;
        }

        public static long IdOlustur(this IslemTuru islemTuru, TemelVeri secilenVeri)
        {
            string SifirEkle(string deger)
            {
                if (deger.Length == 1)
                    return "0" + deger;
                return deger;
            }

            string UcBasamakYap(string deger)
            {
                switch (deger.Length)
                {
                    case 1:
                        return "00" + deger;
                    case 2:
                        return "0" + deger;
                }

                return deger;
            }

            string Id()
            {
                var yil = DateTime.Now.Date.Year.ToString();
                var ay = SifirEkle(DateTime.Now.Date.Month.ToString());
                var gun = SifirEkle(DateTime.Now.Date.Day.ToString());
                var saat = SifirEkle(DateTime.Now.Hour.ToString());
                var dakika = SifirEkle(DateTime.Now.Minute.ToString());
                var saniye = SifirEkle(DateTime.Now.Second.ToString());
                var miliSaniye = UcBasamakYap(DateTime.Now.Millisecond.ToString());
                var randomSayi = SifirEkle(new Random().Next(0, 99).ToString());

                return yil + ay + gun + saat + dakika + saniye + miliSaniye + randomSayi;
            }

            var id = Id();
            return islemTuru == IslemTuru.VeriGuncelleme ? secilenVeri.Id : long.Parse(Id());
        }
    }
}