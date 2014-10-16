using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Howfar.Api.Models
{
    public class CityViewModel
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class CityDetailViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }



    public class CityDistanceSimpleViewModel
    {
        public string Name { get; set; }
        public double Distance { get; set; }
    }
}