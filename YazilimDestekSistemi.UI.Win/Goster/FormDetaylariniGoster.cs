using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.Model.Veriler.Temel;
using YazilimDestekSistemi.UI.Win.Formlar.Genel.TemelFormlar;
using YazilimDestekSistemi.UI.Win.Goster.Temel;

namespace YazilimDestekSistemi.UI.Win.Goster
{
    public class FormDetaylariniGoster<TForm> : ITemelFormDetayGoster where TForm : frmYDS_G_TF_TemelIslemFormu
    {
        public long DuzenlemeFormunuOndeGoster(KartTuru kartTuru, long id) //// , params object[] prm) 
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.IslemTuru = id > 0 ? IslemTuru.VeriGuncelleme : IslemTuru.VeriEkleme;
                frm.Id = id;
                frm.Yukle();

                frm.ShowDialog();
                return frm.YenilemeYapilacak ? frm.Id : 0;
            }
        }

        public long DuzenlemeFormunuOndeGoster(KartTuru kartTuru, long id, params object[] prm)
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.IslemTuru = id > 0 ? IslemTuru.VeriGuncelleme : IslemTuru.VeriEkleme;
                frm.Id = id;
                frm.Yukle();

                frm.ShowDialog();
                return frm.YenilemeYapilacak ? frm.Id : 0;
            }
        }

        public class SecimSonucu
        {
            public long Id { get; set; }
            public string Adi { get; set; }
        }


        public static TemelVeri ListeFormunuEnOndeGoster(KartTuru kartTuru, long? seciliGelecekId, params object[] prm)
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.SeciliGelecekId = seciliGelecekId;
                frm.Yukle();
                frm.ShowDialog();

                return frm.DialogResult == DialogResult.OK ? frm.SecilenVeri : null;
            }
        }

        public SecimSonucu ListeFormunuOndeGoster(KartTuru kartTuru) //// , params object[] prm) 
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.Yukle();

                frm.ShowDialog();

                return new SecimSonucu
                {
                    Id = frm.Id,
                    Adi = frm.Adi // Eğer `Adi` yoksa, form sınıfına eklemelisin
                };
            }
        }
    }
}
