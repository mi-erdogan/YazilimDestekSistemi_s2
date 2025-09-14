using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YazilimDestekSistemi.Model.Veriler.Temel;

namespace YazilimDestekSistemi.Model.Veriler.SistemYonetimi
{
    public class SY_KullaniciGrup : TemelVeri
    {

        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(250)]
        public string KullaniciGrupAdi { get; set; }

        public int YetkiSeviyesi { get; set; }
    }
}