namespace Form115.Infrastructure.Search.Base {
    #region UsingReg

    using System.Collections.Generic;
    using DataLayer.Models;

    #endregion

    internal abstract class SearchBase {
        protected IEnumerable<Hotels> SearchResults;

        public abstract IEnumerable<Hotels> GetResult();

    }
}