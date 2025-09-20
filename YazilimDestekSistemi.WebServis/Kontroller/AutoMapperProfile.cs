using AutoMapper;
using YazilimDestekSistemi.Model.Dto.SistemYonetimi;
using YazilimDestekSistemi.Model.Veriler.SistemYonetimi;

namespace YazilimDestekSistemi.WebServis.Kontroller
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            #region Sistem Yönetimi 

            CreateMap<SY_Kullanici, SY_KullaniciL>()
                .ForMember(dest => dest.KullaniciGrupAdi, opt => opt.MapFrom(src => src.SY_KullaniciGrup.KullaniciGrupAdi));
            
            #endregion
        }
    }
}
