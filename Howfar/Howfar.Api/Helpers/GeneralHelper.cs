using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Howfar.Api.Models;

namespace Howfar.Api.Helpers
{
    public class GeneralHelper
    {
        public string GetDistance(CityViewModel city01, CityViewModel city02)
        {
            var distance = CalculateDistance(city01, city02);
            return distance.ToString() + " km";
        }

        public List<CityDistanceSimpleViewModel> GetClosestCities(List<CityDetailViewModel> cities, CityViewModel cityBase, int numberOfCities)
        {
            var citiesViewModel = cities.Select(c => new CityDistanceSimpleViewModel()
                                                         {
                                                             Name = c.Name, Distance = CalculateDistance(cityBase, new CityViewModel() {Latitude = c.Latitude, Longitude = c.Longitude})
                                                         }).ToList();

            var teste = citiesViewModel.OrderBy(x => x.Distance).Take(numberOfCities).ToList();

            return teste;
        }

        private double CalculateDistance(CityViewModel city01, CityViewModel city02)
        {
            var radianLa01 = GetRadian(ConvertCoordenate(city01.Latitude));
            var radianLo01 = GetRadian(ConvertCoordenate(city01.Longitude));
            var radianLa02 = GetRadian(ConvertCoordenate(city02.Latitude));
            var radianLo02 = GetRadian(ConvertCoordenate(city02.Longitude));

            var laChange = Math.Abs(radianLa01 - radianLa02);
            var loChange = Math.Abs(radianLo01 - radianLo02);

            //[sen²(Δlat/2) + cos(lat1)] x cos(lat2) x sen²(Δlong/2)
            var calc01Result =
                (Math.Sin(laChange/2) * Math.Sin(laChange/2) + Math.Cos(radianLa01)) * Math.Cos(radianLa02) * (Math.Sin(loChange/2) * Math.Sin(loChange/2));

            // 2 x cot(√a/√(1−a))
            var calc02Result = 2 * Math.Asin(Math.Sqrt(calc01Result)/Math.Sqrt(1 - calc01Result));

            var distance = 6371*calc02Result;

            return Math.Round(distance, 3);
        }

        private double ConvertCoordenate(string valueToConvert)
        {
            if (IsNotDecimalFormat(valueToConvert))
            {
                char[] charlist = { '°', '\'', '"' };

                var listItens = valueToConvert.Split(charlist);
                
                var total =
                     double.Parse(listItens[0]) +
                            (double.Parse(string.IsNullOrEmpty(listItens[1]) ? "0" : listItens[1].Replace('.', ',')) * 0.0166666666666667) +
                            (double.Parse(string.IsNullOrEmpty(listItens[2]) ? "0" : listItens[2].Replace('.', ',')) * 0.0166666666666667 * 0.0166666666666667);

                if (listItens.Last().Trim() == "S" || listItens.Last().Trim() == "W")
                    total = -total;

                return total;
            }

            return double.Parse(string.IsNullOrEmpty(valueToConvert) ? "0" : valueToConvert.Replace(".", ","));
        }

        private bool IsNotDecimalFormat(string valueToVerify)
        {
            if (string.IsNullOrEmpty(valueToVerify))
                return false;

            var strCoord = new List<string>() { "N", "S", "E", "W" };

            return strCoord.Any(str => valueToVerify.Contains(str));
        }

        private double GetRadian(double valueToConvert)
        {
            return valueToConvert * (Math.PI / 180);
        }

    }
}