using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CreateCalendar
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string create_calendar(int startDate);

        [OperationContract]
        String AddEvent(string calendar, int day, string name, string description, string start, string end);

        [OperationContract]
        String CalendarToDisplay(string cal);
    }

    [DataContract]
    public class CompositeType
    {
        
    }
}
