using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using mono_lvl3.DAL.DbContext;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using System.Data.Entity;

namespace mono_lvl3.Model
{
    public class DIModule : Ninject.Modules.NinjectModule
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
