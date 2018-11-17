using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface ICityRepository
    {
        List<City> GetAllCities();

        int InsertCity(City c);

        int UpdateCity(City c);

        List<City> GetCityByName(string cityName);

        int DeleteCity(int id);
    }
}