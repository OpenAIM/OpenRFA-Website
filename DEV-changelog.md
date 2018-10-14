2018-10-14
- Modified existing rule to include the cURL post to Zulip because having a separate rule wasn't passing the GUID properly.

2018-10-13
- Installed [rules_http_client](https://www.drupal.org/project/rules_http_client)
- Created rule "New Parameter" which executes PHP rule

2018-10-12
- Installed [OAuth2 Server](https://www.drupal.org/project/oauth2_server)
- Installed [X Autoload](https://www.drupal.org/project/xautoload)
- Added library to Drupal [oauth2-server-php](https://github.com/bshaffer/oauth2-server-php/tree/master/src/OAuth2)
- Created [OAuth Server](http://dev.openrfa.org/admin/structure/oauth2-servers)
- Add ["basic" Scope](http://dev.openrfa.org/admin/structure/oauth2-servers/manage/main/scopes)
- Added ["rocketchat" Client](http://dev.openrfa.org/admin/structure/oauth2-servers/manage/main/clients)
- Permissions: Allowed anonymouse user to use OAuth 2


2018-10-11
- Installed [Rocket.Chat](https://www.drupal.org/project/rocket_chat)

2018-10-10
- Installed [OneAll Social Login](https://www.drupal.org/project/social_login)

2018-10-07
- installed [oauth](https://www.drupal.org/project/oauth)

2018-09-30
- installed [services views](https://www.drupal.org/project/services_views)
- created view "services-parameters" for API calls

2018-09-29 JM:
- disabled [automatic node titles](https://www.drupal.org/project/auto_nodetitle)
- created COBie Attribute content type
- created taxonomy term COBie Sheet and added all terms from [spreadsheet](https://docs.google.com/spreadsheets/d/1ksQhyH6uilCvX40jxQeP6x-1r6Aq8vcAkTmVYsWbEa4/edit#gid=282739480)
- added  feed importer "COBie Attributes" for bulk importing COBie attributes from CSV
- imported COBie attributes
- added [COBie view](http://dev.openrfa.org/cobie)

2018-09-28 JM:
- configured services module and created REST API endpoint
- installed [services](https://www.drupal.org/project/services)
- installed [registry_autoload](https://www.drupal.org/project/registry_autoload)
- installed [plug](https://www.drupal.org/project/plug)
- upgraded server to php 5.6 (server-wide)
- installed [restful](https://www.drupal.org/project/restful)
- uninstalled restws module due to incompatibility with current Drupal versions
- installed [restws](https://www.drupal.org/project/restws)
- changed account creation permission to be restricted to admin only to prevent spambots registering and posting
- deleted all users except administrators

2018-09-27 JM:
- stood up dev.openrfa.org