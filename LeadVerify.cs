using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Web;

namespace Lead_Verify_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build the URI
            UriBuilder uri = new UriBuilder();
            uri.Scheme = "https";
            uri.Host = "proapi.whitepages.com";
            uri.Path = "/3.1/lead_verify.json";

            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters.Add("api_key", Environment.GetEnvironmentVariable("LEAD_VERIFY_API_KEY"));
            parameters.Add("name", "Drama Number");
            parameters.Add("phone", "6464806649");
            parameters.Add("email_address", "medjalloh1@yahoo.com");
            parameters.Add("address_city", "Ashland");
            parameters.Add("address.postal_code", "59004");
            parameters.Add("address.state", "MT");
            parameters.Add("address.street_line_1", "302 Gorham Ave");
            parameters.Add("ip_address", "108.194.128.165");

            uri.Query = parameters.ToString();
            using(var httpClient = new HttpClient())
            {
                var rawJson = httpClient.GetStringAsync(uri.Uri).Result;
            
                // Parse JSON response
                var jsonMap = JObject.Parse(rawJson);

                var availableChecks = new [] {"name_checks", "phone_checks", "address_checks", "email_address_checks",
                                              "ip_address_checks"};

                // Display phone check results
                foreach (var check in availableChecks) {
                    Console.WriteLine(jsonMap[check].ToString());
                }
            }
        }
    }
}
