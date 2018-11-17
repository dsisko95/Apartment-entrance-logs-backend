using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IMonitoringBusiness
    {
        List<Monitoring> GetAllLog();

        List<Monitoring> GetAllLogsByDateBetween(DateTime date_od, DateTime date_do);

        List<Monitoring> GetlogsFilterAll(string cname, string owname, string clname, string status);
    }
}