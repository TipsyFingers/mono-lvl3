using Ninject.Modules;
using mono_lvl3.Service;
using mono_lvl3.Service.Common;

namespace mono_lvl3.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbumService>().To<AlbumService>();
            Bind<IArtistService>().To<ArtistService>();
            Bind<ISongService>().To<SongService>();
        }
    }
}
