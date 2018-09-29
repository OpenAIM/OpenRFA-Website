# OpenRFA Desktop Application

Developer: Jay Merlan (https://github.com/jmerlan)

(License information coming soon.)

The OpenRFA Desktop Application is a desktop application built on C# and WPF. The purpose of the application has to be defined, however at a minimum the app should act as a shared parameter manager which would make simple REST API calls to OpenRFA.org rather than reading and writing to a local shared parameter text file.

The short-term goal is to build an application using OpenRFA.org's REST API to help with development of the API itself. The hope is that while developing this application, we will build solid code samples as well as API documention.

## API
Consider this documentation in a constant state of improvement. We will continue to write-up documentation as we further develop the API.

OpenRFA.org is currently built on Drupal 7.x, therefore the [Services](https://www.drupal.org/project/services) module has been used to implement the REST API.

Note: The API is only currently available on the development server: http://dev.openrfa.org. Please reach out to jmerlan or vdubya for administrator access.

### Endpoints

Retrieve CSRF Token
```rest/user/token.json```

Log in using OpenRFA.org
```rest/user/login.json```

### Sample Code

Request for Drupal Shared Parameter nodes
```csharp
            string data = string.Empty;

            var client = new RestClient(OpenRfa.baseUrl);

            // Set the data format to JSON because default is XML
            var request = new RestRequest("rest/node?parameters[type]=shared_parameter", Method.GET) { RequestFormat = RestSharp.DataFormat.Json };

            request.AddHeader("X-CSRF-Token", ORfaAuth.currentSession.Token);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            data = response.Content;
```