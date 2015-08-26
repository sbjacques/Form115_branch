using BestCars.Infrastructure.SearchAnnonces;
using DataLayer.Models;
using Form115.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Form115.Infrastructure.Search;
using Form115.Infrastructure.Search.Base;
using Form115.Infrastructure.Search.Options;
using BestCars.Infrastructure.SearchAnnonces.Options;

namespace Form115.Controllers
{
    public class SearchController : Controller
    {
        private readonly Form115Entities _db = new Form115Entities();
        // GET: Browse
        public ActionResult Index()
        {
            var svm = new SearchViewModel();

            svm.ListeContinents = _db.Continents.Select(c => new { Key = c.idContinent, Value = c.name }).ToDictionary(x => x.Key, x => x.Value);
            // TODO classe Categorie qui renverra la liste des catégories (méthode statique)
            svm.ListeCategories = _db.Categories.Select(c => new { Key = c.IdCategorie, Value = c.Description }).ToDictionary(x => x.Key, x => x.Value);
            svm.DisponibiliteMax = _db.Produits.Select(p => p.NbPlaces).Max();
            svm.DisponibiliteMax = 20;

            return View(svm);
        }

        [HttpPost]
        public ActionResult Result(SearchViewModel svm)
        {
            //_listBreadCrumb.Add(new BreadCrumbItem { Texte = "Résultat", ControllerName = "Search", ActionName = "Result" });
            //ViewBag.ListeCrumbItem = _listBreadCrumb;

            // var pageSize = 20;
            var result = GetSearchResult(svm);

            //var rvm = new SearchResultViewModel
            //{
            //    ListeResultat = result.Take(pageSize).ToList(),
            //    PageSize = pageSize,
            //    ItemsQty = result.Count(),
            //    PagesQty = (result.Count() % pageSize) == 0 ? result.Count() / pageSize : result.Count() / pageSize + 1,
            //    CurrentPage = 1,
            //    XmlSearchViewModel = svm.SerializeSearchViewModel()
            //};
            //return View(rvm);// l.Select(v => new {v.IdVoiture, v.TypeVendeur, v.NumDep, v.Prix}
            return View(result);
        }

        private static List<Hotels> GetSearchResult(SearchViewModel svm)
        {
            // Search et SearchOption héritent de SearchBase
            SearchBase s = new Search();
            s = new SearchOptionDestination(s, svm.Continent, svm.Region, svm.Pays, svm.Ville);
            //s = new SearchOptionDateDepart(s, svm.DateDepart);
            s = new SearchOptionDuree(s, svm.Duree);
            s = new SearchOptionNbPers(s, svm.NbPers);
            s = new SearchOptionPrixMax(s, svm.PrixMax);
            s = new SearchOptionPrixMin(s, svm.PrixMin);


            return s.GetResult().ToList();
        }
    
    }
    
}