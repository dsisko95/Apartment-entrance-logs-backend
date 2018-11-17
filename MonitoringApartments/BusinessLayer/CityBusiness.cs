using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class CityBusiness : ICityBusiness
    {
        private ICityRepository cr;

        public CityBusiness(ICityRepository cr)
        {
            this.cr = cr;
        }

        public List<City> GetAllCities()
        {
            if (cr.GetAllCities() == null)
                return null;
            else
                return cr.GetAllCities();
        }

        public bool InsertCity(City c)
        {
            bool isIt = false;
            if (c == null)
            {
                isIt = false;
            }
            else
            {
                if (cr.InsertCity(c) == 0)
                {
                    isIt = false;
                }
                else
                {
                    isIt = true;
                }
            }
            return isIt;
        }

        public bool UpdateCity(City c)
        {
            bool isIt = false;
            if (c == null)
            {
                isIt = false;
            }
            else
            {
                if (cr.UpdateCity(c) == 0)
                {
                    isIt = false;
                }
                else
                {
                    isIt = true;
                }
            }
            return isIt;
        }

        public List<City> GetCityByName(string cityName)
        {
            List<City> city = this.cr.GetCityByName(cityName);
            if (city != null)
                return city;
            else
                return null;
        }

        public bool DeleteCity(int id)
        {
            bool result = false;
            if (id != 0 && this.cr.DeleteCity(id) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}