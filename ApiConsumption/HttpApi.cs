using System;
using System.Net;
using System.Net.Http;

namespace ApiConsumption
{
    public static class HttpApi
    {
        private static HttpClient client = null;

        public static string GetApi(string path)
        {
            if (client == null)
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
                client = new HttpClient(handler);
            }
            client.BaseAddress = new Uri(path);
            HttpResponseMessage response = client.GetAsync("answers?order=desc&sort=activity&site=stackoverflow").Result;
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Result: " + result);

            return result;

        }
    }
}
