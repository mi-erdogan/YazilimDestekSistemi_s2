namespace YazilimDestekSistemi.UI.Win.Arayuzler
{
    public interface IStatusBarKisaYol : IStatusBarAciklama
    {
        string StatusBarKisaYol { get; set; }
        string StatusBarKisaYolAciklama { get; set; }
    }
}