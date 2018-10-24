#!/usr/bin/env python3

import zulip

# Download ~/zuliprc to home dir
client = zulip.Client(config_file="~/zuliprc")

# Render a message
request = {
    'content': '**foo**'
}
result = client.render_message(request)
print(result)