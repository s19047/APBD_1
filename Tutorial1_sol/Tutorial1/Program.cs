using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1
{
    public class Program
    {
        
      public  static async Task Main(string[] args)
        {
            var websiteUrl = args[0];
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(websiteUrl);
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z0-9]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var emails = regex.Matches(htmlContent);

                foreach (var email in emails)
                {
                    Console.WriteLine(email.ToString());
                }

                Console.WriteLine("hello");
            }
        }
    }
}
