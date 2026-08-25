using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP.Yemot.NET
{
    /// <summary>
    /// RequestParameters
    /// </summary>
    public class RequestParams
    {
        /// <summary>
        /// RequestParameters init
        /// </summary>
        /// <param name="requestParams">HttpPost example: HttpContext.Current.Request.Form</param>
        public RequestParams(NameValueCollection requestParams)
        {
            dynamic form = requestParams;
            this.Form = form;
            ConvertParamsToKeyValuePairList(this.Form);
            this.ApiCallId = form["ApiCallId"];
            this.ApiPhone = form["ApiPhone"];
            this.ApiDID = form["ApiDID"];
            this.ApiRealDID = form["ApiRealDID"];
            this.ApiExtension = form["ApiExtension"];
            this.ApiEnterID = form["ApiEnterID"];
            this.ApiEnterIDName = form["ApiEnterIDName"];
            string apiTimeParam = form["ApiTime"];
            this.ApiTime = !string.IsNullOrWhiteSpace(apiTimeParam) ? UnixTimeStampToDateTime(double.Parse(apiTimeParam)) : (DateTime?)null;
            string hangupParam = form["hangup"];
            this.Hangup = !string.IsNullOrWhiteSpace(hangupParam) && hangupParam == "yes";
            this.ApiHangupExtension = form["ApiHangupExtension"];

        }
        /// <summary>
        /// מזהה ייחודי לאורך השיחה
        /// </summary>
        public string ApiCallId { get; set; }
        /// <summary>
        /// מספר הטלפון של המשתמש
        /// </summary>
        public string ApiPhone { get; set; }
        /// <summary>
        /// מספר טלפון הראשי של המערכת שלכם
        /// </summary>
        public string ApiDID { get; set; }
        /// <summary>
        /// המספר אליו חייג המשתמש
        /// </summary>
        public string ApiRealDID { get; set; }
        /// <summary>
        /// שם התיקייה/שלוחה בה נמצא המשתמש
        /// </summary>
        public string ApiExtension { get; set; }
        /// <summary>
        /// במידה ובוצעה התחברות לפי זיהוי אישי, יצורף ערך זה המכיל את סוג ההתחברות וה-ID של המשתמש
        /// https://f2.freeivr.co.il/topic/8204/%D7%94%D7%92%D7%93%D7%A8%D7%95%D7%AA-%D7%94%D7%96%D7%99%D7%94%D7%95%D7%99-%D7%91%D7%9B%D7%9C%D7%9C-%D7%94%D7%9E%D7%A2%D7%A8%D7%9B%D7%AA
        /// </summary>
        public string ApiEnterID { get; set; }
        /// <summary>
        /// שם משויך לזיהוי האישי
        /// https://f2.freeivr.co.il/topic/8204/%D7%94%D7%92%D7%93%D7%A8%D7%95%D7%AA-%D7%94%D7%96%D7%99%D7%94%D7%95%D7%99-%D7%91%D7%9B%D7%9C%D7%9C-%D7%94%D7%9E%D7%A2%D7%A8%D7%9B%D7%AA/14
        /// </summary>
        public string ApiEnterIDName { get; set; }
        /// <summary>
        /// תאריך ושעה
        /// </summary>
        public DateTime? ApiTime { get; set; }
        /// <summary>
        /// פרמטר שמציין שהמשתמש ניתק את השיחה
        /// </summary>
        public bool Hangup { get; set; }
        /// <summary>
        /// פרמטר שמציין את השלוחה בה המשתמש ניתק את השיחה
        /// </summary>
        public string ApiHangupExtension { get; set; }
        private NameValueCollection Form { get; set; }
        /// <summary>
        /// כלל הפרמטרים שהתקבלו בבקשה, לפי סדר הגעתם
        /// </summary>
        private List<KeyValuePair<string, string>> Parameters { get; set; }

        private void ConvertParamsToKeyValuePairList(NameValueCollection form)
        {
            this.Parameters = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < form.Count; i++)
            {
                string key = form.Keys[i];
                string value = form[key];
                this.Parameters.Add(new KeyValuePair<string, string>(key, value));
            }
        }
        /// <summary>
        /// גישה לפרמטרים נוספים.
        /// במידה וקיים פרמטר עם שם דומה מס' פעמים, הפונקציה תחזיר את הערך האחרון
        /// </summary>
        public string GetParamValue(string paramKey)
        {
            string paramVal = this.Form[paramKey];
            string[] tapedsArr = paramVal?.Split(',');
            string last = tapedsArr?.Last();
            return last;
        }
        /// <summary>
        /// הפרמטר האחרון שהתקבל בבקשה
        /// </summary>
        public KeyValuePair<string, string> GetLastParam()
        {
            return this.Parameters.LastOrDefault();
        }
        /// <summary>
        /// הפרמטר האחרון בשם המבוקש.
        /// במידה ולא קיים, מוחזר KeyValuePair ריק (ניתן לבדוק באמצעות IsNull)
        /// </summary>
        public KeyValuePair<string, string> GetParam(string paramKey)
        {
            KeyValuePair<string, string> param = this.Parameters.LastOrDefault(x => x.Key == paramKey);
            return param.IsNull() ? new KeyValuePair<string, string>() : param;
        }
        /// <summary>
        /// שם הפרמטר האחרון שהתקבל בבקשה
        /// </summary>
        public string GetLastParamKey()
        {
            return this.Form.AllKeys?.LastOrDefault();
        }

        private bool IsRequestParamsEmpty()
        {
            return !this.Parameters.Any();
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

    }
}
