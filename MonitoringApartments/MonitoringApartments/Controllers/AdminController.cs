using BusinessLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MonitoringApartments.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private IOwnerBusiness ownerBusiness;
        private ICityBusiness cityBusiness;
        private IApartmentBusiness apartmentBusiness;
        private IClientBusiness clientBusiness;
        private IMonitoringBusiness monitoringBusiness;

        public AdminController(IOwnerBusiness ownerBusiness, ICityBusiness cityBusiness, IApartmentBusiness apartmentBusiness, IClientBusiness clientBusiness, IMonitoringBusiness monitoringBusiness)
        {
            this.ownerBusiness = ownerBusiness;
            this.cityBusiness = cityBusiness;
            this.apartmentBusiness = apartmentBusiness;
            this.clientBusiness = clientBusiness;
            this.monitoringBusiness = monitoringBusiness;
        }

        [Route("insertcity")]
        [HttpPost]
        public bool InsertCity([FromBody] City cityObj)
        {
            return this.cityBusiness.InsertCity(cityObj);
        }

        [Route("{city}/getcitybyname")]
        public List<City> GetAllCitiesByName(string city)
        {
            return this.cityBusiness.GetCityByName(city);
        }

        [Route("getallcountryes")]
        public List<City> GetAllLogsCountries()
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

        [Route("insertowner")]
        [HttpPost]
        public bool InsertOwner([FromBody] Owner ownerObj)
        {
            return this.ownerBusiness.InsertOwner(ownerObj);
        }

        [Route("{username}/checkduplicateusername")]
        public Owner GetCheckDuplicateUsername(string username)
        {
            return this.ownerBusiness.CheckDuplicateUsername(username);
        }

        [Route("getallowners")]
        public List<Owner> GetAllOwners()
        {
            return this.ownerBusiness.GetAllOwners();
        }

        [Route("updateowner")]
        [HttpPut]
        public bool UpdateOwner([FromBody]Owner o)
        {
            return this.ownerBusiness.UpdateOwner(o);
        }

        [Route("{id}/deleteowner")]
        [HttpDelete]
        public bool DeleteOwner(int id)
        {
            return this.ownerBusiness.DeleteOwner(id);
        }

        [Route("updateownerpassword")]
        [HttpPut]
        public bool UpdateOwnerPassword([FromBody]Owner o)
        {
            return this.ownerBusiness.UpdateOwnerPassword(o);
        }

        [Route("getallcitys")]
        public List<City> GetAllCitys()
        {
            return this.cityBusiness.GetAllCities();
        }

        [Route("getallownersbytypeowner")]
        public List<Owner> GetAllOwnersByTypeOwner()
        {
            return this.ownerBusiness.GetAllOwnersByRoleOwner();
        }

        [Route("insertapartment")]
        [HttpPost]
        public bool InsertApartment([FromBody] Apartment aObj)
        {
            return this.apartmentBusiness.InsertApartment(aObj);
        }

        [Route("getallapartmens")]
        public List<Apartment> GetAllApartments()
        {
            return this.apartmentBusiness.GetAllApartments();
        }

        [Route("updateapartment")]
        [HttpPut]
        public bool UpdateApartment([FromBody]Apartment a)
        {
            return this.apartmentBusiness.UpdateApartment(a);
        }

        [Route("insertclient")]
        [HttpPost]
        public bool InsertClient([FromBody]Client clientObj)
        {
            return this.clientBusiness.InsertClient(clientObj);
        }

        [Route("getallclients")]
        public List<Client> GetAllClients()
        {
            return this.clientBusiness.GetAllClients();
        }

        [Route("updateclient")]
        [HttpPut]
        public bool UpdateClient([FromBody]Client c)
        {
            return this.clientBusiness.UpdateClient(c);
        }

        [Route("{jmbg}/getclientbyjmbg")]
        public List<Client> GetAllClientsByJMBG(string jmbg)
        {
            return this.clientBusiness.GetClientByJMBG(jmbg);
        }
    }
}