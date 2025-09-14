using YazilimDestekSistemi.Common.Numaralandirmalar;

namespace YazilimDestekSistemi.UI.Win.Goster.Temel
{
    public interface ITemelFormDetayGoster
    {
        long DuzenlemeFormunuOndeGoster(KartTuru kartTuru, long id);
    }
}