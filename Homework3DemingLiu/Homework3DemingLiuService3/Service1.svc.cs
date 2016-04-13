using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Homework3DemingLiuService3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // Add method here to help the user find all the stores near their address and zip code
        public string findNearestStore(string address)
        {
            string url = @"https://maps.googleapis.com/maps/api/place/textsearch/json?query=" + "grocery+store+near+" + address + "&type=grocery_or_supermarket&key=AIzaSyBYLeiP2Nv2h1G0ZAhuFNL60m7KqNZlWmE";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string res = reader.ReadToEnd();
            response.Close();
            PlaceSearch ps = JsonConvert.DeserializeObject<PlaceSearch>(res);

            // Find the nearest store based on the distance that needs to be traveled //
            int minDist = 0;
            int index = 0;
            for(int i = 0; i < ps.results.Length; i++)
            {
                url = @"http://maps.googleapis.com/maps/api/distancematrix/json?origins=" + address + "&destinations=" + ps.results[i].formatted_address + "&mode=driving&sensor=false&language=en-EN&units=imperial";
                request = (HttpWebRequest)WebRequest.Create(url);
                response = request.GetResponse();
                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream);
                res = reader.ReadToEnd();
                DistanceMatrix dm = JsonConvert.DeserializeObject<DistanceMatrix>(res);
                if (i == 0)
                {
                    minDist = dm.rows[0].elements[0].distance.value;
                    index = i;
                }
                int dist = dm.rows[0].elements[0].distance.value;
                if(dist < minDist)
                {
                    minDist = dist;
                    index = i;
                }
            }
            return ps.results[index].formatted_address;
        }

        public class Results
        {
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string icon { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public OpeningHours hour { get; set; }
            public Photos[] photo { get; set; }
            public string place_id { get; set; }
            public string price_level { get; set; }
            public string rating { get; set; }
            public string reference { get; set; }
            public string[] types { get; set; }
        }
        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Geometry
        {
            public Location location { get; set; }
        }
        public class OpeningHours
        {
            public bool openNow { get; set; }
            public string[] weekDayText { get; set; }
        }
        public class Photos
        {
            public int height { get; set; }
            public string[] html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }
        public class PlaceSearch
        {
            public string[] html_attributions { get; set; }
            public string next_page_token { get; set; }
            public Results[] results { get; set; }
            public string status { get; set; }
        }

        public class Distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Element
        {
            public Distance distance { get; set; }
            public Duration duration { get; set; }
            public string status { get; set; }
        }

        public class Row
        {
            public Element[] elements { get; set; }
        }

        public class DistanceMatrix
        {
            public string[] destination_addresses { get; set; }
            public string[] origin_addresses { get; set; }
            public Row[] rows { get; set; }
            public string status { get; set; }
        }

    }
}
