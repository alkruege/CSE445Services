using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Homework3DemingLiu
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public GroceryList sortByPriority(GroceryList list)
        {
            int min2;
            for (int i=0; i < list.List.Length; i++)
            {
                min2 = i;
                for (int j=i+1; j < list.List.Length; j++)
                {
                    if (list.List[j].priority < list.List[min2].priority)
                    {
                        min2 = j;
                    }
                }
                if (min2 != i)
                {
                    GroceryItem temp = list.List[min2];
                    list.List[min2] = list.List[i];
                    list.List[i] = temp;
                }
            }
            return list;
        }

        public GroceryList sortByCost(GroceryList list)
        {
            int min1;
            for (int i = 0; i < list.List.Length; i++)
            {
                min1 = i;
                for (int j = i + 1; j < list.List.Length; j++)
                {
                    if (list.List[j].cost < list.List[min1].cost)
                    {
                        min1 = j;
                    }
                }
                if (min1 != i)
                {
                    // Swaps the two objects with a temporary variable //
                    GroceryItem temp = list.List[min1];
                    list.List[min1] = list.List[i];
                    list.List[i] = temp;
                }
            }
            return list;
        }
        // Add method here to sort items based on user choice   - Moderate Service
        public GroceryList sortByQuantity(GroceryList list)
        {
            int min3;
            for (int i = 0; i < list.List.Length; i++)
            {
                min3 = i;
                for (int j = i + 1; j < list.List.Length; j++)
                {
                    if (list.List[j].quantity < list.List[min3].quantity)
                    {
                        min3 = j;
                    }
                }
                if (min3 != i)
                {
                    GroceryItem temp = list.List[min3];
                    list.List[min3] = list.List[i];
                    list.List[i] = temp;
                }
            }
            return list;
        }
    }
}
