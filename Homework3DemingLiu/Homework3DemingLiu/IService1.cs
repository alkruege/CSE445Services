using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Homework3DemingLiu
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/sortByPriority/")]
        GroceryList sortByPriority(GroceryList list);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/sortByCost/")]
        GroceryList sortByCost(GroceryList list);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/sortByQuantity/")]
        GroceryList sortByQuantity(GroceryList list);
    }

    [DataContract]
    public class GroceryList
    {
        [DataMember]
        public GroceryItem[] List { get; set; }
    }

    [DataContract]
    public class GroceryItem
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int priority { get; set; }
        [DataMember]
        public double cost { get; set; }
        [DataMember]
        public int quantity { get; set; }
    }
}
