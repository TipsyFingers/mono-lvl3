using mono_lvl3.DAL.DbContext;
using mono_lvl3.Repository.Common;
using Ninject.Modules;
using Ninject.Extensions.Factory;

namespace mono_lvl3.Repository
{
    public class DIModule1 : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbumRepository>().To<AlbumRepository>();
            Bind<IArtistRepository>().To<ArtistRepository>();
            Bind<ISongRepository>().To<SongRepository>();
            Bind<IDataContext>().To<DataContext>(); 
            Bind<IGenericRepository>().To<GenericRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().ToFactory();
        }
    }
}
