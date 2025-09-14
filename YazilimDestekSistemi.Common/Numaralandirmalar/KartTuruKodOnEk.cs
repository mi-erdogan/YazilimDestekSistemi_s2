using System.ComponentModel;

namespace YazilimDestekSistemi.Common.Numaralandirmalar
{
    public enum KartTuruKodOnEk
    {
        [Description("Kullanıcı")]
        Kullanici = 1,

        [Description("Kullanıcı Grup")]
        KullaniciGrup = 2,

        [Description("İlçe")]
        Ilce = 3,

        [Description("Ülke")]
        Ulke = 4,
    }
}