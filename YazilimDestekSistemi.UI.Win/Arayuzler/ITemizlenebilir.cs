namespace YazilimDestekSistemi.UI.Win.Arayuzler
{
    public interface ITemizlenebilir : IStatusBarAciklama
    {
        bool Temizlenebilir { get; set; }
    }
}