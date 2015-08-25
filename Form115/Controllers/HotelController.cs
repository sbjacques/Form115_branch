using DataLayer.Models;
using Form115.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form115.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Form115Entities db = new Form115Entities();
            Hotels hotel = db.Hotels.Where(h => h.IdHotel == id).First();
            HotelViewModel hvm = new HotelViewModel
            {
                Hotel = hotel
            };
            return View(hvm);
        }
    }
}