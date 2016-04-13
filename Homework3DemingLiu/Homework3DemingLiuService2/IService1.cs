using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Homework3DemingLiuService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/suggestion/{JSONlist}/{moneyToSpend}/{originAddr}")]
        GroceryList suggestion(string JSONlist, string moneyToSpend, string originAddr);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class Distance
    //{
    //    public string text { get; set; }
    //    public int value { get; set; }
    //}

    //[DataContract]
    //public class Duration
    //{
    //    public string text { get; set; }
    //    public int value { get; set; }
    //}

    //[DataContract]
    //public class Element
    //{
    //    public Distance distance { get; set; }
    //    public Duration duration { get; set; }
    //    public string status { get; set; }
    //}

    //[DataContract]
    //public class Row
    //{
    //    public Element[] elements { get; set; }
    //}

    //[DataContract]
    //public class DistanceMatrix
    //{
    //    public string[] destination_addresses { get; set; }
    //    public string[] origin_addresses { get; set; }
    //    public Row[] rows { get; set; }
    //    public string status { get; set; }
    //}

    [DataContract]
    public class GroceryList
    {
        [DataMember]
        public GroceryItem[] List { get; set; }
    }

    [DataContract]
    public class GroceryItem
    {
        private string itemName;           // Used to store item Name
        private int priority;               // Used to rank priority
        private double cost;              // Used to rank cost
        private int quantity;               // Used to specify the quantity
        private bool purchasedFlag;     // Used to signify whether an item has been purchased

        [DataMember]
        public string Name
        {
            get { return itemName; }
            set { itemName = value; }
        }

        [DataMember]
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        [DataMember]
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }

}
