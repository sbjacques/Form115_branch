using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form115.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Statistiques()
        {
            var db = new Form115Entities();

            var listProduit = db.Produits.Where(x => x.DateDepart > DateTime.Now).Count();
            var listUtilisateurs = db.Utilisateurs.Count();

                          //créer une liste avec résultats
            var result = new List<int>{
                listProduit, listUtilisateurs
            };
            

            return PartialView("_Statistiques",result);
            
        }

        [ChildActionOnly]
        public PartialViewResult ProchainsProduits()
        {
            var listeProduits = (new Form115Entities()).Produits.OrderBy(p => p.DateDepart).Take(10).ToList();

            return PartialView("_ProchainsProduits", listeProduits);
        }

        [ChildActionOnly]
        public PartialViewResult BestPromo()
        {
            var db = new Form115Entities();

            var countPromo = db.Promotions.Where(x => x.DateDebut > DateTime.Now).Count();
            var listPromo = db.Promotions.Where(x => x.DateDebut > DateTime.Now).OrderBy(x=>x.DateDebut).Take(5).ToList();

            //créer une liste avec résultats
            //var result = new Tuple<omo> {



            return PartialView("_BestPromo", listPromo);

        }
    }
}