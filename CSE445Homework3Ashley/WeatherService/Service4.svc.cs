using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service4 : IService4
    {
        public double tempConvert(String type, double value)
        {
            double temp = 0.0;
            if(type=="C")
            {
                temp = (value * 1.8) + 32;
            }
            else if(type=="F")
            {
                temp = ((value - 32) / 9) * 5;
            }

            return temp;
        }

          
    }
}
