using AutoMapper;
using mono_lvl3.WebAPI.ViewModels;
using mono_lvl3.Model.DomainModels;
using mono_lvl3.Model.Common;

namespace mono_lvl3.WebAPI.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
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