using YazilimDestekSistemi.Model.Veriler.Temel;

namespace YazilimDestekSistemi.Bll.Arayuzler
{
    public interface ITemelGenelBll
    {
        bool Ekle(TemelVeri veri);
        bool Guncelle(TemelVeri eskiDeger, TemelVeri yeniDeger);
        string YeniKodVer();
    }
}