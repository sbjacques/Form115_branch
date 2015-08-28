using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public partial class Hotels
    {
        public void ajouterPromotion(DateTime debut, DateTime fin, int valeur)
        {
            bool commencePendantExistant = Promotions.Where(p=>p.DateDebut <= debut && p.DateFin >= debut).Count()!=0 ;
            bool terminePendantExistant = Promotions.Where(p => p.DateDebut <= fin && p.DateFin >= fin).Count() != 0;
            if (commencePendantExistant || terminePendantExistant)
            {
                throw new Exception();
            }
            else 
            { 
                Promotions promo = new Promotions {
                    Hotels = this,
                    DateDebut = debut,
                    DateFin = fin,
                    Valeur = (byte) valeur
                } ;
                (new Form115Entities()).Promotions.Add(promo) ;
            }
        }
    }
}
