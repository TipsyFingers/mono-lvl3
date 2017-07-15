using AutoMapper;
using mono_lvl3.WebMVC.ViewModels;
using mono_lvl3.Model.DomainModels;
using mono_lvl3.Model.Common;

namespace mono_lvl3.WebMVC.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<ArtistViewModel, IArtist>().ReverseMap();
            CreateMap<ArtistViewModel, ArtistDomainModel>().ReverseMap();

            CreateMap<AlbumViewModel, IAlbum>().ReverseMap();
            CreateMap<AlbumViewModel, AlbumDomainModel>().ReverseMap();

            CreateMap<SongViewModel, ISong>().ReverseMap();
            CreateMap<SongViewModel, SongDomainModel>().ReverseMap();
        }
    }
}