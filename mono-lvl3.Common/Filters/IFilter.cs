using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Common.Filters
{
    public interface IFilter
    {
        string SearchString { get; set; }
        string SortOrder { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
