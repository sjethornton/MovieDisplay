using System;
using System.Collections.Generic;
using MovieDisplayDAL;
using Newtonsoft.Json.Linq;

namespace MovieDisplayViewModels
{
    public class MovieDisplayViewModel
    {
        private MovieDAO _dao;
        public string name { get; set; }
        public string dimension { get; set; }
        public string format { get; set; }
        public string rating { get; set; }

        //MovieDisplayViewModel constructor
        public MovieDisplayViewModel()
        {
            _dao = new MovieDAO();
        }

        //GetMovies
        //gets a list of all movies
        public List<MovieDisplayViewModel> GetMovies(string pId)
        {
            List<MovieDisplayViewModel> viewModels = new List<MovieDisplayViewModel>();
            var search = _dao.GetMovieFiles()["movies"][pId];

            foreach(JProperty j in search)
            {
                MovieDisplayViewModel viewModel = new MovieDisplayViewModel();
                viewModel.name = j.ToString();
                viewModel.dimension = j.ToString();
                viewModel.format = j.ToString();
                viewModel.rating = j.ToString();
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        //GetMovie
        public MovieDisplayViewModel GetMovie(string pId)
        {
            var search = _dao.GetMovieFiles()["movies"][pId];
            MovieDisplayViewModel movieDisplay = new MovieDisplayViewModel();
            movieDisplay.name = search["name"].ToString();
            movieDisplay.dimension = search["dimension"].ToString();
            movieDisplay.format = search["format"].ToString();
            movieDisplay.rating = search["rating"].ToString();
            return movieDisplay;
        }

      
    }
}
