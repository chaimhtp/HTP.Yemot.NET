﻿using HTP.Yemot.NET.Enums;

namespace HTP.Yemot.NET
{
    public class MessageItem
    {
        public MessageItem(MessageItemType messageItemType, string value)
        {
            MessageItemType = messageItemType;
            Value = value;
        }
        public string Value { get; set; }
        public MessageItemType MessageItemType { get; set; }
    }
}
