using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;


namespace Wpf
{
    public class CsrfToken
    {
        public string Token { get; set; }
    }

    public class Session
    {
        [JsonProperty("sessid")]
        public string Id { get; set; }

        [JsonProperty("session_name")]
        public string Name { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    class ORfaAuth
    {
        /// <summary>
        /// Retrieves a CSRF token which is required to log in.
        /// </summary>
        public static CsrfToken GetCsrfToken()
        {
            CsrfToken token = new CsrfToken();

            // Get CSRF token using RestSharp
            var client = new RestClient(OpenRfa.baseUrl);
            var request = new RestRequest("rest/user/token.json", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            // Pass token to MainWindow
            MainWindow.CsrfToken = JsonConvert.DeserializeObject<CsrfToken>(response.Content);

            return token;
        }
        
        /// <summary>
        /// Log in using OpenRFA.org user credentials
        /// </summary>
        /// <returns>Data for current logged in session in JSON format.</returns>
        public static string LogIn(string userName, string userPassword)
        {
            string json = string.Empty;

            GetCsrfToken();

            var client = new RestClient(OpenRfa.baseUrl);

            // Set the data format to JSON because default is XML
            var request = new RestRequest("rest/user/login.json", Method.POST) { RequestFormat = RestSharp.DataFormat.Json };

            request.AddHeader("X-CSRF-Token", MainWindow.CsrfToken.Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(new { username = userName, password = userPassword });

            IRestResponse response = client.Execute(request);

            json = response.Content;

            // Pass session data to MainWindow
            MainWindow.Session = JsonConvert.DeserializeObject<Session>(response.Content);

            return json;
        }

    }
}
