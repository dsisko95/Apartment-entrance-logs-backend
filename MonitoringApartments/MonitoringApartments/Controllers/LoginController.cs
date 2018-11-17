using BusinessLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MonitoringApartments.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private IOwnerBusiness ownerBusiness;
        private IMonitoringBusiness monitoringBusiness;

        public LoginController(IOwnerBusiness ownerBusiness, IMonitoringBusiness monitoringBusiness)
        {
            this.ownerBusiness = ownerBusiness;
            this.monitoringBusiness = monitoringBusiness;
        }

        [Route("{username}/{password}/getownerlogin")]
        public Owner GetOwnerLogin(string username, string password)
        {
            return this.ownerBusiness.GetOwnerLogin(username, password);
        }

        [Route("{username}/{secques1}/{secques2}/getcheckusernamebysecquest")]
        public List<Owner> GetOwnerCheckSecQuestion(string username, string secques1, string secques2)
        {
            return this.ownerBusiness.GetCheckUsernameBySecQuestion(username, secques1, secques2);
        }

        [Route("updateownerbyusername")]
        [HttpPut]
        public bool UpdateOwnerByUsername([FromBody]Owner o)
        {
            return this.ownerBusiness.UpdateOwnerPasswordByUsername(o);
        }

        [Route("getalllogs")]
        public List<Monitoring> GetAllLogs()
        {
            return this.monitoringBusiness.GetAllLog();
        }
    }
}