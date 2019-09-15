using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace MovieDisplayDAL
{
    public class MovieDAO
    {
        private String jsonFile = @"App_Data/dbo.json";
        
        private JObject jsonData;
        public MovieDAO()
        {
            //pull up information from dbo.json
            jsonData = GetMovieFiles();
        }

        //GetMovieFiles

        public JObject GetMovieFiles()
        {
            var domain = AppDomain.CurrentDomain.BaseDirectory;
            return JObject.Parse(File.ReadAllText(domain + jsonFile));
        }
    }
}
