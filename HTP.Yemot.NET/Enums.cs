
namespace HTP.Yemot.NET.Enums
{
    public enum MessageItemType
    {
        //כל שינוי כאן, צריך לשנות בהתאם את רשימת הערכים למעלה: IdListMessageItemTypeValues
        File,
        Digits,
        Number,
        Alpha,
        /// <summary>
        /// חשוב! לא להכניס בטקסט את התווים נקודה (👈 .👉 ) וקו מפריד (👈 -👉 )
        /// </summary>
        Text,
        Speech,
        MusicOnHold,
        Date,
        DateH,
        Zmanim,
        SystemMessage,
        GoToFolder,
    }

    //public enum AudioDecorator
    //{
    //    /// <summary>
    //    /// ביפ
    //    /// </summary>
    //    Beep = 501,
    //    /// <summary>
    //    /// הצלחה
    //    /// </summary>
    //    Success = 502,
    //    /// <summary>
    //    /// כשלון
    //    /// </summary>
    //    Failure = 503,
    //    /// <summary>
    //    /// הודעה
    //    /// </summary>
    //    Message = 504,
    //    /// <summary>
    //    /// מחיאות כפיים
    //    /// </summary>
    //    Applause = 505,
    //}

    public enum InputMode
    {
        /// <summary>
        /// הקשה
        /// </summary>
        Tap,
        /// <summary>
        /// זיהוי דיבור
        /// </summary>
        STT,
        /// <summary>
        /// הקלטה
        /// </summary>
        Record
    }

    public enum InputType
    {
        Number,
        Digits,
        Price,
        Time,
        Date,
        HebrewDate,
        TeudatZehut,
        Phone,
        Alpha,
        HebrewKeyboard,
        EnglishKeyboard,
        EmailKeyboard,
        DigitsKeyboard,
        File,
        TTS,
        NO
    }


}
