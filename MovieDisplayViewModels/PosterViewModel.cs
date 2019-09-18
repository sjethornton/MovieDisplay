using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.IO;
using MovieDisplayDAL;
using Newtonsoft.Json.Linq;

namespace MovieDisplayViewModels
{
    public class PosterViewModel
    {
        private PosterDAO _dao;
        public string id { get; set; }
        public string posterName { get; set; }
        public string posterURL { get; set; }
        public string performanceNumbers { get; set; }

        //constructor
        public PosterViewModel()
        {
            _dao = new PosterDAO();
        }

        //GetPosters
        //will return a list of posters based off of a list of performance ids
        //will ignore duplicates
        public List<string> GetPosters(IList<PerformancesViewModel> pvm)
        {
            List<string> result = new List<string>();
            var posterFiles = _dao.GetPosterFiles();
            foreach(PerformancesViewModel s in pvm)
            {
                if (result.Contains(s.performanceId.ToString()))
                {
                    //duplicate, ignore
                }
                else
                {
                    foreach (JObject j in posterFiles)
                    {
                        var test = j["performanceNumbers"];
                        foreach (string pn in test)
                        {
                            if (pn == s.performanceId.ToString())
                            {
                               var filePath = AppDomain.CurrentDomain.BaseDirectory + "img\\" + j["posterName"].ToString();
                                var filePathtest = "img\\" + j["posterName"].ToString();
                                //check for duplicates
                                if (result.Contains(filePathtest) == false)
                                {
                                    //check to see if poster file exists
                                    if (System.IO.File.Exists(filePath))
                                    {
                                        result.Add(filePathtest);
                                    }
                                }
                            }
                        }
                    }
                }
            }
              

            return result;
        }
    }

}
