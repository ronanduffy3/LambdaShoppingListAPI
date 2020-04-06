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
            DELETEMethod();

            POSTMethod();
            Console.WriteLine("Added the items successfully");

            Console.WriteLine("Press enter to retrieve items from the list");
            Console.ReadLine();
            GETMethod();

            Console.WriteLine("Press enter to delete items from the list");
            Console.ReadLine();
            DELETEMethod();

            Console.WriteLine("Press enter to show the items have been removed from the list");
            GETMethod();
            
        }

        public static void POSTMethod()
         {
            // Creates a request with the link to our lambda function and using the HTTPWebRequest library for the connection.
            var request = (HttpWebRequest)WebRequest.Create("https://xx5jwpkp9b.execute-api.eu-west-1.amazonaws.com/Prod/v1/shoppingList");
            // Specifys that its a JSON request so we can use POST, GET and DELETE
            request.ContentType = "application/json";
            // Defines its a POST request which is writing data
            request.Method = "POST";

            // Creates an instance of the StreamWriter class to write and then use the JavascriptSerializer to format it as JSON
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    Name = "Water",
                    Quantity = 3
                });

                streamWriter.Write(json);
            }
            
            // Gets the server response and some light error handling
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
            // Similar to above I created a request and specified the type which is JSON and then what sort of request - DELETE
            var request = (HttpWebRequest)WebRequest.Create("https://xx5jwpkp9b.execute-api.eu-west-1.amazonaws.com/Prod/v1/shoppingList");
            request.ContentType = "application/json";
            request.Method = "DELETE";

            // use StreamWriter and JavaScriptSerializer same as above and performs the operation
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    Name = "Water",
                    Quantity = 3
                });

                streamWriter.Write(json);
            }

            // Some light error handling, same as above
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

        public static void GETMethod()
        {
            // Similar again as above, except didn't need to define the sort of request 
            var request = (HttpWebRequest)WebRequest.Create("https://xx5jwpkp9b.execute-api.eu-west-1.amazonaws.com/Prod/v1/shoppingList");
            var response = (HttpWebResponse)request.GetResponse();
            string responseString;
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    responseString = reader.ReadToEnd();
                }
                // Write the response to the command window.
                if(responseString != null) { 
                Console.WriteLine(responseString);
                }
                else
                {
                    Console.WriteLine("responseString string is null, no items on the list");
                    Console.ReadLine();
                }
            }
        }

    }

    
}
