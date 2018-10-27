# OpenRFA API Documentation
Consider this a living document. We will continue to write-up documentation as we further develop the API.

OpenRFA.org is currently built on Drupal 7.x, therefore the [Services](https://www.drupal.org/project/services) module has been configured to implement the REST API.

The API is only currently available on the development server: http://dev.openrfa.org. Users from the production site have been disabled on the dev site. If you would like to use the API, reach out to jmerlan or vdubya for access.

## Samples

### Retrieve CSRF Token
#### Method
```POST```
#### Endpoint
```rest/user/token.json```
#### C# Sample Code
```csharp
        public static string GetCsrfToken()
        {
            string token = string.Empty;

            // Get CSRF token using RestSharp
            var client = new RestClient("http://dev.openrfa.org");
            var request = new RestRequest("rest/user/token.json", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            // Return token as JSON object
            token = response.Content;

            return token;
        }
```

### Log in using OpenRFA.org
#### Method
```POST```
#### Endpoint
```rest/user/login.json```
#### C# Sample Code
```csharp
        public static string LogIn()
        {

            string json = string.Empty;

            // Login using RestSharp
            var client = new RestClient("http://dev.openrfa.org");

            // Set the data format to JSON because default is XML
            var request = new RestRequest("rest/user/login.json", Method.POST) { 
            	RequestFormat = RestSharp.DataFormat.Json
            };

            request.AddHeader("X-CSRF-Token", "k1qBSxDlnCOK8jgMnVbBxTn7HtnBABaxh0Bzu7Rre8Y");
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(new { username = "MartyMcFly", password = "helloooMcFly!" });

            IRestResponse response = client.Execute(request);

            // Returned user session data is in JSON format
            json = response.Content;

            return json;
        }
```

### Get Shared Parameters
#### Method
```GET```
#### Endpoint
```rest/views/services_parameters?display_id=view_parameters```

#### With Pagination (Five items per page, first page)
```rest/views/services_parameters?display_id=view_parameters&limit=5&offset=0```
### Filter Shared Parameter by GUID (368fac86-6f88-4553-999b-a17e7e822e19)
```rest/views/services_parameters?display_id=view_parameters&filters[guid]=368fac86-6f88-4553-999b-a17e7e822e19```
### Filter Shared Parameters by Name (name contains "code")
```rest/views/services_parameters?display_id=view_parameters&filters[name]=code```
### Filter Shared Paramters by State ("Approved")
```rest/views/services_parameters?display_id=view_parameters&filters[state_id]=3```
#### Shared Parameter State IDs
- (2) Proposed
- (3) Approved
- (4) Rejected

### Propose a New Share Parameter
#### Method
```POST```
#### Endpoint
```http://dev.openrfa.org/rest/node```
#### Required fields:
The following fields are required in your `POST` to propose a new shared parameter. Note that you also must be logged in with a user who has permissions to propose a shared parameter.
- type=shared_parameter
- title={{NameOfSharedParameter}}
- field_data_type={{DataTypeId}}
- field_group={{GroupId}}
- field_description={{Tooltip}}

**For ID numbers for field_data_type and field_group fields, refer to: http://openrfa.org/documentation/api/term-ids**

#### C# Sample Code
```csharp
        public static string NewParameter (Session session, string name, int dataTypeId, int groupId, string description)
        {
            // New node using RestSharp
            var client = new RestClient("http://dev.openrfa.org/rest/node.json");
            var request = new RestRequest(Method.POST) { RequestFormat = RestSharp.DataFormat.Json };

            // Session data from successul login
            request.AddHeader("X-CSRF-Token", session.Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddCookie(session.Name, session.Id);

            // Shared parameter data from arguments
            request.AddParameter("undefined", String.Format("{{\n   " +
                "\"title\":\"{0}\",\n   " +
                "\"type\":\"shared_parameter\",\n   " +
                "\"field_data_type\": {{\"und\":{{\"tid\":\"{1}\"}}}},\n   " +
                "\"field_group\": {{\"und\":{{\"tid\":\"{2}\"}}}},\n   " +
                "\"field_description\": {{\"und\": {{\"0\": {{\"value\": \"{3}\"}}}}}}\n}}\n", name, dataTypeId, groupId, description), 
                ParameterType.RequestBody);

            // Execute the request and store in a response
            IRestResponse response = client.Execute(request);

            // Return response as string
            return response.Content;
        }

```