using HTP.Yemot.NET.Enums;

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
            switch (inputMode)
            {
                case InputMode.Tap:
                    this.Max = int.MaxValue;
                    this.Min = 1;
                    this.SecondsWait = 7;
                    this.PlayOkMode = InputType.NO;
                    this.BlockAsterisk = false;
                    this.BlockZero = false;
                    this.ReplaceChar = "";
                    this.DigitsAllowed = new int[0];
                    this.AmountAttempts = 0;
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
        /// > הקשה.
        /// > הקלטה לשמירה במערכת.
        /// > הקלטה שתתומלל לטקסט שיישלח לשרת.
        /// ברירת המחדל היא הקשה.
        /// </summary>
        public InputMode InputMode { get; set; }
        /// <summary>
        /// שם הפרמטר שיצורף לנתון שהתקבל.
        /// </summary>
        public string ParamName { get; set; }
        /// <summary>
        /// האם להשתמש בערך אם כבר קיים.
        /// ברירת מחדל המערכת לא משתשמת עם הערך אלא מבקשת שוב מהמשתמש.
        /// </summary>
        public bool ReUseIfExists { get; set; }
        /// <summary>
        /// הקשה/זיהוי דיבור. כמות הספרות המקסימלית שהמשתמש יוכל להקיש.
        /// ברירת המחדל היא ללא הגבלה.
        /// </summary>
        public int Max { get; set; }
        /// <summary>
        /// הקשה. כמות הספרות המינימלית שהמשתמש יוכל להקיש.
        /// ברירת מחדל 1.
        /// </summary>
        public int Min { get; set; }
        /* שניות להמתנה */
        /// <summary>
        /// הקשה. אורך הזמן שהמערכת תמתין להקשת המשתמש
        /// ברירת המחדל 7
        /// </summary>
        public double SecondsWait { get; set; }
        /// <summary>
        /// הקשה. באיזה צורה להשמיע למשתמש את מה שהוקש.
        /// ברירת מחדל InputType.Digits
        /// </summary>
        public InputType PlayOkMode { get; set; }
        /// <summary>
        /// הקשה. האם לחסום את מקש כוכבית.
        /// </summary>
        public bool BlockAsterisk { get; set; }
        /// <summary>
        /// הקשה. האם לחסום את מקש 0.
        /// </summary>
        public bool BlockZero { get; set; }
        /// <summary>
        /// הקשה. החלפת מקש בכל סימן אחר.
        /// ערך זה יכול להכיל 2 סימנים - הסימן הראשון את איזה ערך להחליף, הסימן השני זה מה לשים במקום מה שהוחלף.
        /// </summary>
        public string ReplaceChar { get; set; }
        /// <summary>
        /// הקשה. איזה מקשים המשתמש יוכל להקיש.
        /// ברירת מחדל ללא הגבלה.
        /// </summary>
        public int[] DigitsAllowed { get; set; }
        /// <summary>
        /// הקשה. כמות הפעמים שהמערכת משמיעה את השאלה לפני שהיא מגדירה את הנתון כריק.
        /// ברירת המחדל 1.
        /// </summary>
        public int AmountAttempts { get; set; }
        /// <summary>
        /// הקשה. האם לאפשר התקדמות עם נתון ריק.
        /// ברירת מחדל לא מאפשר
        /// </summary>
        public bool ReadNone { get; set; }
        /// <summary>
        /// הקשה. במדה ומאפשרים נתון ריק, מה יהיה הערך שיצורף.
        /// ברירת המחדל None
        /// </summary>
        public string ReadNoneValue { get; set; }
        /// <summary>
        /// הקשה. האם לחסום שינוי שפת מקלדת.
        /// במידה והוגדר מצב מקלדת - עברית/אנגלית/מקלדת מייל/מקלדת ספרות ב - PlayOkMode
        /// </summary>
        public bool BlockChangeTypeLang { get; set; }
        /// <summary>
        /// הקשה/זיהוי דיבור/הקלטה. בקשת אישור על ההקשה/הקלטה
        /// ברירת המחדל: מבקש אישור.
        /// </summary>
        public bool Confirmation { get; set; }
        /// <summary>
        /// זיהוי דיבור. באיזה שפה המערכת תזהה את הדיבור של המשתמש.
        /// ברירת המחדל היא עברית או מה שהוגדר כשפת השלוחה.
        /// רשימת השפות:
        /// https://drive.google.com/file/d/1UC_KOjhZgPWZff8BcUfBLwMbSmKewy8A/view?usp=sharing
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// זיהוי דיבור. האם לחסום את ההקשות של המשתמש.
        /// ברירת המחדל, המשתמש יכול להקיש או לדבר.
        /// </summary>
        public bool AllowTyping { get; set; }
        /// <summary>
        /// זיהוי דיבור. האם להפעיל זיהוי הקלטות בלבד.
        /// </summary>
        public bool RecordingDetectionOnly { get; set; }
        //זמן מקסימלי של שקט לסיום ההקלטה
        /// <summary>
        /// זיהוי דיבור. זמן מקסימלי של שקט לסיום ההקלטה.
        /// מופעל רק במידה והוגדר הפעלת זיהוי הקלטות בלבד RecordingDetectionOnly=true.
        /// </summary>
        public int QuietSeconds { get; set; }
        /// <summary>
        /// הקלטה. היכן תישמר ההקלטה במערכת.
        /// הערה: חובה לשים / בהתחלה. אסור לשים / בסוף
        /// ברירת מחדל נשמר בתיקייה שמוגדרת ב-api_dir
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// הקלטה. הגדרת את שם הקובץ שיישמר
        /// ברירת מחדל שם הקובץ ממוספר בצורה אוטומטית כמספר הגבוה ביותר בשלוחה.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// הקלטה. שמירה בניתוק שיחה.
        /// ברירת מחדל, ההקלטה לא נשמרת בשלוחה הרצויה.
        /// </summary>
        public bool RecordHangup { get; set; }
        /// <summary>
        /// הקלטה. הוספת ההקלטה החדשה על ההקלטה הקיימת.
        /// פעיל רק אם הוגדר שם קובץ זהה לקובץ קיים.
        /// ברירת מחדל, המערכת מוסיפה קובץ חדש בתוספת בשם תאריך ושעה נוכחיים
        /// </summary>
        public bool RecordAttach { get; set; }
        /// <summary>
        /// הקלטה. אורך המינימלי של ההקלטה בשניות
        /// </summary>
        public int LengthMin { get; set; }
        /// <summary>
        /// זיהוי דיבור/הקלטה. זמן מקסימלי להקלטה בשניות
        /// ברירת מחדל ללא הגבלה.
        /// הערה: בזיהוי דיבור הגדרה זו פעילה רק אם מופעל זיהוי הקלטה בלבד - RecordingDetectionOnly=true
        /// </summary>
        public int LengthMax { get; set; }

    }
}
