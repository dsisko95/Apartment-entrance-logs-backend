using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IMonitoringRepository
    {
        List<Monitoring> GetAllLogs();

        List<Monitoring> GetAllLogsByDateBetween(DateTime date_od, DateTime date_do);

        List<Monitoring> GetlogsFilterAll(string cname, string owname, string clname, string status);
    }
}