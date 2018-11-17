using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MonitoringApartments.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/insert")]
    public class InsertController : ApiController
    {
        private IOwnerBusiness ownerBusiness;
        private ICityBusiness cityBusiness;
        private IApartmentBusiness apartmentBusiness;
        private IClientBusiness clientBusiness;

        public InsertController(IOwnerBusiness ownerBusiness, ICityBusiness cityBusiness, IApartmentBusiness apartmentBusiness, IClientBusiness clientBusiness)
        {
            this.ownerBusiness = ownerBusiness;
            this.cityBusiness = cityBusiness;
            this.apartmentBusiness = apartmentBusiness;
            this.clientBusiness = clientBusiness;
        }
        [Route("insertcity")]
        [HttpPost]
        public bool InsertCity([FromBody] City cityObj)
        {
            return this.cityBusiness.InsertCity(cityObj);
        }
        [Route("{city}/getallcitysbyname")]
        public List<City> GetAllCitiesByName(string city)
        {
            return this.cityBusiness.GetAllCitiesByName(city);
        }
        [Route("getallcountryes")]
        public List<City> GetAllLogs()
        {
            return this.cityBusiness.GetAllCities();
        }
        [Route("getallcitiescountries")]
        public List<City> GetAllCitiesCountries()
        {
            return this.cityBusiness.GetAllCities();
        }
        [Route("{id}/deletecity")]
        [HttpDelete]
        public bool DeleteCity(int id)
        {
            return this.cityBusiness.DeleteCity(id);
        }
        [Route("updatecity")]
        [HttpPut]
        public bool UpdateStudent([FromBody]City c)
        {
            return this.cityBusiness.UpdateCity(c);
        }


    }
}
