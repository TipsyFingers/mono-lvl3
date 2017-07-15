using AutoMapper;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;

namespace mono_lvl3.Model.Mapping
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Artist, ArtistDomainModel>().ReverseMap();
            CreateMap<Artist, IArtist>().ReverseMap();
            CreateMap<IArtist, ArtistDomainModel>().ReverseMap();

            CreateMap<Album, AlbumDomainModel>().ReverseMap();
            CreateMap<Album, IAlbum>().ReverseMap();
            CreateMap<IAlbum, AlbumDomainModel>().ReverseMap();

            CreateMap<Song, SongDomainModel>().ReverseMap();
            CreateMap<Song, ISong>().ReverseMap();
            CreateMap<ISong, SongDomainModel>().ReverseMap();
        }
    }
}
