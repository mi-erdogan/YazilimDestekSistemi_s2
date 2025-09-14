using System.ComponentModel;

namespace YazilimDestekSistemi.Common.Numaralandirmalar
{
    public enum KartTuru // : byte
    {
        [Description("Kullanıcı Kartı")]
        Kullanici = 1,

        [Description("Kullanıcı Grup Kartı")]
        KullaniciGrup = 2,

        [Description("İlçe Kartı")]
        Ilce = 3,

        [Description("Ülke Kartı")]
        Ulke = 4,
    }
}