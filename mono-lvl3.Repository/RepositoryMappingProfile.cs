using AutoMapper;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Models.DomainModels;

namespace mono_lvl3.Repository
{
    public class RepositoryMappingProfile : Profile
    {
        public RepositoryMappingProfile()
        {
            CreateMap<Album, AlbumDomainModel>().ReverseMap();
            CreateMap<Artist, ArtistDomainModel>().ReverseMap();
            CreateMap<Song, SongDomainModel>().ReverseMap();
        }
    }
}
