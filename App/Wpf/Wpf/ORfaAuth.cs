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

    class ORfaAuth
    {
        public static CsrfToken csrfToken = new CsrfToken();
        public static string userName = string.Empty;
        public static string userPassword = string.Empty;

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
        
        public static string LogIn()
        {

            string sessionData = string.Empty;

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

            sessionData = response.Content;

            // TEMP: Show session data
            MessageBox.Show(sessionData, "Session Data");

            return sessionData;
        }
    }
}
