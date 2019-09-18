﻿using Newtonsoft.Json.Linq;
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
            try
            {
                var domain = AppDomain.CurrentDomain.BaseDirectory;
                return JObject.Parse(File.ReadAllText(domain + jsonFile));
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Error " + e.Message + " found in GetMovieFiles in MovieDAO");
                throw e;
            }
        }
    }
}
