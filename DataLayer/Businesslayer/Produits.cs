using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// HACK classe ajoutée
namespace DataLayer.Models
{

    public partial class Produits
    {
        private Form115Entities _db = new Form115Entities();

        public byte GetPromotions
        {
            get
            {
                return Sejours.Hotels.Promotions
                                     .Where(p => (p.DateDebut <= DateDepart) && (p.DateFin >= DateDepart))
                                     .Select(p => p.Valeur)
                                     .FirstOrDefault();
            }

        }
    }
}
