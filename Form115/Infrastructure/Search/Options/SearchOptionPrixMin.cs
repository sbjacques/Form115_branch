namespace Form115.Infrastructure.Search.Options
{
    #region UsingReg

    using System.Collections.Generic;
    using System.Linq;
    using DataLayer.Models;
    using Form115.Infrastructure.Search.Base;

    #endregion

    internal class SearchOptionPrixMin : SearchOption
    {
        private readonly int? _prixMin;

        public SearchOptionPrixMin(SearchBase sb, int? prixMin)
            : base(sb)
        {
            _prixMin = prixMin;
        }

        public override IEnumerable<Hotels> GetResult()
        {
            return _prixMin.HasValue
                ? SearchBase.GetResult()
                            .Where(x => x.Sejours
                                          .Select(s => s.Produits
                                                        .Where(p => p.Prix >= _prixMin))
                                          .Any())
                : SearchBase.GetResult();
        }
    }
}