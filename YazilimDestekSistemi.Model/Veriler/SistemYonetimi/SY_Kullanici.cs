using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YazilimDestekSistemi.Model.Veriler.Temel;

namespace YazilimDestekSistemi.Model.Veriler.SistemYonetimi
{
    public class SY_Kullanici : TemelVeri
    {

        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(250)]
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

        [ForeignKey("SY_KullaniciGrupId")]
        public SY_KullaniciGrup SY_KullaniciGrup { get; set; }
    }
}