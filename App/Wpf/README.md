# OpenRFA Desktop Application

Developer: Jay Merlan (https://github.com/jmerlan)

(License information coming soon.)

The OpenRFA Desktop Application is a desktop application built on C# and WPF. The purpose of the application has to be defined, however at a minimum the app should act as a shared parameter manager which would make simple REST API calls to OpenRFA.org rather than reading and writing to a local shared parameter text file.

The short-term goal is to build an application using OpenRFA.org's REST API to help with development of the API itself. The hope is that while developing this application, we will build solid code samples as well as API documention.

## API
Consider this documentation in a constant state of improvement. We will continue to write-up documentation as we further develop the API.

OpenRFA.org is currently built on Drupal 7.x, therefore the [Services](https://www.drupal.org/project/services) module has been used to implement the REST API.

Note: The API is only currently available on the development server: http://dev.openrfa.org. Please reach out to jmerlan or vdubya for administrator access.

### Endpoint Samples

#### Retrieve CSRF Token
```rest/user/token.json```

#### Log in using OpenRFA.org
```rest/user/login.json```

#### Get Shared Parameters
```rest/views/services_parameters?display_id=view_parameters```
##### With Pagination
```rest/views/services_parameters?display_id=view_parameters&limit=5&offset=0```

#### Fitler Shared Parameter by GUID
(shared parameter with GUID: 368fac86-6f88-4553-999b-a17e7e822e19)

```rest/views/services_parameters?display_id=view_parameters&filters[guid]=368fac86-6f88-4553-999b-a17e7e822e19```

#### Filter Shared Parameters by Name 
(shared parameters which name contains "code")

```rest/views/services_parameters?display_id=view_parameters&filters[name]=code```

#### Filter Shared Paramters by State
(shared parameters with Current State: "Approved")

```rest/views/services_parameters?display_id=view_parameters&filters[state_id]=3```

##### Shared Parameter State IDs
- (2) Proposed
- (3) Approved
- (4) Rejected
