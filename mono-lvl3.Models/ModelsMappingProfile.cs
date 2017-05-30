using AutoMapper;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Models.Common;
using mono_lvl3.Models.DomainModels;

namespace mono_lvl3.Models
{
    public class ModelsMappingProfile : Profile
    {
        public ModelsMappingProfile()
        {
            CreateMap<Album, AlbumPOCO>().ReverseMap();
            CreateMap<Album, IAlbum>().ReverseMap();
            CreateMap<IAlbum, AlbumPOCO>().ReverseMap();

            CreateMap<Artist, ArtistPOCO>().ReverseMap();
            CreateMap<Artist, IArtist>().ReverseMap();
            CreateMap<IArtist, ArtistPOCO>().ReverseMap();

            CreateMap<Song, SongPOCO>().ReverseMap();
            CreateMap<Song, ISong>().ReverseMap();
            CreateMap<ISong, SongPOCO>().ReverseMap();
        }
    }
}
