using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Web;

namespace Identity_Check_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build the URI
            UriBuilder uri = new UriBuilder();
            uri.Scheme = "https";
            uri.Host = "proapi.whitepages.com";
            uri.Path = "/3.2/identity_check.json";

            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters.Add("api_key", Environment.GetEnvironmentVariable("ID_CHECK_API_KEY"));
            parameters.Add("primary.name", "Drama Number");
            parameters.Add("primary.phone", "6464806649");
            parameters.Add("primary.address.street_line_1", "302 Gorham Ave");
            parameters.Add("primary.address.city", "Ashland");
            parameters.Add("primary.address.state_code", "MT");
            parameters.Add("primary.address.postal_code", "59004");
            parameters.Add("primary.address.country_code", "US");
            parameters.Add("secondary.name", "Drama Number");
            parameters.Add("secondary.phone", "6464806649");
            parameters.Add("secondary.address.street_line_1", "302 Gorham Ave");
            parameters.Add("secondary.address.city", "Ashland");
            parameters.Add("secondary.address.state_code", "MT");
            parameters.Add("secondary.address.postal_code", "59004");
            parameters.Add("secondary.address.country_code", "US");
            parameters.Add("email_address", "medjalloh1@yahoo.com");
            parameters.Add("ip_address", "108.194.128.165");

            uri.Query = parameters.ToString();

            using(var httpClient = new HttpClient())
            {
                var rawJson = httpClient.GetStringAsync(uri.Uri).Result;
            
                // Parse JSON response
                var jsonMap = JObject.Parse(rawJson);

                var availableChecks = new [] {"primary_phone_checks", "primary_address_checks",
                                              "secondary_phone_checks", "secondary_address_checks",
                                              "email_address_checks", "ip_address_checks"};
                // Display results
                foreach (var check in availableChecks) {
                    Console.WriteLine(jsonMap[check].ToString());
                }
            }
        }
    }
}
