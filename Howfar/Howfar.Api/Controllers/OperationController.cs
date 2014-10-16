using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Howfar.Api.Helpers;
using Howfar.Api.Models;
using Howfar.Model;
using Howfar.Model.Interfaces;

namespace Howfar.Api.Controllers
{
    public class OperationController : ApiController
    {
        private readonly IGenericRepository<City> _repository;
        private GeneralHelper _calculator;

        public OperationController(IGenericRepository<City> repository)
        {
            _repository = repository;
            _calculator = new GeneralHelper();
        }

        public List<CityDetailViewModel> GetCitiesList()
        {
            var cityModel = _repository.GetAll();

            return cityModel.Select(city => new CityDetailViewModel()
                                                {
                                                    Id = city.CityId, Name = city.Name, Latitude = city.Latitude, Longitude = city.Longitude
                                                }).ToList();
        }

        public string GetDistance(long city01, long city02)
        {
            var first = _repository.Get(city01);
            
            var second = _repository.Get(city02);
            
            if (first == null || second == null)
                return "O código da " + (first == null ? "primeira" : "segunda") + " cidade não é válido!";

            return _calculator.GetDistance(new CityViewModel()
                                {
                                    Latitude = first.Latitude,
                                    Longitude = first.Longitude
                                }, 
                                new CityViewModel()
                                {
                                    Latitude = second.Latitude,
                                    Longitude = second.Longitude
                                });
        }

        public List<CityDistanceSimpleViewModel> GetClosestCities(long city, int total = 2)
        {
            var cityBase = _repository.Get(city);

            if (cityBase == null)
                return new List<CityDistanceSimpleViewModel>();

            var cityModel = _repository.GetAll().Where(x => x.CityId != cityBase.CityId);

            var citiesViewModel = cityModel.Select(c => new CityDetailViewModel()
                                                {
                                                    Name = c.Name, Latitude = c.Latitude, Longitude = c.Longitude
                                                }).ToList();

            
            var cities = _calculator.GetClosestCities(citiesViewModel, new CityViewModel(){Latitude = cityBase.Latitude, Longitude = cityBase.Longitude}, total);
            
            return cities;
        }
    }
}