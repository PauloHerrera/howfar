using System.Collections.Generic;
using System.Data.Entity;
using Howfar.Model;

namespace Howfar.Data.Config
{
    public class EntityContextInitializer : CreateDatabaseIfNotExists<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            IList<City> cities = new List<City>();
            
            cities.Add(new City() { Name = "São Vicente", Latitude = "23°57'17.5\"S", Longitude = "46°30'08.2\"W" });
            cities.Add(new City() { Name = "Santos", Latitude = "-23.954719", Longitude = "-46.342014" });
            cities.Add(new City() { Name = "Rio Branco", Latitude = "9°58'27.9\"S ", Longitude = "67°49'42.1\"W" });
            cities.Add(new City() { Name = "Florianópolis", Latitude = "27°35'30.4\"S", Longitude = "48°33'46.3\"W" });
            cities.Add(new City() { Name = "Pindamonhangaba", Latitude = "22°55'30.4\"S", Longitude = "45°27'44.7\"W" });
            cities.Add(new City() { Name = "Curitiba", Latitude = "25°25'11.7\"S", Longitude = "49°15'59.0\"W" });
            cities.Add(new City() { Name = "Ilha Bela", Latitude = "23°46'44.3\"S", Longitude = "45°21'21.5\"W" });
            cities.Add(new City() { Name = "Belo Horizonte", Latitude = "19°55'21.2\"S", Longitude = "43°56'46.3\"W" });
            cities.Add(new City() { Name = "Paraty", Latitude = "-23.217399", Longitude = "-44.734772" });
            cities.Add(new City() { Name = "Salvador", Latitude = "12°58'15.1\"S", Longitude = "38°30'11.7\"W" });
              
            cities.Add(new City() { Name = "Los Angeles", Latitude = "34° 3' 8'' N", Longitude = "118° 14' 37'' W" });
            cities.Add(new City() { Name = "Ibiza", Latitude = "38.906694", Longitude = "1.420292" });
            cities.Add(new City() { Name = "Buenos Aires", Latitude = "34°36'05.7\"S", Longitude = "58°22'49.5\"W" });
            cities.Add(new City() { Name = "Acapulco", Latitude = "16°51'52.8\"N", Longitude = "99°53'14.6\"W" });
            cities.Add(new City() { Name = "Cidade do México", Latitude = "19°25'43.0\"N", Longitude = "99°08'03.6\"W" });
            cities.Add(new City() { Name = "Kingston", Latitude = "17°59'00.3\"N ", Longitude = "76°47'51.9\"W" });
            //cities.Add(new City() { Name = "Sydney", Latitude = "33°35'55.2\"S", Longitude = "150°56'47.8\"E" });
            cities.Add(new City() { Name = "Lyon", Latitude = "45°45'50.6\"N", Longitude = "4°50'07.7\"E" });
            cities.Add(new City() { Name = "Barcelona", Latitude = "41°23'08.3\"N", Longitude = "2°10'22.1\"E" });
            cities.Add(new City() { Name = "Madrid", Latitude = "40°24'58.1\"N", Longitude = "3°41'58.0\"W" });
            
            foreach (City city in cities)
                context.Citys.Add(city);

            //All standards will
            base.Seed(context);
        }
    }
}
