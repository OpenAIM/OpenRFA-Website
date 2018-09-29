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
    class CsrfToken
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
        public static CsrfToken csrfToken = new CsrfToken();
        public static Session currentSession = new Session();
        public static string userName = string.Empty;
        public static string userPassword = string.Empty;

        /// <summary>
        /// Retrieves a CSRF token which is required to log in.
        /// </summary>
        public static void GetCsrfToken()
        {
            string token = string.Empty;

            // Get CSRF token using RestSharp
            var client = new RestClient(OpenRfa.baseUrl);
            var request = new RestRequest("rest/user/token.json", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            // Return token as string
            string json = response.Content;

            csrfToken = JsonConvert.DeserializeObject<CsrfToken>(json);
        }
        
        /// <summary>
        /// Log in using OpenRFA.org user credentials
        /// </summary>
        /// <returns>Data for current logged in session in JSON format.</returns>
        public static string LogIn()
        {

            string json = string.Empty;

            //// NOOB: This might be the secure way to login
            //RestClient restClient = new RestClient(OpenRfa.baseUrl)
            //{
            //    Authenticator = new HttpBasicAuthenticator(userName, password)
            //};

            var client = new RestClient(OpenRfa.baseUrl);

            // Set the data format to JSON because default is XML
            var request = new RestRequest("rest/user/login.json", Method.POST) { RequestFormat = RestSharp.DataFormat.Json };

            request.AddHeader("X-CSRF-Token", csrfToken.Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(new { username = userName, password = userPassword });

            IRestResponse response = client.Execute(request);

            json = response.Content;

            currentSession = JsonConvert.DeserializeObject<Session>(json);

            // TEMP: Show session data
            //MessageBox.Show(currentSession.Token, "Current Session Token");
            //MessageBox.Show(json, "Session Data");

            //// Copy raw session data to clipboard
            //Clipboard.SetText(json);

            return json;
        }
    }
}
