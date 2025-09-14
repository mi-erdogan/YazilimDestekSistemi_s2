using System;
using System.Linq;
using YazilimDestekSistemi.Model.Veriler.Temel.Arayuzler;

namespace YazilimDestekSistemi.Bll.Fonksiyonlar
{
    public static class Donustur
    {
        public static THedef VeriDonustur<THedef>(this ITemelVeri kaynak)
        {
            if (kaynak == null) return default(THedef);

            var hedef = Activator.CreateInstance<THedef>();
            var kaynakProp = kaynak.GetType().GetProperties();
            var hedefProp = typeof(THedef).GetProperties();

            foreach (var kp in kaynakProp)
            {
                var deger = kp.GetValue(kaynak);
                var hp = hedefProp.FirstOrDefault(x => x.Name == kp.Name);
                if (hp != null)
                    hp.SetValue(hedef, ReferenceEquals(deger, "") ? null : deger); // Gelen Veri "" Tırnak ise null olarak aktar.
            }

            return hedef;
        }
    }
}