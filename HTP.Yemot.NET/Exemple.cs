using HTP.Yemot.NET.Enums;
using System.Collections.Generic;

namespace HTP.Yemot.NET
{
    public class Exemple
    {
        /// <summary>
        /// מאפשר להקריא למשתמש פריט מסויים
        /// ולבחור מקש 1/2/3 תוך כדי ההשמעה (כמעט אין זמן להגיב - 0.1 שניות)
        /// או לא לבחור.
        /// המערכת לא תבקש אישור.
        /// </summary>
        /// <param name="paramName">שם הפרמטר</param>
        /// <param name="itemValue">ערך הפריט</param>
        /// <returns></returns>
        public static string TapRead(string paramName, string itemValue)
        {
            List<MessageItem> messages = new List<MessageItem>();
            messages.Add(new MessageItem(MessageItemType.Text, "פריט"));
            messages.Add(new MessageItem(MessageItemType.Text, itemValue));
            InputOptions options = new InputOptions();
            options.ParamName = paramName;
            options.Min = 0;
            options.SecondsWait = 0.1;
            options.Confirmation = false;
            options.ReadNone = true;
            options.ReadNoneValue = "2";
            options.DigitsAllowed = new int[] { 1, 2, 3};
            Read read = new Read(messages, options);
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
