#!/usr/bin/env python3

import json
import zulip

# Downloaded ~/zuliprc from server and saved to Home dir
client = zulip.Client(config_file="~/zuliprc")

# Get the 3 last messages sent by "jay" to the stream "general"
request = {
    'use_first_unread_anchor': True,
    'num_before': 3,
    'num_after': 0,
    'narrow': [{'operator': 'sender', 'operand': 'jay@openrfa.org'},
               {'operator': 'stream', 'operand': 'general'}],
    'client_gravatar': True,
    'apply_markdown': True
}  # type: Dict[str, Any]

result = client.get_messages(request)

# Make the JSON pretty
prettyResult = json.dumps(result, sort_keys=True, indent=4)

print(prettyResult)