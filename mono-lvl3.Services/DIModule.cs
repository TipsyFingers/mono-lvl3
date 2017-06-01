using mono_lvl3.Service.Common;
using Ninject.Modules;

namespace mono_lvl3.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArtistService>().To<ArtistService>();
            Bind<IAlbumService>().To<AlbumService>();
            Bind<ISongService>().To<SongService>();
        }
    }
}
