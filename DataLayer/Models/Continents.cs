//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Continents
    {
        public Continents()
        {
            this.Regions = new HashSet<Regions>();
        }
    
        public int idContinent { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<Regions> Regions { get; set; }
    }
}
