using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1
{
	class Program
	{
		static async Task Main(string[] args)
		{
			if (args.Length == 1)
			{
				if (args[0] != null)
				{
					var url = args[0];
					var httpClient = new HttpClient();
					var response = await httpClient.GetAsync(url);
					if (response.IsSuccessStatusCode)
					{
						var htmlContent = await response.Content.ReadAsStringAsync();

						Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
						var emails = emailRegex.Matches(htmlContent);
						if (emails != null)
						{
							var uniqueMatches = emails
									.OfType<Match>()
									.Select(m => m.Value)
									.Distinct();
							uniqueMatches.ToList().ForEach(Console.WriteLine);
						}
						else
						{
							Console.WriteLine("No email addresses found");
						}
					}
					else
					{
						Console.WriteLine("An Error has occured");
					}
					httpClient.Dispose();
					response.Dispose();
				}
				else
				{
					throw new ArgumentException("Please Pass a valid URL");
				}

			}
			else
			{
				throw new ArgumentNullException("Please Pass one Url argument");
			}
		}
	}
}
