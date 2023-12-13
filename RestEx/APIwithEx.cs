using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestEx
{
    public class APIwithEx
    {
        string baseurl = "https://reqres.in/api";

        /*public void GetsingleUser()
        {
            var client = new RestClient(baseurl);
            var req = new RestRequest("users/5", Method.Get);
            var response = client.Get(req);

            //with Error Exception

            if(!response.IsSuccessful )

            {
                try
                {
                    var errordetails = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);


                    if( errordetails != null )
                    {
                        Console.WriteLine($"API Error : {errordetails.Error}");
                    }

                }


                catch (JsonException)
                
                {
                
                Console.WriteLine("Failed to deserialize error response");
                
                }
            
            }

            else
            {
                Console.WriteLine(response.Content);
            }

        }
    }*/


        public void GetsingleUser()
        {
            var client = new RestClient(baseurl);
            var req = new RestRequest("users/55", Method.Get);
            var response = client.Execute(req);

            //with Error Exception

            if (!response.IsSuccessful)

            {

                if (IsJson(response.Content))
                {
                    try
                    {
                        var errordetails = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);


                        if (errordetails != null)
                        {
                            Console.WriteLine($"API Error : {errordetails.Error}");
                        }

                    }


                    catch (JsonException)

                    {

                        Console.WriteLine("Failed to deserialize error response");

                    }
                }





                else
                {
                    Console.WriteLine($"Non- Json error response :{response.Content}");
                }
            }


            static bool IsJson(string content)
            {
                try
                {
                    JToken.Parse(content);
                    return true;
                }

                catch (ArgumentNullException)
                {
                    return false;
                }
            }

        }

    }
}
