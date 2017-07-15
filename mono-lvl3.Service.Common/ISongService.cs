using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Service.Common
{
    public interface ISongService
    {
        #region Methods

        Task<IEnumerable<ISong>> GetAsync(IFilter filter = null);
        Task<ISong> GetByIDAsync(Guid id);
        Task<int> AddAsync(ISong song);
        Task<int> UpdateAsync(ISong song);
        Task<int> DeleteAsync(Guid id);

        // Za popunjavanje dropdown liste za odabir albuma na kojemu se nalazi pjesma
        //IEnumerable<IAlbum> GetAlbumsAsync();

        #endregion Methods
    }
}
