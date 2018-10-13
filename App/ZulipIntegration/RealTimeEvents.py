#!/usr/bin/env python

import sys
import zulip

# Download ~/zuliprc from your dev server and save to Home dir
client = zulip.Client(config_file="~/zuliprc")

# Print every message the current user would receive
# This is a blocking call that will run forever
client.call_on_each_message(lambda msg: sys.stdout.write(str(msg) + "\n"))

# Print every event relevant to the user
# This is a blocking call that will run forever
client.call_on_each_event(lambda event: sys.stdout.write(str(event) + "\n"))
