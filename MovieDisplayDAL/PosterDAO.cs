using System;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MovieDisplayDAL
{
    public class PosterDAO
    {
        private String jsonFile = @"App_Data/dboposter.json";

        private JArray jsonData;

        public PosterDAO()
        {
            jsonData = GetPosterFiles();
        }

        //GetPosterFiles
        public JArray GetPosterFiles()
        {
            try
            {
                var domain = AppDomain.CurrentDomain.BaseDirectory;
                return JArray.Parse(File.ReadAllText(domain + jsonFile));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message + " found in GetPosterFiles in PosterDAO");
                throw e;
            }
        }
    }
}
