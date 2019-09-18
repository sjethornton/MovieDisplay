using MovieDisplayDAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDisplayViewModels
{
    public class PricingViewModel
    {
        public string matineeTime = "Showtimes starting between 8:00AM and 4:00PM";
        public string eveningTime = "Showtimes starting between 4:00PM and closing";

        private PricingDAO _dao;
        //public string format { get; set; }
        public string age { get; set; }
        public string screen { get; set; }
        public string price { get; set; }
        public string time { get; set; }

        public PricingViewModel()
        {
            _dao = new PricingDAO();
        }

        //GetPricing
        //returns a list of all available combinations of pricing/screen/time
        public List<PricingViewModel> GetPricing()
        {
            List<PricingViewModel> viewModels = new List<PricingViewModel>();
            JObject search = _dao.GetPricingFiles();
            var pricings = search.Value<JObject>("pricing").Properties();


            //evening
            foreach(var price in pricings)
            {
                //get time
                var time = "";
                if (price.Name == "matinee")
                {
                    time = matineeTime;
                }
                else
                {
                    time = eveningTime;
                }

                //drill down to get screen type
                var screenObj = search.Value<JObject>("pricing").Value<JObject>(price.Name);
                foreach(var screen in screenObj)
                {
                    var screenType = screen.Key;

                    //drill even more to get age
                    var ageObj = screenObj.Value<JObject>(screenType);
                    foreach(var a in ageObj)
                    {
                        var age = a.Key;

                        //finally drill down to get price for 2d/3d
                        var priceObj = ageObj.Value<JObject>(age);

                        string priceString = "";
                        foreach (var p in priceObj)
                        {
                            priceString += p.Key + " $" + p.Value.ToString() + " ";
                        }
                            //wrap it all up for a new PricingViewModel
                            PricingViewModel viewModel = new PricingViewModel();
                            viewModel.age = age;
                            viewModel.time = time;
                            viewModel.screen = screenType;
                            viewModel.price = priceString;
                            viewModels.Add(viewModel);
                    }
                }            }

            return viewModels;
        }
    }
}
