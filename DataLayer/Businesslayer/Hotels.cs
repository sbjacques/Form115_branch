using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public partial class Hotels
    {
        public void ajouterPromotion(Form115Entities db, Promotions promo)
        {
            bool commencePendantExistant = Promotions.Where(p=>p.DateDebut <= promo.DateDebut && p.DateFin >= promo.DateDebut).Any() ;
            bool terminePendantExistant = Promotions.Where(p => p.DateDebut <= promo.DateFin && p.DateFin >= promo.DateFin).Any() ;
            if (commencePendantExistant || terminePendantExistant)
            {
                throw new Exception();
            }
            else 
            { 
                db.Promotions.Add(promo) ;
            }
        }
    }
}
