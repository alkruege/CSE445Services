using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace CSE445Homework3
{
    public partial class _Default : Page
    {
        String calendar;
        String display;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }


        //create calendar
        protected void Button1_Click(object sender, EventArgs e)
        {
            calendar = Label35.Text;
            CSE445Homework3.ServiceReference1.Service1Client client = new CSE445Homework3.ServiceReference1.Service1Client();
            int start_date = Int32.Parse(TextBox6.Text);
            calendar = client.create_calendar(start_date);
            display = client.CalendarToDisplay(calendar);
            display_calendar();
            Label35.Text = calendar;
        }

        //add event
        protected void Button2_Click(object sender, EventArgs e)
        {
            calendar = Label35.Text;
            CSE445Homework3.ServiceReference1.Service1Client client = new CSE445Homework3.ServiceReference1.Service1Client();
            //int start_date = Int32.Parse(TextBox6.Text);
            //calendar = client.create_calendar(start_date);
            int date = Int32.Parse(TextBox9.Text);
            string name = TextBox7.Text;
            string description = TextBox8.Text;
            string start = TextBox10.Text;
            string end = TextBox11.Text;
            calendar = client.AddEvent(calendar, date, name, description, start, end);
            if(calendar=="")
            {
                Label4.Text = "Create a Calendar First";
            }
            else if(calendar.StartsWith("ERROR"))
            {
                Label4.Text = calendar;
            }
            else
            {
                display = client.CalendarToDisplay(calendar);
                display_calendar();
            }
            Label35.Text = calendar;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            calendar = Label35.Text;
            CSE445Homework3.ServiceReference1.Service1Client client1 = new CSE445Homework3.ServiceReference1.Service1Client();
            CSE445Homework3.ServiceReference2.Service2Client client2 = new CSE445Homework3.ServiceReference2.Service2Client();
            int date = Int32.Parse(TextBox1.Text);
            string start = TextBox2.Text;
            string end = TextBox3.Text;
            string name = TextBox4.Text;
            string description = TextBox5.Text;

            int value = 0;

            if(DropDownList1.SelectedIndex==0)
            {
                value = 1;
            }
            if (DropDownList1.SelectedIndex == 1)
            {
                value = -1;
            }
            calendar = client2.editEvent(calendar, value, date, name, description, start, end);
            if (calendar == "")
            {
                Label4.Text = "Create a Calendar First";
            }
            else if (calendar.StartsWith("ERROR"))
            {
                Label4.Text = calendar;
            }
            else
            {
                display = client1.CalendarToDisplay(calendar);
                display_calendar();
            }

            Label35.Text = calendar;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            calendar = Label35.Text;
            int days = Int32.Parse(TextBox13.Text);
            int years= Int32.Parse(TextBox14.Text);
            string url = @"http://localhost:8003/Service3.svc/hours/" + days.ToString()+"/"+years.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String output = reader.ReadToEnd();

            XmlReader read = XmlReader.Create(new StringReader(output));
            read.ReadToFollowing("int");
            int free=read.ReadElementContentAsInt();
            
            Label1.Text = "Awake Time (hours): " + free;
            Label35.Text = calendar;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            calendar = Label35.Text;
            string type = (TextBox15.Text);
            string value = (TextBox12.Text);
            string url = @"http://localhost:8004/Service5.svc/temp/" + type + "/" + value;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String output = reader.ReadToEnd();

            XmlReader read = XmlReader.Create(new StringReader(output));
            read.ReadToFollowing("double");
            double temp = read.ReadElementContentAsDouble();

            Label2.Text = "Temperature: " + temp;
            Label35.Text = calendar;
        }

        public void display_calendar()
        {
            Label4.Text = (display.Split('\n'))[0];
            Label5.Text = (display.Split('\n'))[1];
            Label6.Text = (display.Split('\n'))[2];
            Label7.Text = (display.Split('\n'))[3];
            Label8.Text = (display.Split('\n'))[4];
            Label9.Text = (display.Split('\n'))[5];
            Label10.Text = (display.Split('\n'))[6];
            Label11.Text = (display.Split('\n'))[7];
            Label12.Text = (display.Split('\n'))[8];
            Label13.Text = (display.Split('\n'))[9];
            Label14.Text = (display.Split('\n'))[10];
            Label15.Text = (display.Split('\n'))[11];
            Label16.Text = (display.Split('\n'))[12];
            Label17.Text = (display.Split('\n'))[13];
            Label18.Text = (display.Split('\n'))[14];
            Label19.Text = (display.Split('\n'))[15];
            Label20.Text = (display.Split('\n'))[16];
            Label21.Text = (display.Split('\n'))[17];
            Label22.Text = (display.Split('\n'))[18];
            Label23.Text = (display.Split('\n'))[19];
            Label24.Text = (display.Split('\n'))[20];
            Label25.Text = (display.Split('\n'))[21];
            Label26.Text = (display.Split('\n'))[22];
            Label27.Text = (display.Split('\n'))[23];
            Label28.Text = (display.Split('\n'))[24];
            Label29.Text = (display.Split('\n'))[25];
            Label30.Text = (display.Split('\n'))[26];
            Label31.Text = (display.Split('\n'))[27];
            Label32.Text = (display.Split('\n'))[28];
            Label33.Text = (display.Split('\n'))[29];


        }

        
    }
}