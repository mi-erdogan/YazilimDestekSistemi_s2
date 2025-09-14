using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YazilimDestekSistemi.Model.Veriler.Temel.Arayuzler;

namespace YazilimDestekSistemi.Model.Veriler.Temel
{
    public class TemelVeri : ITemelVeri
    {
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // DatabaseGenerated(DatabaseGeneratedOption.None) Otomatik Artan ı kapat. Identity
        public long Id { get; set; }

        [Column(Order = 1), Required, StringLength(75)] // Required Zorunlu Alan, StringLength MaxKarakterAlani
        public virtual string Kod { get; set; } // virtual (İndexleme için)

        [StringLength(1500)]
        public string Aciklama { get; set; }
        public bool Durum { get; set; } = true;
        public long KayitEdenId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public long? DegistirenId { get; set; }
        public DateTime? DegisimTarihi { get; set; }
        public string Surum { get; set; }
    }
}