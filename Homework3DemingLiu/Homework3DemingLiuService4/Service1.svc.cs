using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace Homework3DemingLiuService4
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // Add method here to help the user find all the stores near their address and zip code
        public double findGasPrice()
        {
            string url = "http://www.fueleconomy.gov/ws/rest/fuelprices";
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";                                                              // GET method request
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();                // Obtain the HTML response
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");                               // Changes the encoding of the XML
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = responseStream.ReadToEnd();                                             // Reads the XML  String
            webresponse.Close();

            XmlReader reader = XmlReader.Create(new StringReader(result));  // Parse XML string
            reader.ReadToFollowing("regular");                              // Reads the double value in the string
            return reader.ReadElementContentAsDouble();                     // Return fetched value from the XML content

        }
    }
}