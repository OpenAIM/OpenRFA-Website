#!/usr/bin/env python

import json
import sys
import zulip

# Download ~/zuliprc and save to your Home dir
client = zulip.Client(config_file="~/zuliprc")


def GetEvents(queueId):
    result = client.get_events(
        queue_id=queueId,
        last_event_id=-1
        )

    return result


def RegisterEventQueue():

    result = client.register(
        event_types=['message']
    )

    # Return Queue ID
    return result["queue_id"]


queue_id = RegisterEventQueue()

print(queue_id)

print(client.get_events(
    queue_id=queue_id,
    last_event_id=-1
))

# events = GetEvents(queue_id)

#print(events)