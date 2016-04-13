using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Web;


namespace CreateCalendar
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //creates a calendar
        public String create_calendar(int startDate)
        {
            int days = 7;
            //utilizes the Calendar, Day, and Event Classes
            Calendar myCalendar = new Calendar(days);
            String output="";
            for(int i=0; i<days; i++)
            {
                (myCalendar.getDays()[i]).setDate(startDate);

                for(int j=0; j<myCalendar.getDays()[i].getSchedule().Length; j++)
                {
                    myCalendar.getDays()[i].getSchedule()[j].setDay(startDate);
                    Event temp = myCalendar.getDays()[i].getSchedule()[j];
                    output += temp.getDay()+ "/" + temp.getName() + "/" + temp.getDescription() + "/" + temp.getStart() +"/"+ temp.getEnd() +"\n";
                }
                startDate++;
            }

            return output;

        }

        //makes that calendar in the format to display
        public String CalendarToDisplay(string cal)
        {
            //error handling
            if(cal=="")
            {
                return "ERROR: Calendar must be created first";

            }
            if(cal.StartsWith("ERROR"))
            {
                return cal;
            }
            
            Calendar myCalendar = new Calendar();
            string[] time_array = myCalendar.getTimeArray();
            String output = "";
            String[] calendar = cal.Split('\n');
            int len=calendar.Length;
            //display the week lengthwise with the time on the left column
            for (int i = 0; i < 30; i++)
            {
                output += time_array[i] + "   " + calendar[i].Split('/')[0] + ":" + calendar[i].Split('/')[1] + ":" + calendar[i].Split('/')[2];// +"   " + calendar[i + 30] + "   " + calendar[i + 60] + "   " + calendar[i + 90] + "   " + calendar[i + 120] + "   " + calendar[i + 150] + "   " + calendar[i + 180] + "\n";
                output += "   " + calendar[i+30].Split('/')[0] + ":" + calendar[i+30].Split('/')[1] + ":" + calendar[i+30].Split('/')[2];
                output += "   " + calendar[i + 60].Split('/')[0] + ":" + calendar[i + 60].Split('/')[1] + ":" + calendar[i + 60].Split('/')[2];
                output += "   " + calendar[i + 90].Split('/')[0] + ":" + calendar[i + 90].Split('/')[1] + ":" + calendar[i + 90].Split('/')[2];
                output += "   " + calendar[i + 120].Split('/')[0] + ":" + calendar[i +120].Split('/')[1] + ":" + calendar[i + 120].Split('/')[2];
                output += "   " + calendar[i + 150].Split('/')[0] + ":" + calendar[i + 150].Split('/')[1] + ":" + calendar[i + 150].Split('/')[2];
                output += "   " + calendar[i + 180].Split('/')[0] + ":" + calendar[i + 180].Split('/')[1] + ":" + calendar[i + 180].Split('/')[2]+'\n';
            }

                return output;
        }

        //adds an event to the calendar
        public String AddEvent(string calendar, int day, string name, string description, string start, string end)
        {
            //error handling
            if(calendar=="")
            {
                return "ERROR: Must create calendar first";
            }
            if(calendar.StartsWith("ERROR"))
            {
                return calendar;
            }
            //use the calendar class to get the time array
            Calendar myCalendar = new Calendar();
            String[] time_array = myCalendar.getTimeArray();
            //split the lines
            String[] cal = calendar.Split('\n');
            String first_entry = cal[0];
            String num = (first_entry.Split('/'))[0];
            int first = Int32.Parse(num);
            int date = day - first;
            //date++;
            int start_time=-1;
            int end_time=-1;

            //find the start time
            for (int i = 0; i < time_array.Length; i++ )
            {
                if (time_array[i] == start)
                {
                    start_time = i;
                }
            }

            //find the end time
            if(end=="09:00PM")
            {
                end_time=29;
            }
            else
            {
                for(int i = 0; i<time_array.Length; i++)
                {
                    if(time_array[i]==end)
                    {
                        end_time=i-1;
                    }
                }
            }

            //more error handling
            if(end_time==-1 || start_time==-1)
            {
                return "ERROR: time must be in format 00:00XX";
            }

            if(start_time>end_time)
            {
                return "ERROR: start time must be before end time";
            }

            //format the new row
            for (int x = start_time; x <= end_time; x++ )
            {
                cal[x + (date*30)] = day.ToString() + "/" + name + "/" + description + "/" + start + "/" + end;
            }

            //set up the output
            String output = "";
            for (int i = 0; i < cal.Length; i++)
            {
                output += cal[i] + "\n";
            }
            return output;
        }
    }
}
