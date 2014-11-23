using Articles.Data;
using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AlertsWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlertsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlertsService.svc or AlertsService.svc.cs at the Solution Explorer and start debugging.
    public class AlertsService : IAlertsService
    {
        private IAlertsData data;

        public AlertsService()
        {
            this.data = new AlertsData(ArticlesDbContext.Create());
        }

        public ICollection<int> Get()
        {
            //var alerts = this.data.Alerts.All().ToList();
            //return alerts;

            return new List<int> { 2, 3 };
        }
    }
}
