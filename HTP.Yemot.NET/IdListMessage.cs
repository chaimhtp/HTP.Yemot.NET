using HTP.Yemot.NET.Enums;
using HTP.Yemot.NET.Extensions;
using System.Collections.Generic;

namespace HTP.Yemot.NET
{
    //See an explanation here:
    //https://f2.freeivr.co.il/topic/31/%D7%94%D7%A9%D7%9E%D7%A2%D7%AA-%D7%A0%D7%AA%D7%95%D7%A0%D7%99%D7%9D-%D7%95%D7%94%D7%95%D7%93%D7%A2%D7%95%D7%AA-%D7%90%D7%99%D7%A9%D7%99%D7%95%D7%AA-id_message-id_list_message
    public class IdListMessage 
    {
        public IdListMessage()
        {
            this.MessageItems = new List<MessageItem>();
        }
        public List<MessageItem> MessageItems { get; set; }
        public void Add(MessageItem messageItem)
        {
            MessageItems.Add(messageItem);
        }
        public string ToResponseString()
        {
            string ret = "id_list_message=";
            ret += this.MessageItems.Concat();
            ret += "&";
            return ret;
        }
    }
}
