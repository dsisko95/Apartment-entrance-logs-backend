using DataLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface ICityBusiness
    {
        List<City> GetAllCities();

        bool InsertCity(City c);

        bool UpdateCity(City c);

        List<City> GetCityByName(string cityName);

        bool DeleteCity(int id);
    }
}