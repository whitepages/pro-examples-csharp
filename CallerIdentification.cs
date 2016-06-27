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
            uri.Path = "/3.0/caller_identification";

            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters.Add("api_key", Environment.GetEnvironmentVariable("CALLER_ID_API_KEY"));
            parameters.Add("phone", "6464806649");

            uri.Query = parameters.ToString();

            using(var httpClient = new HttpClient())
            {
                var rawJson = httpClient.GetStringAsync(uri.Uri).Result;

                // Parse JSON response
                var jsonMap = JObject.Parse(rawJson);

                // Display results
                Console.WriteLine(jsonMap);
            }
        }
    }
}
