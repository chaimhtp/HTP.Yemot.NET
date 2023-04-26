# HTP.Yemot.NET
<div dir="rtl" text-align="right">

הגדרות [מודול API](https://f2.freeivr.co.il/post/76) של 'ימות המשיח' באמצעות NET.


# דוגמא בסיסית

[./Exemple.cs](https://github.com/chaimhtp/HTP.Yemot.NET/blob/main/HTP.Yemot.NET/Exemple.cs)

<div dir="ltr" text-align="left">

<details>
<summary>פרטים</summary>

<div dir="rtl" text-align="right">
מאפשר להקריא למשתמש פריט מסויים ולבחור מקש 1/2/3 תוך כדי ההשמעה (כמעט אין זמן להגיב - 0.1 שניות) או לא לבחור.
המערכת לא תבקש אישור.

<div dir="ltr" text-align="left">

```js
public static string TapRead(string paramName, string itemName)
{
    List<MessageItem> messages = new List<MessageItem>();
    messages.Add(new MessageItem(MessageItemType.Text, "פריט"));
    messages.Add(new MessageItem(MessageItemType.Text, itemName));
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
```

<div dir="rtl" text-align="right">

תוצאת הפונקציה:

<div dir="ltr" text-align="left">

"read=t-פריט.t-שם הפריט=param_x,,1,0,0.1,NO,,,,1.2.3,0,Ok,2,,no"

<div dir="ltr" text-align="left">

```js
public static string IdListMessage()
{
    MessageItem item = new MessageItem(MessageItemType.Text, "שלום עולם");
    IdListMessage idListMessage = new IdListMessage();
    idListMessage.Add(item);
    return idListMessage.ToResponseString();
}
```
<div dir="rtl" text-align="right">

תוצאת הפונקציה:

<div dir="ltr" text-align="left">

"id_list_message=t-שלום עולם&"

</details>


# IdListMessage
[./IdListMessage.cs](https://github.com/chaimhtp/HTP.Yemot.NET/blob/main/HTP.Yemot.NET/IdListMessage.cs)

<div dir="ltr" text-align="left">

```js
IdListMessage idListMessage = new IdListMessage();
idListMessage.Add(messageItem);
idListMessage.ToResponseString(); // id_list_message=t-שלום עולם&
```
<details>
<summary>פרטים</summary>

### MessageItem

```js
MessageItem(MessageItemType messageItemType, string value)
```
```js
MessageItem item = new MessageItem(MessageItemType.Text, "שלום עולם");
```
```js
MessageItem item = new MessageItem(MessageItemType.File, "001")
```
```js
MessageItem item = new MessageItem(MessageItemType.DateH, "21/12/2022")
```

### MessageItemType
```js
public enum MessageItemType
{
    /// <summary>
    /// השמעת קובץ מתוך המערכת או מהמאגר הגלובלי.
    /// </summary>
    File,
    /// <summary>
    /// השמעת ספרות (לדוגמה 111 המערכת תשמיע "אחת אחת אחת")
    /// </summary>
    Digits,
    /// <summary>
    /// השמעת מספר (לדוגמה 111 המערכת תשמיע "מאה ואחת עשרה")
    /// </summary>
    Number,
    /// <summary>
    /// השמעת אותיות (לדוגמה abc המערכת תשמיע "איי בי סי")
    /// </summary>
    Alpha,
    /// <summary>
    /// הקראת טקסט.
    /// חשוב! לא להכניס בטקסט את התווים נקודה (👈 .👉 ) וקו מפריד (👈 -👉 ).
    /// </summary>
    Text,
    /// <summary>
    /// הקראת טקסט מתוך קובץ במערכת
    /// </summary>
    Speech,
    /// <summary>
    /// מוזיקה בהמתנה.
    /// </summary>
    MusicOnHold,
    /// <summary>
    /// השמעת תאריך לועזי21/12/2022
    /// </summary>
    Date,
    /// <summary>
    /// השמעת תאריך עברי 21/12/2022 - כ"ז כיסלו תשפ"ג
    /// </summary>
    DateH,
    /// <summary>
    /// השמעה שעה לפי משתנה רצוי
    /// </summary>
    Zmanim,
    /// <summary>
    /// הודעת מערכת
    /// </summary>
    SystemMessage,
    /// <summary>
    /// מעבר לשלוחה אחרת (לא ניתן לשרשר הודעות נוספות לאחר פקודה זו)
    /// </summary>
    GoToFolder,
    /// <summary>
    /// כלום - מיועד להערות לדוגמא להסביר מה המשמעות של ההודעת מערכת שתשמיעו לאחר מכן, שימו לב לא להשתמש ב"."
    /// </summary>
    Noop
}
```
</details>

# Read
[./Read.cs](https://github.com/chaimhtp/HTP.Yemot.NET/blob/main/HTP.Yemot.NET/Read.cs)

<div dir="ltr" text-align="left">

```js
List<MessageItem> messages = new List<MessageItem>();
messages.Add(new MessageItem(MessageItemType.Text, "פריט"));
InputOptions options = new InputOptions();
options.ParamName = param_x;
options.Min = 0;
...
Read read = new Read(messages, options);
read.ToResponseString(); // "read=t-פריט.t-שם הפריט=param_x,,1,0,0.1,NO,,,,1.2.3,0,Ok,2,,no"
```
<details>
<summary>פרטים</summary>

### InputOptions
```js
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
```
### InputMode

```js
/// <summary>
/// מצב קליטת נתוני משתמש
/// </summary>
public enum InputMode
{
    /// <summary>
    /// הקשה
    /// </summary>
    Tap,
    /// <summary>
    /// זיהוי דיבור
    /// </summary>
    Voice,
    /// <summary>
    /// הקלטה
    /// </summary>
    Record
}
```
### InputType

```js
/// <summary>
/// צורת קליטת נתוני משתמש והשמעת הנתונים שנקלטו למשתמש
/// </summary>
public enum InputType
{
    /// <summary>
    /// משמיע את מה שהוקש בצורת מספר כלומר 22 יהיה "עשרים ושתים".
    /// </summary>
    Number,
    /// <summary>
    /// משמיע את מה שהוקש בצורת ספרות כלומר 22 המערכת תשמיע "שתים שתים".
    /// </summary>
    Digits,
    /// <summary>
    /// משמיע את מה שהוקש בצורת מחיר.
    /// לדוגמה: במידה והמשתמש הקיש 53 המערכת תשמיע "חמישים ושלוש שקלים".
    /// דוגמא נוספת: במידה והמשתמש הקיש הקיש 53 כוכבית 23, המערכת תשמיע "חמישים ושלוש שקלים ועשרים ושלוש אגורות".
    /// כמו כן בסטרינג שיישלח לשרת יופיע 53.23 (כלומר המערכת מחליפה את מקש הכוכבית בנקודה).
    /// </summary>
    Price,
    /// <summary>
    /// משמיע את מה שהוקש בצורת שעה. כלומר 2359 המערכת תשמיע "עשרים ושלוש חמישים ותשע".
    /// יש צורך להגדיר מינימום ומקסימום 4 ספרות.
    /// </summary>
    Time,
    /// <summary>
    /// משמיע את ההקשה בצורת תאריך.
    /// כלומר 10122019 המערכת תשמיע "עשר דצמבר אלפיים ותשע עשרה".
    /// יש צורך להגדיר מינימום ומקסימום 8 ספרות.
    /// </summary>
    Date,
    /// <summary>
    /// משמיע את מה שהוקש בצורת תאריך עברי.
    /// כלומר 23125779 המערכת תשמיע "כ"ט אלול תשע"ט".
    /// יש צורך להגדיר מינימום ומקסימום 8 ספרות.
    /// </summary>
    HebrewDate,
    /// <summary>
    /// ייתן להקיש תעודת זהות תקינה בלבד.
    /// המערכת תשמיע את ההקשה בצורת ספרות.
    /// יש צורך להגדיר מינימום 8 ספרות ומקסימום 9 ספרות.
    /// </summary>
    TeudatZehut,
    /// <summary>
    /// ייתן להקיש רק מספר טלפון ישראלי תקין.
    /// המערכת תשמיע את ההקשה בצורת ספרות.
    /// יש צורך להגדיר מינימום 9 ספרות ומקסימום 10 ספרות.
    /// </summary>
    Phone,
    /// <summary>
    /// בצורת אותיות.
    /// במקרה של הקשה טלפונית של ספרות זה ישמע כמו הקשת ספרות.
    /// במידה ויש אותיות כמו
    /// abc
    /// אז ישמעו את האותיות אחת אחרי השניה.
    /// </summary>
    Alpha,
    /// <summary>
    /// המערכת תעביר את המשתמש להקלדה במקלדת עברית.
    /// בסיום ההקלדה תשמיע את מה שהוקלד במילים או באותיות
    /// </summary>
    HebrewKeyboard,
    /// <summary>
    /// המערכת תעביר את המשתמש להקלדה במקלדת אנגלית.
    /// בסיום ההקלדה תשמיע את מה שהוקלד במילים או באותיות
    /// </summary>
    EnglishKeyboard,
    /// <summary>
    /// המערכת תעביר את המשתמש להקלדה במקלדת אנגלית מותאמת למייל.
    /// בסיום ההקלדה תשמיע את מה שהוקלד במילים או באותיות.
    /// </summary>
    EmailKeyboard,
    /// <summary>
    /// המערכת תעביר את המשתמש להקלדה במקלדת ספרות כאשר המערכת תשמיע כל הקשה בצורה מיידית בהתאם למקשים שהוקשו.
    /// הערה חשובה במצב זה אין הגבלה של מינימום או מקסימום, והערכים של ההגבלה לא פעילים.
    /// מעלת מקלדת ספרות זה השמעת כל ספרה מיידית ללקוח.
    /// </summary>
    DigitsKeyboard,
    /// <summary>
    /// משמיע למשתמש קובץ שמע בהתאם למה שהוקש.
    /// </summary>
    File,
    /// <summary>
    /// משמיע למשתמש טקסט בהקראה ממוחשבת בהתאם למה שהוקש.
    /// </summary>
    TTS,
    /// <summary>
    /// לא ישמיע את מה שהוקש כלל
    /// </summary>
    NO
}
```
</details>

# Routing
[./Routing.cs](https://github.com/chaimhtp/HTP.Yemot.NET/blob/main/HTP.Yemot.NET/Routing.cs)

```js
GoToBranch(string branchPath); // go_to_folder=/1
```

# RequestParams
ניהול פרמטרים שנשלחו מהמערכת הטלפונית
[./RequestParams.cs](https://github.com/chaimhtp/HTP.Yemot.NET/blob/main/HTP.Yemot.NET/RequestParams.cs)

```js
/// <summary>
/// RequestParameters init
/// </summary>
/// <param name="requestParams">HttpPost example: HttpContext.Current.Request.Form</param>
RequestParams(NameValueCollection requestParams).
```
example:
```js
RequestParams form = new RequestParams(HttpContext.Current.Request.Form);
string apiCallId = form.ApiCallId;
string paramx = form.GetParamValue("param_x");
```
```js
if (form.Hangup)
{
    Routing.GoToBranch(string branchPath);
}
```

