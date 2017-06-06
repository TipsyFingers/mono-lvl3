using AutoMapper;
using mono_lvl3.WebAPI.ViewModels;
using mono_lvl3.Model.DomainModels;

namespace mono_lvl3.WebAPI.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<ArtistViewModel, ArtistPOCO>().ReverseMap();
        }
    }
}