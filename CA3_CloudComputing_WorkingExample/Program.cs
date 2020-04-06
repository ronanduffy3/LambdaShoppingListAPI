using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CA3_CloudComputing_WorkingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
        }

        public static void POSTMethod()
         {
            var request = (HttpWebRequest)WebRequest.Create("https://xx5jwpkp9b.execute-api.eu-west-1.amazonaws.com/Prod/v1/shoppingList");
            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    Name = "Water",
                    Quantity = 1
                });

                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();
            try
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch
            {
                Console.WriteLine("Exception");
            }

            Console.ReadLine();
        }
        
        public static void DELETEMethod()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://xx5jwpkp9b.execute-api.eu-west-1.amazonaws.com/Prod/v1/shoppingList");
            request.ContentType = "application/json";
            request.Method = "DELETE";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    Name = "Water",
                    Quantity = 3
                });

                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();
            try
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch
            {
                Console.WriteLine("Exception");
            }
        }

    }

    
}
