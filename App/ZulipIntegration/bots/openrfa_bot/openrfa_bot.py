import zulip

class OpenRfaBot(object):
    '''
    The bot helps bridge OpenRFA.org with Zulip.
    '''

    def usage(self):
        return '''The bot helps bridge OpenRFA.org with Zulip'''

    def handle_message(self, message, bot_handler):
        original_content = message['content']
        original_sender = message['sender_email']
        new_content = original_content.replace('@jay',
                                               'from %s:' % (original_sender,))

        bot_handler.send_message(dict(
            type='stream',
            to='jay',
            subject=message['sender_email'],
            content=new_content,
        ))

handler_class = OpenRfaBot