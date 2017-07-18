using AutoMapper;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using System;

namespace mono_lvl3.Model.Mapping
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Artist, ArtistDomainModel>().ReverseMap().PreserveReferences();
            CreateMap<Artist, IArtist>().ReverseMap().PreserveReferences();
            CreateMap<IArtist, ArtistDomainModel>().ReverseMap().PreserveReferences();

            CreateMap<Album, AlbumDomainModel>().ReverseMap().PreserveReferences();
            CreateMap<Album, IAlbum>().ReverseMap().PreserveReferences();
            CreateMap<IAlbum, AlbumDomainModel>().ReverseMap().PreserveReferences();

            CreateMap<Song, SongDomainModel>().ReverseMap().PreserveReferences();
            CreateMap<Song, ISong>().ReverseMap().PreserveReferences();
            CreateMap<ISong, SongDomainModel>().ReverseMap().PreserveReferences();
        }
    }
}
