using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace pdouelle.QueryStringHelper
{
    public static class QueryStringHelper
    {
        public static string GetQueryString(this object obj)
        {
            var queryParameters = new List<string>();
            
            PropertyInfo[] properties = obj.GetType().GetProperties();
            
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.GetValue(obj, null) != null)
                {
                    var propertyName = propertyInfo.Name;
                    var propertyValue = propertyInfo.GetValue(obj, null)?.ToString();
                    var propertyValueEncoded = HttpUtility.UrlEncode(propertyValue);

                    queryParameters.Add(propertyName + "=" + propertyValueEncoded);
                }
            }

            var queryString = string.Join("&", queryParameters);
            
            return "?" + queryString;
        }
    }
}