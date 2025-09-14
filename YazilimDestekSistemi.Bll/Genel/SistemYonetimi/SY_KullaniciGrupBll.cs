using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazilimDestekSistemi.Bll.Arayuzler;
using YazilimDestekSistemi.Bll.Temel;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.Data.Baglamlar;
using YazilimDestekSistemi.Model.Veriler.SistemYonetimi;
using YazilimDestekSistemi.Model.Veriler.Temel;

namespace YazilimDestekSistemi.Bll.Genel.SistemYonetimi
{
    public class SY_KullaniciGrupBll : TemelBll<SY_KullaniciGrup, YdsBaglam>, ITemelGenelBll
    {
        public SY_KullaniciGrupBll()
        {

        }

        public SY_KullaniciGrupBll(Control ctrl) : base(ctrl)
        {

        }

        public TemelVeri Tekil(Expression<Func<SY_KullaniciGrup, bool>> filtre)
        {
            return TemelTekil(filtre, x => x); // Select * From // Tüm Verileri Getir.
        }

        public IEnumerable<TemelVeri> Liste(Expression<Func<SY_KullaniciGrup, bool>> filtre)
        {
            return TemelListe(filtre, x => x).OrderBy(x => x.Kod).ToList();
        }

        public bool Ekle(TemelVeri veri)
        {
            return TemelEkle(veri, x => x.Kod == veri.Kod);
        }

        public bool Guncelle(TemelVeri eskiDeger, TemelVeri yeniDeger)
        {
            return TemelGuncelle(eskiDeger, yeniDeger, x => x.Kod == eskiDeger.Kod);
        }

        public string YeniKodVer()
        {
            return TemelYeniKodVer(KartTuruKodOnEk.Kullanici, x => x.Kod);
        }
    }
}