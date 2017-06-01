using System.Data.Entity;
using mono_lvl3.DAL.DbContext;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using Ninject.Modules;

namespace mono_lvl3.Model
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbum>().To<AlbumPOCO>();
            Bind<IArtist>().To<ArtistPOCO>();
            Bind<ISong>().To<SongPOCO>();

            Bind(typeof(DbContext)).To(typeof(DataContext));
        }
    }
}
