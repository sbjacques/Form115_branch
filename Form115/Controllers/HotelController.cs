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
            //Form115Entities db = new Form115Entities();
            //Hotels hotel = db.Hotels.Where(h => h.IdHotel == id).First();
            HotelViewModel hvm = new HotelViewModel
            {
                IdHotel = id
            };
            return View(hvm);
        }

        public ActionResult DetailsPeriode(int id, string DateDebut, string DateFin)
        {
            //Form115Entities db = new Form115Entities();
            //Hotels hotel = db.Hotels.Where(h => h.IdHotel == id).First();
            HotelViewModel hvm = new HotelViewModel
            {
                IdHotel = id
            };
            return View(hvm);
        }
        

        [HttpPost]
        public JsonResult listeProduits(HotelViewModel hvm)
        {
            Form115Entities db = new Form115Entities();
            var prods = db.Produits.Where(p => p.Sejours.IdHotel == hvm.IdHotel)
                            .Where(p=>p.Sejours.Duree >= hvm.DureeMinSejour) ; 
            if (hvm.DureeMaxSejour != null) {
                prods = prods.Where(p=>p.Sejours.Duree<=hvm.DureeMaxSejour) ;         
            }
            if (hvm._dateDepart!=null) {
                prods = prods.Where(p=>p.DateDepart >= hvm._dateDepart) ;
            } 
            var result = prods.Select(p => new { 
                                date = p.DateDepart.ToString(), 
                                duree = p.Sejours.Duree,
                                prix = p.Prix, 
                                //promotions = p.GetPromotions,
                                nb_restants = p.NbPlaces - p.Reservations.Sum(r => r.Quantity)
                            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}