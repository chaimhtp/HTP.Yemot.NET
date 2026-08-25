using System.Collections.Generic;

namespace HTP.Yemot.NET
{
    public static class RequestParamsExpansions
    {
        /// <summary>
        /// בדיקה האם ה-KeyValuePair ריק (ברירת מחדל)
        /// </summary>
        public static bool IsNull(this KeyValuePair<string, string> keyValuePairOfString)
        {
            return keyValuePairOfString.Equals(new KeyValuePair<string, string>());
        }
    }
}
