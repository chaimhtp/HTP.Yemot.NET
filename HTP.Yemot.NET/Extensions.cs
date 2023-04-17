using HTP.Yemot.NET.Enums;
using System.Collections.Generic;

namespace HTP.Yemot.NET.Extensions
{
    internal static class Extensions
    {
        internal static string Concat(this List<MessageItem> messages)
        {
            //See an explanation here:
            //https://f2.freeivr.co.il/topic/31/%D7%94%D7%A9%D7%9E%D7%A2%D7%AA-%D7%A0%D7%AA%D7%95%D7%A0%D7%99%D7%9D-%D7%95%D7%94%D7%95%D7%93%D7%A2%D7%95%D7%AA-%D7%90%D7%99%D7%A9%D7%99%D7%95%D7%AA-id_message-id_list_message
            List<string> messageItemTypeValues = new List<string> { "f", "d", "n", "a", "t", "s", "h", "date", "dateH", "Z", "m", "g" }; // חייב להיות תואם ל MessageItemType enum
            string ret = "";
            foreach (MessageItem item in messages)
            {
                string typeVal = messageItemTypeValues[(int)item.MessageItemType];
                ret += $"{typeVal}-{item.Value}.";
            }
            ret = ret.Trim('.');
            return ret;
        }
        internal static string TrimCommas(this string str)
        {
            return str.Trim(',');
        }
    }
}
