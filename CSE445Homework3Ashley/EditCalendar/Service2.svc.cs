using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EditCalendar
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IService2
    {
        public string editEvent(string calendar, int value, int day, string name, string description, string start, string end)
        {
            if (calendar == "")
            {
                return "ERROR: calender must be created first";
            }
            if (calendar.StartsWith("ERROR"))
            {
                return calendar;
            }

            String[] cal = calendar.Split('\n');
            int len = cal.Length;
            //String last_entry = cal[len - 1];
            //String num = (last_entry.Split('/'))[0];
            //int last = Int32.Parse(num);

            String first_entry = cal[0];
            String num = (first_entry.Split('/'))[0];
            int first = Int32.Parse(num);
            //int last = first + 6;
            //int number_of_days = last - first + 1;

            //if they are editing by time and day
            if (value == 1)
            {
                int d = day - first; // number_of_days;
                //d++;
                for (int i = 0; i < 30; i++)
                {
                    String[] date = cal[(d * 30) + i].Split('/');
                    if (start == date[3] && end == date[4] && date[0] == day.ToString())
                    {
                        cal[(d * 30) + i] = day.ToString() + "/" + name + "/" + description + "/" + start + "/" + end;
                    }
                }
            }
            //if they are deleting

            else if (value == -1)
            {
                int d = day - first; ;
                //d++;
                for (int i = 0; i < 30; i++)
                {
                    String[] date = cal[(d * 30) + i].Split('/');
                    if (start == date[3] && end == date[4] && date[0] == day.ToString() && date[1] == name && date[2] == description)
                    {
                        cal[(d * 30) + i] = day.ToString() + "/empty/empty/00:00/00:00";
                    }
                }
            }
            String output = "";
            for (int i = 0; i < 210; i++)
            {
                output += cal[i] + "\n";
            }
            return output;
        }

    }
}

