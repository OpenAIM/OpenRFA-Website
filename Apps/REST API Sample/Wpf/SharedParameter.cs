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
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("guid")]
        public Guid Guid { get; set; }
        [JsonProperty("data_type")]
        public string DataType { get; set; }
        [JsonProperty("field_group")]
        public string Group { get; set; }
        [JsonProperty("node_id")]
        public int NodeId { get; set; }
        [JsonProperty("state_id")]
        public int StateId { get; set; }

        public int GroupId { get; set; }
        public int DataTypeId { get; set; }

        public static string GetPagedParameters(int limit, int offset, int stateId, string sessionToken)
        {
            string json = string.Empty;

            var client = new RestClient(OpenRfa.baseUrl);

            string requestString = String.Format(
                "rest/views/services_parameters?display_id=view_parameters&limit={0}&offset={1}&filters[state_id]={2}", 
                limit, offset, stateId
                );

            // Set the data format to JSON because default is XML
            var request = new RestRequest(requestString, Method.GET) { RequestFormat = RestSharp.DataFormat.Json };
            
            // Session token is passed from MainWindow
            request.AddHeader("X-CSRF-Token", sessionToken);
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
        public static string GetParameterByGuid (Guid guid, string sessionToken)
        {
            string data = string.Empty;

            var client = new RestClient(OpenRfa.baseUrl);

            // Set the data format to JSON because default is XML
            var request = new RestRequest("rest/views/services_parameters?display_id=view_parameters&filters[guid]=" + guid, Method.GET) { RequestFormat = RestSharp.DataFormat.Json };

            // Session token is passed from MainWindow
            request.AddHeader("X-CSRF-Token", sessionToken);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            data = response.Content;

            return data;
        }

        /// <summary>
        /// Creates a new shared parameter on OpenRFA.org
        /// </summary>
        /// <param name="session">The current session to use for the token and cookie.</param>
        /// <param name="name">The name of the shared parameter.</param>
        /// <param name="dataTypeId">The ID of the data type (refer to http://openrfa.org/documentation/api/term-ids)</param>
        /// <param name="groupId">The ID of the group (refer to http://openrfa.org/documentation/api/term-ids)</param>
        /// <param name="description">The description (tooltip) for the shared parameter.</param>
        /// <returns></returns>
        public static string NewParameter (Session session, string name, int dataTypeId, int groupId, string description)
        {
            // TODO: Create proper C# object and serialize JSON
            //SharedParameter newParameter = new SharedParameter();
            //newParameter.Name = name;
            //newParameter.DataTypeId = dataTypeId;
            //newParameter.GroupId = groupId;
            //newParameter.Description = description;

            var client = new RestClient("http://dev.openrfa.org/rest/node.json");
            var request = new RestRequest(Method.POST) { RequestFormat = RestSharp.DataFormat.Json };
            request.AddHeader("X-CSRF-Token", session.Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddCookie(session.Name, session.Id);
            request.AddParameter("undefined", String.Format("{{\n   " +
                "\"title\":\"{0}\",\n   " +
                "\"type\":\"shared_parameter\",\n   " +
                "\"field_data_type\": {{\"und\":{{\"tid\":\"{1}\"}}}},\n   " +
                "\"field_group\": {{\"und\":{{\"tid\":\"{2}\"}}}},\n   " +
                "\"field_description\": {{\"und\": {{\"0\": {{\"value\": \"{3}\"}}}}}}\n}}\n", name, dataTypeId, groupId, description), 
                ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

    }

}
