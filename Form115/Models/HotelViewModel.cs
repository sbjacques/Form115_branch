using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form115.Models
{
    public class HotelViewModel
    {

        public int IdHotel { get; set; }

        public int DureeMinSejour { get; set; }

        public int DureeMaxSejour { get; set; }

        public string DateDepart { get; set; }

    }
}