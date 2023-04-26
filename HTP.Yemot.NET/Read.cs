using HTP.Yemot.NET.Enums;
using HTP.Yemot.NET.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace HTP.Yemot.NET
{
    // הסבר בלינק https://f2.freeivr.co.il/topic/56/%D7%9E%D7%95%D7%93%D7%95%D7%9C-api-%D7%AA%D7%A7%D7%A9%D7%95%D7%A8-%D7%A2%D7%9D-%D7%9E%D7%97%D7%A9%D7%91%D7%99%D7%9D-%D7%95%D7%9E%D7%9E%D7%A9%D7%A7%D7%99-%D7%A0%D7%AA%D7%95%D7%A0%D7%99%D7%9D-%D7%97%D7%99%D7%A6%D7%95%D7%A0%D7%99%D7%99%D7%9D/5?_=1681665991555
    // נכתב בהשראת https://github.com/ShlomoCode/yemot-router2
    public class Read
    {
        public Read(List<MessageItem> messages,InputOptions options)
        {
            this.Messages = messages;
            if (options.DigitsAllowed.Length > 0)
            {
                options.Max = options.DigitsAllowed.Max(x => x.ToString().Length);
            }
            this.InputOptions = options;
        }
        public InputMode InputMode { get; set; }
        public InputOptions InputOptions { get; set; }
        public List<MessageItem> Messages { get; set; }

        public string ToResponseString()
        {
            string ret = $"read={this.Messages.Concat()}=";
            InputOptions opt = this.InputOptions;
            switch (this.InputMode)
            {
                case InputMode.Tap:
                    ret += TapParameters();
                    break;
                case InputMode.Voice:
                    ret += VoiceParameters();
                    break;
                case InputMode.Record:
                    ret += RecordParameters();
                    break;
                default:
                    break;
            }
            return ret;
        }

        private string TapParameters()
        {
            InputOptions o = this.InputOptions;
            string[] prms = new string[16];
            prms[0] = "";
            prms[1] = $"{o.ParamName}"; // שם
            prms[2] = $"{(o.ReUseIfExists ? "yes" : "")}"; // שימוש בערך אם כבר קיים
            prms[3] = $"{(o.Max != int.MaxValue ? o.Max.ToString() : "")}"; // מקסימום ספרות
            prms[4] = $"{o.Min}"; // מינימום ספרות
            prms[5] = $"{o.SecondsWait}"; // זמן המתנה להקשה
            prms[6] = $"{Enum.GetName(typeof(InputType), o.PlayOkMode)}"; // צורת השמעת ההקשות למשתמש
            prms[7] = $"{(o.BlockAsterisk ? "yes" : "")}"; // האם לחסום כוכבית
            prms[8] = $"{(o.BlockZero ? "yes" : "")}"; // האם לחסום כמות אפס
            prms[9] = $"{o.ReplaceChar}"; // החלפת תווים
            prms[10] = $"{string.Join(".", o.DigitsAllowed)}"; // מקשים מותרים
            prms[11] = $"{o.AmountAttempts}"; // חזרה על השאלה
            prms[12] = $"{(o.ReadNone ? "Ok" : "")}"; // האם לאפשר ערך ריק
            prms[13] = $"{(o.ReadNone && !string.IsNullOrWhiteSpace(o.ReadNoneValue) ? o.ReadNoneValue : "")}"; // ערך שנשלח לשרת במידה וריק
            prms[14] = $"{((o.PlayOkMode == InputType.HebrewKeyboard || o.PlayOkMode == InputType.EnglishKeyboard || o.PlayOkMode == InputType.EmailKeyboard || o.PlayOkMode == InputType.DigitsKeyboard) && o.BlockChangeTypeLang ? "InsertLettersTypeChangeNo" : "")}"; // חסימת שינוי מקלדת
            prms[15] = $"{(!o.Confirmation ? "no" : "")}"; // בקשת אישור הקשה

            string joinedParams = string.Join(",", prms);
            return joinedParams.TrimCommas();
        }
        private string VoiceParameters()
        {
            InputOptions o = this.InputOptions;
            string[] prms = new string[10];
            prms[0] = "";
            prms[1] = $"{o.ParamName}"; // שם
            prms[2] = $"{(o.ReUseIfExists ? "yes" : "")}"; // שימוש בערך אם כבר קיים
            prms[3] = "voice"; // סוג הנתון הנלקח מהמשתמש
            prms[4] = $"{(o.Language)}"; // שפת זיהוי
            prms[5] = $"{(!o.AllowTyping ? "no" : "")}"; // חסימת הקשות
            prms[6] = $"{(o.AllowTyping ? o.Max.ToString() : "")}"; // מקסימום ספרות
            prms[7] = $"{(o.RecordingDetectionOnly ? "record" : "")}"; // האם להפעיל זיהוי הקלטות בלבד
            prms[8] = $"{(o.RecordingDetectionOnly ? o.QuietSeconds.ToString() : "")}"; // זמן מקסימלי של שקט לסיום ההקלטה
            prms[9] = $"{(o.RecordingDetectionOnly ? o.LengthMax.ToString() : "")}"; // זמן המקסימלי להקלטה

            string joinedParams = string.Join(",", prms);
            return joinedParams.TrimCommas();
        }
        private string RecordParameters()
        {
            InputOptions o = this.InputOptions;
            string[] prms = new string[11];
            prms[0] = "";
            prms[1] = $"{o.ParamName}"; // שם
            prms[2] = $"{(o.ReUseIfExists ? "yes" : "")}"; // שימוש בערך אם כבר קיים
            prms[3] = "record"; // סוג הנתון הנלקח מהמשתמש
            prms[4] = $"{o.Path}"; // תיקיית הקלטות
            prms[5] = $"{o.FileName}"; // שם הקובץ
            prms[6] = $"{(!o.Confirmation ? "no" : "")}"; // אישור מיידי של ההקלטה
            prms[7] = $"{(o.RecordHangup ? "yes" : "")}"; // שמירה בניתוק השיחה
            prms[8] = $"{(!string.IsNullOrWhiteSpace(o.FileName) && o.RecordAttach ? "yes" : "")}"; // הוספה על הקלטה קיימת
            prms[9] = $"{o.LengthMin}"; // אורך מינימלי להקלטה
            prms[10] = $"{o.LengthMax}"; // אורך מקסימלי להקלטה

            string joinedParams = string.Join(",", prms);
            return joinedParams.TrimCommas();
        }
    }
}
