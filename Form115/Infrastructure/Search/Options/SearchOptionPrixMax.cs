namespace Form115.Infrastructure.Search.Options
{
    #region UsingReg

    using System.Collections.Generic;
    using System.Linq;
    using DataLayer.Models;
    using Form115.Infrastructure.Search.Base;

    #endregion

    internal class SearchOptionPrixMax : SearchOption
    {
        private readonly int? _prixMax;

        public SearchOptionPrixMax(SearchBase sb, int? prixMax)
            : base(sb)
        {
            _prixMax = prixMax;
        }

        public override IEnumerable<Hotels> GetResult()
        {
            return  _prixMax.HasValue
                ? SearchBase.GetResult()
                            .Where(x => x.Sejours
                                          .Select(s => s.Produits
                                                        .Where(p => p.Prix <= _prixMax))
                                          .Any())
                : SearchBase.GetResult();
        }
    }
}