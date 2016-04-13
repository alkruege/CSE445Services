using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace tempService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService5
    {
        public double tempConvert(String type, string value)
        {
            double temp = 0.0;
            double val = Convert.ToDouble(value);
            if (type == "C")
            {
                temp = (val * 1.8) + 32;
            }
            else if (type == "F")
            {
                temp = ((val - 32) / 9) * 5;
            }

            return temp;
        }
    }
}
