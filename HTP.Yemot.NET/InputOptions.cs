using HTP.Yemot.NET.Enums;

namespace HTP.Yemot.NET
{
    public class InputOptions
    {
        public InputOptions(InputMode inputMode)
        {
            //ערכי ברירת מחדל
            this.ValName = "val";
            this.ReEnterIfExists = false;
            switch (inputMode)
            {
                case InputMode.Tap:
                    this.Max = int.MaxValue;
                    this.Min = 1;
                    this.SecWait = 7;
                    this.PlayOkMode = InputType.NO;
                    this.BlockAsterisk = false;
                    this.BlockZero = false;
                    this.ReplaceChar = "";
                    this.DigitsAllowed = new int[0];
                    this.AmountAttempts = 0;
                    this.ReadNone = false;
                    this.ReadNoneVar = "";
                    this.BlockChangeTypeLang = false;
                    this.Confirmation = true;
                    break;
                case InputMode.STT:
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
        public InputMode InputMode { get; set; }

        /* שם הערך בימות
 ברירת מחדל, נקבע אוטומטית,
 val_1, val_2 ... */
        public string ValName { get; set; }
        /* האם לבקש את הערך שוב אם קיים. */
        public bool ReEnterIfExists { get; set; }


        //ערכי ברירת מחדל - הקשה

        /* כמות ההקשות המקסימלית */
        public int Max { get; set; }
        /* כמות ההקשות המינימלית */
        public int Min { get; set; }
        /* שניות להמתנה */
        public int SecWait { get; set; }
        /* צורת קליטת ההקשות שמשפיע גם על ההשמעה למשתמש את הקשותיו */
        /* באם מעוניינים במקלדת שונה ממקלדת ספרות, כגון EmailKeyboard או HebrewKeyboard, יש להכניס כאן את סוג המקלדת*/
        public InputType PlayOkMode { get; set; }
        /* האם לחסום הקשה על כוכבית */
        public bool BlockAsterisk { get; set; }
        /* האם לחסום הקשה על אפס */
        public bool BlockZero { get; set; }
        /* החלפת תווים*/
        public string ReplaceChar { get; set; }
        /* ספרות מותרות להקשה - מערך
[1, 2, 3 ...]
*/
        public int[] DigitsAllowed { get; set; }
        /* אחרי כמה שניות להשמיע שוב את השאלה */
        public int AmountAttempts { get; set; }
        /* אם המשתמש לא ענה, האם לשלוח ערך*/
        public bool ReadNone { get; set; }
        /* הערך שיישלח באין תשובה */
        public string ReadNoneVar { get; set; }
        /* האם לחסום שינוי שפת מקלדת */
        public bool BlockChangeTypeLang { get; set; }
        /* בקשת אישור על ההקשה/הקלטה */
        public bool Confirmation { get; set; }


        //ערכי ברירת מחדל - זיהוי דיבור
        public string Language { get; set; } // https://drive.google.com/file/d/1UC_KOjhZgPWZff8BcUfBLwMbSmKewy8A/view?usp=sharing

        public bool AllowTyping { get; set; }
        // זיהוי הקלטות בלבד
        public bool RecordingDetectionOnly { get; set; }
        //זמן מקסימלי של שקט לסיום ההקלטה
        public int QuietSeconds { get; set; }


        //ערכי ברירת מחדל - הקלטה
        //      path: "",
        public string Path { get; set; }

        //file_name: "",
        public string FileName { get; set; }

        ////record_ok: true,
        //public bool RecordOk { get; set; }

        //record_hangup: false,
        public bool RecordHangup { get; set; }

        //record_attach: false,
        public bool RecordAttach { get; set; }

        //length_min: "",
        public int LengthMin { get; set; }

        //length_max: "",
        public int LengthMax { get; set; }

    }
}
