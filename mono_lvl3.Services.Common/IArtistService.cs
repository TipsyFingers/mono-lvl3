using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Service.Common
{
    public interface IArtistService
    {
        #region Methods

        Task<IEnumerable<IArtist>> GetAsync(IFilter filter = null);
        Task<int> AddAsync(IArtist artist);
        Task<int> UpdateAsync(IArtist artist);
        Task<int> DeleteAsync(Guid id);

        #endregion Methods
    }
}
