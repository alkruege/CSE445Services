using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Homework3TryItPage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string urlGas = "http://localhost:49274/Service1.svc/findGasPrice/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlGas);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            String res = reader.ReadToEnd();
            Label1.Text = "$"+res;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string url = @"http://localhost:49269/Service1.svc/findNearestStore/" + TextBox1.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            String res = reader.ReadToEnd();
            Label3.Text = res;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            FileUpload1.SaveAs(Server.MapPath("GroceryLists\\"+FileUpload1.FileName));
            string[] lines = File.ReadAllLines(Server.MapPath(@"GroceryLists\\" + FileUpload1.FileName)); // This is to read the groceryList in a line

            // Now to convert the file into an object //
            // So each line obtained will be delimited to the following//
            // <name>,<priority>,<cost>,<quantity> //
            GroceryList list = new GroceryList();
            list.List = new GroceryItem[lines.Length];
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                list.List[i] = new GroceryItem();
                list.List[i].name = columns[0];
                list.List[i].priority = Convert.ToInt32(columns[1]);
                list.List[i].cost = Convert.ToDouble(columns[2]);
                list.List[i].quantity = Convert.ToInt32(columns[3]);
                i++;
            }
            //string json = JsonConvert.SerializeObject(list); // Serialize the object into JSON string
            //string encodedJson = EscapeStringValue(json);
            string url = "";
            switch (DropDownList1.SelectedIndex)
            {
                case 0:
                    url = @"http://localhost:64233/Service1.svc/sortByPriority/";
                    break;
                case 1:
                    url = @"http://localhost:64233/Service1.svc/sortByCost/";
                    break;
                case 2:
                    url = @"http://localhost:64233/Service1.svc/sortByQuantity/";
                    break;
            }

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //WebResponse response = request.GetResponse();
            //Stream responseStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(responseStream);
            //string res = reader.ReadToEnd();

            //var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    streamWriter.Write(encodedJson);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    string result = streamReader.ReadToEnd();
            //    list = JsonConvert.DeserializeObject<GroceryList>(result); // Deserialize the json string result
            //}

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(list);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                GroceryList sortedList = JsonConvert.DeserializeObject<GroceryList>(result); // Deserialize the json string result
                // Write back to the file //
                for (i = 0; i < sortedList.List.Length; i++)
                {
                    lines[i] = sortedList.List[i].name + "," + sortedList.List[i].priority + "," + sortedList.List[i].cost + "," + sortedList.List[i].quantity;
                }
                File.WriteAllLines(Server.MapPath("GroceryLists\\" + FileUpload1.FileName), lines);
                
                // Display sorted result on Table //
                TableRow[] tRow = new TableRow[lines.Length];
                for(int j = 0; j < lines.Length; j++)
                {
                    tRow[j] = new TableRow();
                    Table2.Rows.Add(tRow[j]);
                    TableCell tCell = new TableCell();
                    tRow[j].Cells.Add(tCell);
                    tCell.Text = sortedList.List[0].name;
                    for(int k = 0; k < 4; k++)
                    {
                        tRow[j].Cells.Add(tCell);
                        tCell.Text = sortedList.List[j].name;
                    }
                }
            }
        }

        static string EscapeStringValue(string value)
        {
            const char BACK_SLASH = '\\';
            const char SLASH = '/';
            const char DBL_QUOTE = '"';

            var output = new StringBuilder(value.Length);
            foreach (char c in value)
            {
                switch (c)
                {
                    case SLASH:
                        output.AppendFormat("{0}{1}", BACK_SLASH, SLASH);
                        break;

                    case BACK_SLASH:
                        output.AppendFormat("{0}{0}", BACK_SLASH);
                        break;

                    case DBL_QUOTE:
                        output.AppendFormat("{0}{1}", BACK_SLASH, DBL_QUOTE);
                        break;

                    default:
                        output.Append(c);
                        break;
                }
            }

            return output.ToString();
        }
    }
}