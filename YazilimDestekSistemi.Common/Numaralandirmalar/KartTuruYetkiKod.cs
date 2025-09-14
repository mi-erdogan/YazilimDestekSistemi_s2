using System.ComponentModel;

namespace YazilimDestekSistemi.Common.Numaralandirmalar
{
    public enum KartTuruYetkiKod
    {
        [Description("500.1.001")]
        Kullanici = 1,

        [Description("500.2.001")]
        KullaniciGrup = 2,

        [Description("200.2.003")]
        Ilce = 3,

        [Description("200.2.001")]
        Ulke = 4,
    }
}