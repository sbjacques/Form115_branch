using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Form115.Models
{
    public class HotelViewModel
    {

        public int IdHotel { get; set; }

        public int DureeMinSejour { get; set; }

        public int? DureeMaxSejour { get; set; }

        public DateTime _dateDepart;
        public string DateDepart
        {
            get { return _dateDepart.ToString(); }
            set
            {
                if (value == "") { _dateDepart = DateTime.Now; }
                else {
                    string format = "dd/MM/yyyy";
                    if (!DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out _dateDepart))
                    {
                        _dateDepart = DateTime.Now;
                    }
                }
            }
        }

    }
}