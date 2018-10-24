#!/usr/bin/env python3

import json
import zulip

# Downloaded ~/zuliprc from server and saved to Home dir
client = zulip.Client(config_file="~/zuliprc")

# Get the raw content of the message with ID "135735120"
result = client.get_raw_message(135735120)

# Make the JSON pretty
prettyResult = json.dumps(result, sort_keys=True, indent=4)

print(prettyResult)