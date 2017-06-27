using AutoMapper;
using mono_lvl3.Web_API.ViewModels;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;

namespace mono_lvl3.Web_API.Mapping
{
    public class WebAPIMappingProfile : Profile
    {
        public WebAPIMappingProfile()
        {
            CreateMap<ArtistViewModel, IArtist>().ReverseMap();
            CreateMap<ArtistViewModel, ArtistPOCO>().ReverseMap();

            CreateMap<AlbumViewModel, IAlbum>().ReverseMap();
            CreateMap<AlbumViewModel, AlbumPOCO>().ReverseMap();

            CreateMap<SongViewModel, ISong>().ReverseMap();
            CreateMap<SongViewModel, SongPOCO>().ReverseMap();
        }
    }
}