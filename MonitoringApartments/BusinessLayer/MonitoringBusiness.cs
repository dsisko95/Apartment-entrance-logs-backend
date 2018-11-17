using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class MonitoringBusiness : IMonitoringBusiness
    {
        private IMonitoringRepository monitoringRepository;

        public MonitoringBusiness(IMonitoringRepository monitoringRepository)
        {
            this.monitoringRepository = monitoringRepository;
        }

        public List<Monitoring> GetAllLog()
        {
            List<Monitoring> logs = this.monitoringRepository.GetAllLogs();
            if (logs.Count > 0)
            {
                return logs;
            }
            else
            {
                return null;
            }
        }

        public List<Monitoring> GetAllLogsByDateBetween(DateTime date_od, DateTime date_do)
        {
            List<Monitoring> logs = this.monitoringRepository.GetAllLogsByDateBetween(date_od, date_do);
            if (logs.Count > 0)
            {
                return logs;
            }
            else
            {
                return null;
            }
        }

        public List<Monitoring> GetlogsFilterAll(string cname, string owname, string clname, string status)
        {
            List<Monitoring> logs = this.monitoringRepository.GetlogsFilterAll(cname, owname, clname, status);
            if (logs.Count > 0)
            {
                return logs;
            }
            else
            {
                return null;
            }
        }
    }
}