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
    class SharedParameter
    {
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public string DataType { get; set; }
        public int NodeId { get; set; }

        public static string GetParameters()
        {
            string data = string.Empty;

            var client = new RestClient(OpenRfa.baseUrl);

            // Set the data format to JSON because default is XML
            var request = new RestRequest("rest/node?parameters[type]=shared_parameter", Method.GET) { RequestFormat = RestSharp.DataFormat.Json };

            request.AddHeader("X-CSRF-Token", ORfaAuth.currentSession.Token);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            data = response.Content;

            // TEMP: Show session data
            //MessageBox.Show(data, "Shared Parameters");
            MainWindow.RawData = data;

            return data;
        }

        /// <summary>
        /// Returns a shared parameter by its GUID
        /// </summary>
        /// <param name="guid">The GUID of the shared parameter</param>
        /// <returns>Shared parameter data in JSON</returns>
        public static string GetParameterByGuid (Guid guid)
        {
            string data = string.Empty;

            var client = new RestClient(OpenRfa.baseUrl);

            // Set the data format to JSON because default is XML
            var request = new RestRequest("rest/views/services_parameters?display_id=view_parameters&filters[guid]=" + guid, Method.GET) { RequestFormat = RestSharp.DataFormat.Json };

            request.AddHeader("X-CSRF-Token", ORfaAuth.currentSession.Token);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            data = response.Content;

            return data;
        }

    }

}
