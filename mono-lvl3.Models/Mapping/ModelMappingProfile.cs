using AutoMapper;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Model.Mapping
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Artist, ArtistPOCO>().ReverseMap();
            CreateMap<Artist, IArtist>().ReverseMap();
            CreateMap<IArtist, ArtistPOCO>().ReverseMap();

            CreateMap<Album, AlbumPOCO>().ReverseMap();
            CreateMap<Album, IAlbum>().ReverseMap();
            CreateMap<IAlbum, AlbumPOCO>().ReverseMap();

            CreateMap<Song, SongPOCO>().ReverseMap();
            CreateMap<Song, ISong>().ReverseMap();
            CreateMap<ISong, SongPOCO>().ReverseMap();
        }
    }
}
