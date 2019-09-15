using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDisplayViewModels;
using Newtonsoft.Json.Linq;

namespace MovieDisplayWeb.Controllers
{
    public class PerformancesController : Controller
    {
        PerformancesViewModel performancesViewModel;
       
        // GET: Movie
        public ActionResult Index()
        {
            performancesViewModel = new PerformancesViewModel();

            //IList<PerformancesViewModel> allPerfs = performancesViewModel.GetPerformancesToday();
            //ViewData["performances"] = allPerfs;

            return View();
        }
    }
}