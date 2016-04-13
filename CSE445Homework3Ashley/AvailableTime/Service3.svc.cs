using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AvailableTime
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service3 : IService3
    {
        //returns awake hours in a given number of days, and years
        //Approximately 15 awake hours per day, 365 days a year
        public int hours(string days, string years)
        {
            int yr = Int32.Parse(years);
            int d = Int32.Parse(days);
            int hour = 0;
            hour +=15*d;
            hour += (15 * 365 * yr);
            return hour;
        }
        
    }
}
