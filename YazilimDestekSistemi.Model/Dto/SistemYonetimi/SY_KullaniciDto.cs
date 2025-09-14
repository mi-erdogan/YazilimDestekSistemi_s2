using System.ComponentModel.DataAnnotations.Schema;
using YazilimDestekSistemi.Model.Veriler.SistemYonetimi;
using YazilimDestekSistemi.Model.Veriler.Temel;

namespace YazilimDestekSistemi.Model.Dto.SistemYonetimi
{
    [NotMapped]
    public class SY_KullaniciT : SY_Kullanici
    {
        public string KullaniciGrupAdi { get; set; }
    }
    [NotMapped]
    public class SY_KullaniciL : SY_KullaniciT
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int PinKodu { get; set; }
        public int YetkiSeviyesi { get; set; }
        public string Domain { get; set; }
        public string DomainKullaniciAdi { get; set; }
        public string DomainKullaniciSifre { get; set; }
        public string EPostaAdresi { get; set; }
        public string Telefon { get; set; }
        public string Dahili { get; set; }
        public string CepTelefonu { get; set; }
        public string KisaKod { get; set; }
        public long? SY_KullaniciGrupId { get; set; }
        public string KullaniciGrupAdi { get; set; }
    }
}