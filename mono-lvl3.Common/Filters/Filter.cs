using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Common.Filters
{
    public class Filter : IFilter
    {
        #region Properties 

        public string SearchString { get; set; }
        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        #endregion Properties


        #region Variables

        public int DefaultPageSize = 5;

        #endregion Variables


        #region Constructors

        public Filter(string searchTerm, int pageNumber, int pageSize)
        {
            SearchString = searchTerm;
            SetPageNumberAndSize(pageNumber, pageSize);
        }

        #endregion Constructors

        #region Methods

        private void SetPageNumberAndSize(int pageNumber = 1, int pageSize = 0)
        {
            PageNumber = (pageNumber > 0) ? pageNumber : 1;
            PageSize = (pageSize > 0 && pageSize <= DefaultPageSize) ? pageSize : DefaultPageSize;
        }

        #endregion Methods
    }

}
