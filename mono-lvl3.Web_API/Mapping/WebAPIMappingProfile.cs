using AutoMapper;
using mono_lvl3.Web_API.ViewModels;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using System;

namespace mono_lvl3.Web_API.Mapping
{
    public class WebAPIMappingProfile : Profile
    {
        public WebAPIMappingProfile()
        {
            CreateMap<ArtistViewModel, IArtist>().ReverseMap();
            CreateMap<ArtistViewModel, ArtistDomainModel>().ReverseMap();

            CreateMap<AlbumViewModel, IAlbum>().ReverseMap();
            CreateMap<AlbumViewModel, AlbumDomainModel>().ReverseMap();

            CreateMap<SongViewModel, ISong>().ReverseMap();
            CreateMap<SongViewModel, SongDomainModel>().ReverseMap();

            CreateMap<IArtist, Guid>().ConstructUsing(src => src.Id);
            CreateMap<IAlbum, Guid>().ConstructUsing(src => src.Id);
            CreateMap<ISong, Guid>().ConstructUsing(src => src.Id);
        }
    }
}