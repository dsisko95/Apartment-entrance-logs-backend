using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MonitoringApartments.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/filter")]
    public class FilterController : ApiController
    {
        private IMonitoringBusiness monitorBusiness;
        private IOwnerBusiness ownerBusiness;

        public FilterController(IMonitoringBusiness monitorBusiness, IOwnerBusiness ownerBusiness)
        {
            this.monitorBusiness = monitorBusiness;
            this.ownerBusiness = ownerBusiness;
        }

        [Route("{date_od}/{date_do}/getalllogsbydate")]
        public List<Monitoring> GetAllLogsByDateBetween(DateTime date_od, DateTime date_do)
        {
            return this.monitorBusiness.GetAllLogsByDateBetween(date_od, date_do);
        }

        [Route("{cname}/{owname}/{clname}/{status}/getalllogsbyallfilter")]
        public List<Monitoring> GetlogsFilterAll(string cname, string owname, string clname, string status)
        {
            return this.monitorBusiness.GetlogsFilterAll(cname, owname, clname, status);
        }
    }
}