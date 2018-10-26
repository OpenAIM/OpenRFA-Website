#!/usr/bin/env python3

import zulip

# Download ~/zuliprc to your Home dir
client = zulip.Client(config_file="~/zuliprc")

# Send a stream message
request = {
    "type": "stream",
    "to": "OpenRFA",
    "subject": "New Shared Parameter",
    "content": "A new shared parameter has been proposed."
}
result = client.send_message(request)
print(result)

# Send a private message
request = {
    "type": "private",
    "to": "jay@openrfa.org",
    "content": "I come not, friends, to steal away your hearts."
}
result = client.send_message(request)
print(result)
