using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace searchapi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Cyber Logic API endpoint URL
            string apiUrl = "https://xml.avra.vacations/services/webservice.asmx?op=HotelsSearch";

            // API credentials
            string userName = "xxxxxxxxxx";
            string password = "xxxxxxxxxx";

            // Request parameterss
            var requestData = new
            {
                Username = userName,
                Password = password,
                DateFrom = "2024-03-01", // Start date of the party’s stay (YYYY-MM-DD)
                DateTo = "2024-03-05",   // End date of the party’s stay (YYYY-MM-DD)
                Rooms = new
                {
                    Adults = 2, // Number of adults per room
                    Children = 0, // Number of children per room
                    ChildrenAges="" 
                },
                Language = "en",
                Location = "New York", // Search for hotels with names containing "New York"
               
            };

            try
            {
                // Serialize request data to JSON
                string jsonRequestData = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

                // Set up HttpClient
                using (var client = new HttpClient())
                {
                    // Set basic authentication credentials
                    var authValue = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(userName + ":" + password)));
                    client.DefaultRequestHeaders.Authorization = authValue;

                    // Create POST request content
                    var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

                    // Send POST request to the API endpoint
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Checks if the response is successful (HTTP status code 200-299)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and display response content
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response from API:");
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        // Handle error cases gracefully
                        Console.WriteLine("Error: " + response.StatusCode + " - " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
