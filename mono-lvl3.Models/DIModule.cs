using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using Ninject.Modules;

namespace mono_lvl3.Model
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbum>().To<AlbumDomainModel>();
            Bind<IArtist>().To<ArtistDomainModel>();
            Bind<ISong>().To<SongDomainModel>();
        }
    }
}
