//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produits
    {
        public Produits()
        {
            this.Reservations = new HashSet<Reservations>();
        }
    
        public int IdProduit { get; set; }
        public int IdSejour { get; set; }
        public int NbPlaces { get; set; }
        public System.DateTime DateDepart { get; set; }
        public Nullable<decimal> Prix { get; set; }
    
        public virtual Sejours Sejours { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
