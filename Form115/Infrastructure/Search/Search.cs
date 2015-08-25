namespace Form115.Infrastructure.Search
{
    #region UsingReg

    using System.Collections.Generic;
    using DataLayer.Models;
    using Form115.Infrastructure.Search.Base;

    #endregion

    internal class Search : SearchBase {
        public Search() {
            SearchResults = new Form115Entities().Hotels;
        }


        public Search(IEnumerable<Hotels> result)
        {
            SearchResults = result;
        }

        public override IEnumerable<Hotels> GetResult()
        {
            return SearchResults;
        }
    }
}