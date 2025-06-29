using HTP.Yemot.NET.Enums;
using System;

namespace HTP.Yemot.NET
{
    public class InputOptions
    {
        /// <summary>
        /// צורת קליטת נתוני משתמש והשמעת הנתונים שנקלטו למשתמש
        /// </summary>
        /// <param name="inputMode">הקשה/זיהוי דיבור/הקלטה. ברירת המחדל הקשה</param>
        public InputOptions(InputMode inputMode = InputMode.Tap)
        {
            //ערכי ברירת מחדל
            this.ParamName = "val";
            this.ReUseIfExists = false;
            this.InputMode = inputMode;
            this.DigitsAllowed = new int[0];
            switch (inputMode)
            {
                case InputMode.Tap:
                    this.Max = int.MaxValue;
                    this.Min = 1;
                    this.SecondsWait = 7;
                    this.PlayOkMode = InputType.Digits;
                    this.BlockAsterisk = false;
                    this.BlockZero = false;
                    this.ReplaceChar = "";
                    this.AmountAttempts = 1;
                    this.ReadNone = false;
                    this.ReadNoneValue = "";
                    this.BlockChangeTypeLang = false;
                    this.Confirmation = true;
                    break;
                case InputMode.Voice:
                    this.Language = "";
                    this.AllowTyping = false;
                    this.Max = int.MaxValue;
                    this.QuietSeconds = 6;
                    this.LengthMax = 9;
                    break;
                case InputMode.Record:
                    this.Path = "";
                    this.FileName = "";
                    this.Confirmation = true;
                    this.RecordHangup = false;
                    this.RecordAttach = false;
                    this.LengthMin = 0;
                    this.LengthMax = int.MaxValue;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// סוג הנתון שיילקח מהמשתמש:
        ///<para>
        /// ;הקשה
        /// ;הקלטה לשמירה במערכת
        /// ;הקלטה שתתומלל לטקסט שיישלח לשרת
        /// </para>
        /// <para>ברירת המחדל היא הקשה</para>
        /// </summary>
        public InputMode InputMode { get; set; }
        [Obsolete]
        /// <summary>
        /// שם הפרמטר שיצורף לנתון שהתקבל
        /// </summary>
        /// 
        public string ParamName { get; set; }
        /// <summary>
        /// האם להשתמש בערך אם כבר קיים
        ///<para>
        /// ברירת מחדל המערכת לא משתשמת עם הערך אלא מבקשת שוב מהמשתמש
        /// </para>
        /// </summary>
        public bool ReUseIfExists { get; set; }
        /// <summary>
        /// הקשה/זיהוי דיבור. כמות הספרות המקסימלית שהמשתמש יוכל להקיש
        /// <para>
        /// ברירת המחדל היא ללא הגבלה
        /// </para>
        /// </summary>
        public int Max { get; set; }
        /// <summary>
        /// הקשה. כמות הספרות המינימלית שהמשתמש יוכל להקיש
        /// <para>
        /// ברירת מחדל 1
        /// </para>
        /// </summary>
        public int Min { get; set; }
        /* שניות להמתנה */
        /// <summary>
        /// הקשה. אורך הזמן שהמערכת תמתין להקשת המשתמש
        /// <para>
        /// ברירת המחדל 7
        /// </para>
        /// </summary>
        public double SecondsWait { get; set; }
        /// <summary>
        /// הקשה. באיזה צורה להשמיע למשתמש את מה שהוקש
        /// <para>
        /// ברירת מחדל InputType.Digits במידה והוגדר Confirmation=true
        /// </para>
        /// </summary>
        public InputType PlayOkMode { get; set; }
        /// <summary>
        /// הקשה. האם לחסום את מקש כוכבית
        /// </summary>
        /// 
        public bool BlockAsterisk { get; set; }
        /// <summary>
        /// הקשה. האם לחסום את מקש 0.
        /// </summary>
        public bool BlockZero { get; set; }
        /// <summary>
        /// הקשה. החלפת מקש בכל סימן אחר
        /// <para>
        /// ערך זה יכול להכיל 2 סימנים - הסימן הראשון את איזה ערך להחליף, הסימן השני זה מה לשים במקום מה שהוחלף.
        /// </para>
        /// </summary>
        public string ReplaceChar { get; set; }
        /// <summary>
        /// הקשה. איזה מקשים המשתמש יוכל להקיש
        /// <para>
        /// ברירת מחדל ללא הגבלה
        /// </para>
        /// </summary>
        public int[] DigitsAllowed { get; set; }
        /// <summary>
        /// הקשה. כמות הפעמים שהמערכת משמיעה את השאלה לפני שהיא מגדירה את הנתון כריק
        /// <para>
        /// ברירת המחדל 1
        /// </para>
        /// </summary>
        public int AmountAttempts { get; set; }
        /// <summary>
        /// הקשה. האם לאפשר התקדמות עם נתון ריק
        /// <para>
        /// ברירת מחדל לא מאפשר
        /// </para>
        /// </summary>
        public bool ReadNone { get; set; }
        /// <summary>
        /// הקשה. במדה ומאפשרים נתון ריק, מה יהיה הערך שיצורף
        /// <para>
        /// ברירת המחדל None
        /// </para>
        /// </summary>
        public string ReadNoneValue { get; set; }
        /// <summary>
        /// הקשה. האם לחסום שינוי שפת מקלדת
        /// <para>
        /// במידה והוגדר מצב מקלדת - עברית/אנגלית/מקלדת מייל/מקלדת ספרות ב - PlayOkMode
        /// </para>
        /// </summary>
        public bool BlockChangeTypeLang { get; set; }
        /// <summary>
        /// הקשה/זיהוי דיבור/הקלטה. בקשת אישור על ההקשה/הקלטה
        /// <para>
        /// ברירת המחדל: מבקש אישור
        /// </para>
        /// </summary>
        public bool Confirmation { get; set; }
        /// <summary>
        /// זיהוי דיבור. באיזה שפה המערכת תזהה את הדיבור של המשתמש
        /// <para>
        /// ברירת המחדל היא עברית או מה שהוגדר כשפת השלוחה
        /// </para>
        /// רשימת השפות: <see href="https://drive.google.com/file/d/1UC_KOjhZgPWZff8BcUfBLwMbSmKewy8A/view?usp=sharing"/>
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// זיהוי דיבור. האם לחסום את ההקשות של המשתמש
        /// <para>
        /// ברירת המחדל, המשתמש יכול להקיש או לדבר.
        /// </para>
        /// </summary>
        public bool AllowTyping { get; set; }
        /// <summary>
        /// זיהוי דיבור. האם להפעיל זיהוי הקלטות בלבד
        /// </summary>
        public bool RecordingDetectionOnly { get; set; }
        //זמן מקסימלי של שקט לסיום ההקלטה
        /// <summary>
        /// זיהוי דיבור. זמן מקסימלי של שקט לסיום ההקלטה
        /// <para>
        /// מופעל רק במידה והוגדר הפעלת זיהוי הקלטות בלבד RecordingDetectionOnly=true
        /// </para>
        /// </summary>
        public int QuietSeconds { get; set; }
        /// <summary>
        /// הקלטה. היכן תישמר ההקלטה במערכת
        /// <para>
        /// ברירת מחדל נשמר בתיקייה שמוגדרת ב-api_dir
        /// </para>
        /// </summary>
        /// <remarks>
        /// הערה: חובה לשים / בהתחלה. אסור לשים / בסוף
        /// </remarks>
        public string Path { get; set; }
        /// <summary>
        /// הקלטה. הגדרת את שם הקובץ שיישמר
        /// ברירת מחדל שם הקובץ ממוספר בצורה אוטומטית כמספר הגבוה ביותר בשלוחה.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// הקלטה. שמירה בניתוק שיחה
        /// <para>
        /// ברירת מחדל, ההקלטה לא נשמרת בשלוחה הרצויה
        /// </para>
        /// </summary>
        public bool RecordHangup { get; set; }
        /// <summary>
        /// הקלטה. הוספת ההקלטה החדשה על ההקלטה הקיימת
        /// </para>
        /// ברירת מחדל, המערכת מוסיפה קובץ חדש בתוספת בשם תאריך ושעה נוכחיים
        /// </para>
        /// </summary>
        /// <remarks>
        /// פעיל רק אם הוגדר שם קובץ זהה לקובץ קיים
        /// </remarks>
        public bool RecordAttach { get; set; }
        /// <summary>
        /// הקלטה. אורך המינימלי של ההקלטה בשניות
        /// </summary>
        public int LengthMin { get; set; }
        /// <summary>
        /// זיהוי דיבור/הקלטה. זמן מקסימלי להקלטה בשניות
        /// <para>
        /// ברירת מחדל ללא הגבלה
        /// </para>
        /// </summary>
        /// <remarks>
        /// הערה: בזיהוי דיבור הגדרה זו פעילה רק אם מופעל זיהוי הקלטה בלבד - RecordingDetectionOnly=true
        /// </remarks>
        public int LengthMax { get; set; }

    }
}
