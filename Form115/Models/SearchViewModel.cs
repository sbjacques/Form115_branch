﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form115.Models
{
    public class SearchViewModel : BrowseViewModel
    {
        // Informations retournées par le formulaire
        public DateTime DateDepart { get; set; }
        public byte? Duree { get; set; }
        public int? PrixMin { get; set; }
        public int? PrixMax { get; set; }
        public string Categorie { get; set; }
        public int? NbPers { get; set; }

        // Informations de liste à envoyer à la BDD
        public Dictionary<int, string> ListeCategories { get; set; }
        public int DisponibiliteMax { get; set; }
    }
}