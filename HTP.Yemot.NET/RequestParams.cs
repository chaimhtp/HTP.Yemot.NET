using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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
            //this.LastParamKey = this.GetLastParamKey();
            //this.LastParamValue = this.GetParamValue(this.LastParamKey);
            //this.LastParam = this.GetLastParam();
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
        //public KeyValuePair<string, string> LastParam { get; set; }
        //public string LastParamKey { get; set; }
        //public string LastParamValue { get; set; }
        //public bool IsRequestParamsEmpty { get; set; }
        private NameValueCollection Form { get; set; }
        private List<KeyValuePair<string, string>> Parameters { get; set; }
        private void ConvertParamsToKeyValuePairList(NameValueCollection form)
        {
            this.Parameters = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < form.Count; i++)
            {
                string ky = form.Keys[i];
                string val = form[ky];
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(ky, val);
                this.Parameters.Add(kvp);
            }
            //this.LastParam = this.Parameters.LastOrDefault();
        }

        /// <summary>
        /// גישה לפרמטרים נוספים.
        /// במידה וקיים פרמטר עם שם דומה מס' פעמים, הפונקציה תחזיר את הערך האחרון
        /// </summary>
        public string GetParamValue(string paramKey)
        {
            KeyValuePair<string, string> prm = this.Parameters.LastOrDefault(x => x.Key == paramKey);
            return prm.Equals(new KeyValuePair<string, string>()) ? prm.Value : null;
            //string paramVal = this.Form[paramKey];
            //string[] tapedsArr = paramVal?.Split(',');
            //string last = tapedsArr?.Last();
            //return last;
        }
        public KeyValuePair<string, string> GetLastParam()
        {
            return this.Parameters.LastOrDefault();
        }
        /// <summary>
        /// גישה לפרמטרים נוספים.
        /// במידה וקיים פרמטר עם שם דומה מס' פעמים, הפונקציה תחזיר את האחרון
        /// </summary>
        public KeyValuePair<string, string> GetParam(string paramKey)
        {
            KeyValuePair<string, string> prm = this.Parameters.LastOrDefault(x => x.Key == paramKey);
            return !prm.IsNull() ? prm : default;
        }

        public string GetLastParamKey()
        {
            string[] prms = this.Form.AllKeys;
            string last = prms?.LastOrDefault();
            return last;
        }
        private bool IsRequestParamsEmpty()
        {
            return !this.Parameters.Any();
            //string[] prms = this.Form.AllKeys;
            //return !prms.Any();
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

    }
    public static class RequestParamsExpansions
    {
        public static bool IsNull(this KeyValuePair<string, string> keyValuePairOfString)
        {
            return keyValuePairOfString.Equals(new KeyValuePair<string, string>());
        }
    }
}
