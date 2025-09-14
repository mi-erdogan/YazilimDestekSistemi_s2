using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using YazilimDestekSistemi.Bll.Arayuzler;
using YazilimDestekSistemi.Bll.Temel;
using YazilimDestekSistemi.Common.Fonksiyonlar;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.Data.Baglamlar;
using YazilimDestekSistemi.Model.Dto.SistemYonetimi;
using YazilimDestekSistemi.Model.Veriler.SistemYonetimi;
using YazilimDestekSistemi.Model.Veriler.Temel;

namespace YazilimDestekSistemi.Bll.Genel.SistemYonetimi
{
    public class SY_KullaniciBll : TemelBll<SY_Kullanici, YdsBaglam>, ITemelGenelBll
    {
        public SY_KullaniciBll()
        {

        }

        public SY_KullaniciBll(Control ctrl) : base(ctrl)
        {

        }

        public TemelVeri Tekil(Expression<Func<SY_Kullanici, bool>> filtre)
        {
            return TemelTekil(filtre, x => x);
            //return TemelTekil(filtre, x => new SY_KullaniciT
            //{
            //    Id = x.Id,
            //    Kod = x.Kod,
            //    KullaniciAdi = x.KullaniciAdi,
            //    Sifre = x.Sifre,
            //    Adi = x.Adi,
            //    Soyadi = x.Soyadi,
            //    YetkiSeviyesi = x.YetkiSeviyesi,
            //    PinKodu = x.PinKodu,
            //    Domain = x.Domain,
            //    DomainKullaniciAdi = x.DomainKullaniciAdi,
            //    DomainKullaniciSifre = x.DomainKullaniciSifre,
            //    EPostaAdresi = x.EPostaAdresi,
            //    Telefon = x.Telefon,
            //    Dahili = x.Dahili,
            //    CepTelefonu = x.CepTelefonu,
            //    KisaKod = x.KisaKod,
            //    SY_KullaniciGrupId = x.SY_KullaniciGrupId,
            //    KullaniciGrupAdi = x.SY_KullaniciGrup.KullaniciGrupAdi,
            //    Aciklama = x.Aciklama,
            //    KayitEdenId = x.KayitEdenId,
            //    KayitTarihi = x.KayitTarihi,
            //    DegistirenId = x.DegistirenId,
            //    DegisimTarihi = x.DegisimTarihi,
            //    Surum = x.Surum,
            //    Durum = x.Durum
            //});
        }

        public IEnumerable<TemelVeri> Liste(Expression<Func<SY_Kullanici, bool>> filtre)
        {
            //return TemelListe(filtre, x => x).OrderBy(x => x.Kod).ToList();
            // Veritabanı bağlamını kullanarak filtreyi uygula
            //var sorgu = SY_Kullanici
            //                    .Include(x => x.SY_KullaniciGrup) // İlişkili tabloyu dahil et
            //                    .Where(filtre);

            //// Verileri bellek ortamına al ve dönüştür
            //var sonuc = sorgu.AsEnumerable() // Artık veriler bellek üzerinde işlenecek
            //               .Select(x => new SY_KullaniciL
            //               {
            //                   Id = x.Id,
            //                   Kod = x.Kod,
            //                   KullaniciAdi = x.KullaniciAdi,
            //                   Sifre = x.Sifre,
            //                   Adi = x.Adi,
            //                   Soyadi = x.Soyadi,
            //                   YetkiSeviyesi = x.YetkiSeviyesi,
            //                   PinKodu = x.PinKodu,
            //                   Domain = x.Domain,
            //                   DomainKullaniciAdi = x.DomainKullaniciAdi,
            //                   DomainKullaniciSifre = x.DomainKullaniciSifre,
            //                   EPostaAdresi = x.EPostaAdresi,
            //                   Telefon = x.Telefon,
            //                   Dahili = x.Dahili,
            //                   CepTelefonu = x.CepTelefonu,
            //                   KisaKod = x.KisaKod,
            //                   SY_KullaniciGrupId = x.SY_KullaniciGrupId,
            //                   KullaniciGrupAdi = x.SY_KullaniciGrup?.KullaniciGrupAdi, // Null kontrolü ile
            //                   Aciklama = x.Aciklama,
            //                   KayitEdenId = x.KayitEdenId,
            //                   KayitTarihi = x.KayitTarihi,
            //                   DegistirenId = x.DegistirenId,
            //                   DegisimTarihi = x.DegisimTarihi,
            //                   Surum = x.Surum,
            //                   Durum = x.Durum
            //               })
            //               .OrderBy(x => x.Kod) // Kod'a göre sırala
            //               .ToList(); // Listeye dönüştür

            //return sonuc;

            return TemelListe(filtre, x => new SY_KullaniciL
            {
                Id = x.Id,
                Kod = x.Kod,
                KullaniciAdi = x.KullaniciAdi,
                Sifre = x.Sifre,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                YetkiSeviyesi = x.YetkiSeviyesi,
                PinKodu = x.PinKodu,
                Domain = x.Domain,
                DomainKullaniciAdi = x.DomainKullaniciAdi,
                DomainKullaniciSifre = x.DomainKullaniciSifre,
                EPostaAdresi = x.EPostaAdresi,
                Telefon = x.Telefon,
                Dahili = x.Dahili,
                CepTelefonu = x.CepTelefonu,
                KisaKod = x.KisaKod,
                SY_KullaniciGrupId = x.SY_KullaniciGrupId,
                KullaniciGrupAdi = x.SY_KullaniciGrup.KullaniciGrupAdi, // Null kontrolü ile
                Aciklama = x.Aciklama,
                KayitEdenId = x.KayitEdenId,
                KayitTarihi = x.KayitTarihi,
                DegistirenId = x.DegistirenId,
                DegisimTarihi = x.DegisimTarihi,
                Surum = x.Surum,
                Durum = x.Durum
            }).OrderBy(x => x.Kod).ToList();
        }

        public bool Ekle(TemelVeri veri, Expression<Func<SY_Kullanici, bool>> filtre)
        {
            return TemelEkle(veri, filtre);
        }

        public bool Guncelle(TemelVeri eskiDeger, TemelVeri yeniDeger, Expression<Func<SY_Kullanici, bool>> filtre)
        {
            return TemelGuncelle(eskiDeger, yeniDeger, filtre);
        }

        public bool Sil(TemelVeri veri)
        {
            return TemelSil(veri, KartTuru.KullaniciGrup, KartTuruYetkiKod.KullaniciGrup.NumaralandirmaAdi(), KartTuru.KullaniciGrup.NumaralandirmaAdi());
        }

        public string YeniKodVer(Expression<Func<SY_Kullanici, bool>> filtre)
        {
            return TemelYeniKodVer(KartTuruKodOnEk.KullaniciGrup, x => x.Kod, filtre);
        }

        public bool Ekle(TemelVeri veri)
        {
            return TemelEkle(veri, x => x.Kod == veri.Kod);
        }

        public bool Guncelle(TemelVeri eskiDeger, TemelVeri yeniDeger)
        {
            return TemelGuncelle(eskiDeger, yeniDeger, x => x.Kod == eskiDeger.Kod);
        }

        public string YeniKodVer()
        {
            return TemelYeniKodVer(KartTuruKodOnEk.KullaniciGrup, x => x.Kod);
        }
    }
}