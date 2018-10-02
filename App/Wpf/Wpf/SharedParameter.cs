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
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("guid")]
        public Guid Guid { get; set; }
        [JsonProperty("data_type")]
        public string DataType { get; set; }
        [JsonProperty("node_id")]
        public int NodeId { get; set; }

        //// Deprecated
        //public static string GetParameters()
        //{
        //    string data = string.Empty;

        //    var client = new RestClient(OpenRfa.baseUrl);

        //    // Set the data format to JSON because default is XML
        //    var request = new RestRequest("rest/node?parameters[type]=shared_parameter", Method.GET) { RequestFormat = RestSharp.DataFormat.Json };

        //    request.AddHeader("X-CSRF-Token", ORfaAuth.currentSession.Token);
        //    request.AddHeader("Content-Type", "application/json");

        //    IRestResponse response = client.Execute(request);

        //    data = response.Content;

        //    return data;
        //}

        public static string GetPagedParameters(int limit, int offset)
        {
            string json = string.Empty;

            var client = new RestClient(OpenRfa.baseUrl);

            // Set the data format to JSON because default is XML
            var request = new RestRequest(
                String.Format("rest/views/services_parameters?display_id=view_parameters&limit={0}&offset={1}", limit, offset),
                Method.GET
                ) { RequestFormat = RestSharp.DataFormat.Json };

            request.AddHeader("X-CSRF-Token", ORfaAuth.currentSession.Token);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            json = response.Content;

            return json;
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
