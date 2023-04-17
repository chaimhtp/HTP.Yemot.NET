using HTP.Yemot.NET.Enums;
using System.Collections.Generic;

namespace HTP.Yemot.NET
{
    public class Exemple
    {
        public static string TapRead()
        {
            List<MessageItem> messages = new List<MessageItem>();
            messages.Add(new MessageItem(MessageItemType.Text, "שלום עולם"));
            messages.Add(new MessageItem(MessageItemType.Text, "ברוכים הבאים"));
            InputMode mode = InputMode.Tap;
            InputOptions options = new InputOptions(mode);
            options.ReEnterIfExists = false;
            options.DigitsAllowed = new int[] { 1, 2 };
            Read read = new Read(messages, mode, options);
            return read.ToResponseString();
        }

        public static string IdListMessage()
        {
            MessageItem item = new MessageItem(MessageItemType.Text, "שלום עולם");
            IdListMessage idListMessage = new IdListMessage();
            idListMessage.Add(item);
            return idListMessage.ToResponseString();
        }
    }
}
