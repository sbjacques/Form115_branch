using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form115.Infrastructure.Search.Options
{
     #region UsingReg

    using DataLayer.Models;
    using Form115.Infrastructure.Search.Base;

    #endregion

    internal class SearchOptionDestination : SearchOption {

        private readonly int _idContinent;
        private readonly int _idRegion;
        private readonly string _idPays;
        private readonly int _idVille;

        public SearchOptionDestination(SearchBase sb, int idContinent, int idRegion, string idPays, int idVille)
            : base(sb) {
                _idContinent = idContinent;
                _idRegion = idRegion;
                _idPays = idPays;
                _idVille = idVille;
        }

        public override IEnumerable<Hotels> GetResult()
        {            
            var db = new Form115Entities();

            if (_idVille != 0)
            {
                return SearchBase.GetResult().Where(h => h.IdVille == _idVille);
            }
            else if (_idPays != null)
            {
                return SearchBase.GetResult()
                                .Where(h => h.Villes.CodeIso3 == _idPays);
            }
            else if (_idRegion != 0)
            {
                return SearchBase.GetResult()
                                .Where(h => h.Villes.Pays.idRegion == _idRegion);
            }
            else if (_idContinent != 0)
            {
                return SearchBase.GetResult()
                                .Where(h => h.Villes.Pays.Regions.idContinent == _idContinent);
            }
            else
            {
                return SearchBase.GetResult();//))
            }
        }
    }
}