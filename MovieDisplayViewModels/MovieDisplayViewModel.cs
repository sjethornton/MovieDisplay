
using MovieDisplayDAL;

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
        //returns a movie based off movieId from PerformanceViewModel
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
