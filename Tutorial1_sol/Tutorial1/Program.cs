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
           
            var websiteUrl = args.Length > 0 ? args[0] : throw new ArgumentNullException();
            var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync(websiteUrl);
                if (response.IsSuccessStatusCode)
                {
                    var htmlContent = await response.Content.ReadAsStringAsync();

                    var regex = new Regex("[a-z0-9]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var emails = regex.Matches(htmlContent);

                    if (emails.Count > 0) { 

                    foreach (var email in emails)
                    {
                        Console.WriteLine(email.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("no email addresses found");
                }
                    
                }
            }
            catch (Exception)
            {

                Console.WriteLine("error while dopwnloading page");
            }
            
            if(websiteUrl == null)
            {
                throw new ArgumentNullException("The url should contain the value");
            }
         

          
        }
    }
}
