using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace MovieDisplayDAL
{
    public class PricingDAO
    {
        private String jsonFile = @"App_Data/dbo.json";

        private JObject jsonData;

        public PricingDAO()
        {
            //pull info from dbo.json
            jsonData = GetPricingFiles();
        }

        //GetPricingFiles
        public JObject GetPricingFiles()
        {
            try
            {
                var domain = AppDomain.CurrentDomain.BaseDirectory;
                var result = JObject.Parse(File.ReadAllText(domain + jsonFile));
                return result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error " + e.Message + " found in GetPricingFiles");
                throw e;
            }
        }
    }
}
