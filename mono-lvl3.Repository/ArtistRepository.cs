using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mono_lvl3.Repository.Common;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.DAL.DbContext;

namespace mono_lvl3.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private DataContext _db = new DataContext();

        public IEnumerable<Artist> GetAll()
        {
            List<Artist> data = _db.ArtistsModel.ToList();
            return data;
        }

        public Artist Get(Guid id)
        {
            Artist data = _db.ArtistsModel.Where(m => m.Id == id).FirstOrDefault();
            return data;
        }
    }
}
