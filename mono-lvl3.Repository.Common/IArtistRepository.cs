using mono_lvl3.DAL.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Repository.Common
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAll();
        Artist Get(Guid id);
    }
}
