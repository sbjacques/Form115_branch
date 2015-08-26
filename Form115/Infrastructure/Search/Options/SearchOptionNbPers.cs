namespace BestCars.Infrastructure.SearchAnnonces.Options
{
    #region UsingReg

    using System.Collections.Generic;
    using System.Linq;
    using DataLayer.Models;
    using Form115.Infrastructure.Search.Base;

    #endregion

    internal class SearchOptionNbPers : SearchOption {
        private readonly int? _nbPersonnes;

        public SearchOptionNbPers(SearchBase sb, int? nbp)
            : base(sb) {
            _nbPersonnes = nbp;
        }

        public override IEnumerable<Hotels> GetResult()
        {
            var db = new Form115Entities(); 
            return _nbPersonnes.HasValue
                ? SearchBase.GetResult()
                             .Where(h => db.Produits
                                           .Where(p => ((p.NbPlaces - (p.Reservations.Count() != 0 ? p.Reservations.Sum(r => r.Quantity) : 0)) >= _nbPersonnes)) 
                                           .Select(p => p.Sejours.IdHotel)
                                           .Contains(h.IdHotel))
                : SearchBase.GetResult();
        }
    }
}