using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using Form115.Models;

namespace Form115.Controllers
{
    public class BrowseController : Controller
    {
        private readonly Form115Entities _db = new Form115Entities();
        // GET: Browse
        public ActionResult Index()
        {
            var svm = new BrowseViewModel();

            //svm.ListeContinents = _db.Continents.Select(c => new { Key = c.idContinent, Value = c.name }).ToDictionary(x => x.Key, x => x.Value);
            svm.ListeContinents = _db.Continents.Where( c => _db.Hotels.Select(h => h.Villes.Pays.Regions.idContinent).Contains(c.idContinent))
                                                .Select(c => new { Key = c.idContinent, Value = c.name })
                                                .ToDictionary(x => x.Key, x => x.Value);

            return View(svm);
        }

        //public static Dictionary<int, string> GetListeContinents()
        //{

        //}

        public JsonResult GetJsonRegions(int id)
        {
            var result = _db.Continents
                            .Find(id)
                            .Regions
                            .Where(r => _db.Hotels.Select(h => h.Villes.Pays.idRegion).Contains(r.idRegion))
                            .Select(r => new { Id = r.idRegion, Nom = r.name })
                            .ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJsonPays(int id)
        {
            var result = _db.Regions
                            .Find(id)
                            .Pays
                            .Where(p => _db.Hotels.Select(h => h.Villes.CodeIso3).Contains(p.CodeIso3))
                            .Select(p => new {Id = p.CodeIso3, Nom =p.Name.Trim()})
                            .ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetJsonVilles(string id)
        {
            var result = _db.Pays
                            .Find(id)
                            .Villes
                            .Where(v => _db.Hotels.Select(h => h.IdVille).Contains(v.idVille))
                            .Select(v => new { Id = v.idVille, Nom = v.name })
                            .ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetJsonHotels(int id)
        //{
        //    var result = _db.Villes
        //                    .Find(id)
        //                    .Hotels
        //                    // TODO  remetre Nom quand nouvelle base de données
        //                    .Select(h => new { Id = h.IdHotel, Nom = h.Description })
        //                    .ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

    }
}