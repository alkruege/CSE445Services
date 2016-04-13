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

namespace Homework3DemingLiuService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //  Add method here to generate a new grocery list of what you can buy based on 4 things: - Moderate Service()
        //  Distance of the nearest store from your address -findNearestStore():
        //  It will use this number to calculate gas prices using average MPG of a car
        //  Budget of the purchase - user input in double: 
        //  Priority of items - gathered from the existing list:
        //  Cost of the items involved - gathered from the existing list:
        public GroceryList suggestion(string JSONlist, string moneyToSpend, string originAddr)
        {
            //// Deserialize the JSON Objects list from the string //
            //GroceryList list = JsonConvert.DeserializeObject<GroceryList>(JSONlist);

            //GroceryList recommendedList = new GroceryList();
            //int item = 0;

            double budget = Convert.ToDouble(moneyToSpend);
            string url = @"http://localhost:49269/Service1.svc/findNearestStore/" + originAddr;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string res = reader.ReadToEnd();
            string destinationAddr = res;

            // Find the closest store based on the given result //
            url = @"http://maps.googleapis.com/maps/api/distancematrix/json?origins=" + originAddr + "&destinations=" + destinationAddr + "&mode=driving&sensor=false&language=en-EN&units=imperial";
            request = (HttpWebRequest)WebRequest.Create(url);
            response = request.GetResponse();
            responseStream = response.GetResponseStream();
            reader = new StreamReader(responseStream);
            res = reader.ReadToEnd();
            DistanceMatrix dm = JsonConvert.DeserializeObject<DistanceMatrix>(res);
            int distanceInMeters = dm.rows[0].elements[0].distance.value;
            double distanceInMiles = distanceInMeters / 1609.344;

            string urlGas = @"http://localhost:49274/Service1.svc/findGasPrice/";
            request = (HttpWebRequest)WebRequest.Create(urlGas);
            response = request.GetResponse();
            responseStream = response.GetResponseStream();
            reader = new StreamReader(responseStream);
            double gasPrices = Convert.ToDouble(reader.ReadToEnd());


            budget = budget - ((distanceInMiles / 25.5) * gasPrices);

            return new GroceryList();
            //// Formula to determine what you should buy
            //// suggestion score = (0.75)*Priority + (0.25)*(Cost); 
            //for (int i = 0; i < list.List.Length; i++)
            //{
            //    double score = (0.25) * list.List[i].Cost + (0.75) * list.List[i].Priority;
            //    if (score > 0.5)
            //    {
            //        if ((budget - (list.List[i].Quantity * list.List[i].Cost)) < 0)
            //        {
            //            recommendedList.List[item++] = list.List[i];
            //            budget -= (list.List[i].Quantity * list.List[i].Cost);
            //        }
            //    }
            //}
            //return recommendedList;
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
