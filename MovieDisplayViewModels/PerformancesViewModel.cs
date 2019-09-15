using System;
using System.Collections.Generic;
using System.Text;
using MovieDisplayDAL;
using Newtonsoft.Json.Linq;

namespace MovieDisplayViewModels
{
    
    public class PerformancesViewModel
    {
        private MovieDAO _dao;
        private DateTime dt;

        public int auditorium { get; set; }
        public string movieId { get; set; }
        public int performanceId { get; set; }
        public bool isSoldOut { get; set; }
        public string time { get; set; }
        //PerformanceViewModel constructor
        public PerformancesViewModel()
        {
            //grab current Date/Time
            //dt = new DateTime();

            //use predetermined Date/Time for demo purpose
            dt = new DateTime(2019, 01, 03);

            _dao = new MovieDAO();
        }

        //GetPerformances
        //gets a list of dates
        //public List<PerformancesViewModel> GetPerformances()
        //{
        //    List<PerformancesViewModel> viewModels = new List<PerformancesViewModel>();
        //    var search = _dao.GetMovieFiles()["performances"];

        //    foreach(JProperty j in search)
        //    {
        //        PerformancesViewModel viewModel = new PerformancesViewModel();
        //        viewModel.date = j.ToString();
        //        viewModels.Add(viewModel);
        //    }
        //    return viewModels;
        //}

        //GetPerformances
        //gets list of performances for current date
        public List<PerformancesViewModel> GetPerformancesToday()
        {
            List<PerformancesViewModel> viewModels = new List<PerformancesViewModel>();
            var search = _dao.GetMovieFiles()["performances"][dt.ToString("yyyy-MM-dd")];

            foreach (JObject j in search)
            {
                PerformancesViewModel viewModel = new PerformancesViewModel();
                viewModel.auditorium = (int)j["auditorium"];
                viewModel.movieId = j["movieId"].ToString();
                viewModel.performanceId = (int)j["performanceId"];
                viewModel.isSoldOut = (bool)j["isSoldOut"];
                viewModel.time = j["time"].ToString();
                viewModels.Add(viewModel);
            }
            return viewModels;
        }
      
    }
}
