// This PHP snippet has been used as custom PHP code to be executed when
// a new Shared Parameter is proposed on OpenRFA.org (Drupal 7)

<?php

// Pass bot credentials from Zulip
$bot_username = "";
$bot_api_key = "";

// Get cURL resource
$curl = curl_init();

// Pass credentials to cURL resource
curl_setopt($curl, CURLOPT_USERPWD, $bot_name . ':' . $bot_key);

curl_setopt_array($curl, array(
    CURLOPT_RETURNTRANSFER => 1,
    CURLOPT_URL => 'https://openrfa.zulipchat.com/api/v1/messages',
    CURLOPT_POST => 1,
    CURLOPT_POSTFIELDS => array(
        type => 'stream',
        to => 'OpenRFA',
        subject => 'New Shared Parameter',
        content => '[node:author:name] has proposed a parameter called "[node:title]": [node:url]',
    )
));

// Send the request & save response to $resp
$resp = curl_exec($curl);

// Close request to clear up some resources
curl_close($curl);

?>