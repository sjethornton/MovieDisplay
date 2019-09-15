using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDisplayViewModels;
using Newtonsoft.Json.Linq;



namespace MovieDisplayWeb.Controllers
{
    public class MovieController : Controller
    {
        MovieDisplayViewModel movieViewModel;
        PerformancesViewModel performancesViewModel;
        //Dictionary<String, String> showsToday;
        List<ShowingsViewModel> showsToday;
        List<ShowingsViewModel> showsToday2;

        Dictionary<PerformancesViewModel, MovieDisplayViewModel> movieInfo;
        // GET: Movie
        public ActionResult Index()
        {
            movieViewModel = new MovieDisplayViewModel();
            performancesViewModel = new PerformancesViewModel();
            movieInfo = new Dictionary<PerformancesViewModel, MovieDisplayViewModel>();
            showsToday = new List<ShowingsViewModel>();
            showsToday2 = new List<ShowingsViewModel>();

            //obtain performance for today
            IList<PerformancesViewModel> allPerfs = performancesViewModel.GetPerformancesToday();
            IList<PerformancesViewModel> allPerfsSorted = allPerfs.OrderBy(x => x.auditorium).ToList();
            //find movies for running shows


            GetShows(allPerfsSorted);
            ViewData["movies"] = movieInfo;

            ViewData["performances"] = showsToday;
            ViewData["performances2"] = showsToday2;

            return View();
        }

        public void GetShows(IList<PerformancesViewModel> p)
        {
            List<MovieDisplayViewModel> movies = new List<MovieDisplayViewModel>();
            foreach(PerformancesViewModel pvm in p){
                var per = movieViewModel.GetMovie(pvm.movieId);
                movieInfo.Add(pvm, per);
            }

            var count = 0;
            var secondPage = false;
            foreach(KeyValuePair<PerformancesViewModel, MovieDisplayViewModel> e in movieInfo)
            {

                if(secondPage == false & e.Key.auditorium == 7)
                {
                    //new auditorium on second page
                    //used only for first entry on second page
                    showsToday2.Add(new ShowingsViewModel());
                    showsToday2[showsToday2.Count - 1].auditorium = e.Key.auditorium;
                    showsToday2[showsToday2.Count - 1].name = e.Value.name;
                    showsToday2[showsToday2.Count - 1].dimension = e.Value.dimension;
                    showsToday2[showsToday2.Count - 1].format = e.Value.format;
                    showsToday2[showsToday2.Count - 1].rating = e.Value.rating;
                    showsToday2[showsToday2.Count - 1].addTime(e.Key.isSoldOut, e.Key.time);
                    count = e.Key.auditorium;
                    secondPage = true;
                }
                else if(count < e.Key.auditorium && count < 6)
                {
                    //new auditorium
                    showsToday.Add(new ShowingsViewModel());
                    showsToday[showsToday.Count - 1].auditorium = e.Key.auditorium;
                    showsToday[showsToday.Count - 1].name = e.Value.name;
                    showsToday[showsToday.Count - 1].dimension = e.Value.dimension;
                    showsToday[showsToday.Count - 1].format = e.Value.format;
                    showsToday[showsToday.Count - 1].rating = e.Value.rating;
                    showsToday[showsToday.Count - 1].addTime(e.Key.isSoldOut, e.Key.time);
                    count = e.Key.auditorium;
                }
                else if(count < e.Key.auditorium && count >= 7)
                {
                    //new auditorium on second page
                    showsToday2.Add(new ShowingsViewModel());
                    showsToday2[showsToday2.Count - 1].auditorium = e.Key.auditorium;
                    showsToday2[showsToday2.Count - 1].name = e.Value.name;
                    showsToday2[showsToday2.Count - 1].dimension = e.Value.dimension;
                    showsToday2[showsToday2.Count - 1].format = e.Value.format;
                    showsToday2[showsToday2.Count - 1].rating = e.Value.rating;
                    showsToday2[showsToday2.Count - 1].addTime(e.Key.isSoldOut, e.Key.time);
                    count = e.Key.auditorium;
                }
                else if(count == e.Key.auditorium && count < 7)
                {
                    //new time
                    showsToday[showsToday.Count - 1].addTime(e.Key.isSoldOut, e.Key.time);
                }
                else if(count == e.Key.auditorium && count >= 7)
                {
                    //new time on second page
                    showsToday2[showsToday2.Count - 1].addTime(e.Key.isSoldOut, e.Key.time);
                }

            }
        }
        
    }
}