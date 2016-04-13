using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework3TryItPage
{
    [Serializable]
    public class GroceryList
    {        
        public GroceryItem[] List { get; set; }
    }

    [Serializable]
    public class GroceryItem
    { 
        public string name { get; set; }
        public int priority { get; set; } 
        public double cost { get; set; }
        public int quantity { get; set; }
    }

}