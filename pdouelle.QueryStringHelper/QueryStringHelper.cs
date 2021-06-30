using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Text.Json.Serialization;

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
                var value = propertyInfo.GetValue(obj, null);

                if (value != null)
                {
                    Attribute attribute = propertyInfo.GetCustomAttributes(typeof(JsonPropertyNameAttribute)).SingleOrDefault();

                    string propertyName;

                    if (attribute != null)
                    {
                        var jsonPropertyName = attribute as JsonPropertyNameAttribute;
                        propertyName = jsonPropertyName.Name;
                    }
                    else
                        propertyName = propertyInfo.Name;

                    if (value is IEnumerable enumerable && value.GetType() != typeof(string))
                    {
                        foreach (var property in enumerable)
                        {
                            queryParameters.Add(Factory(propertyName, property));
                        }
                    }
                    else
                    {
                        queryParameters.Add(Factory(propertyName, value));
                    }
                }
            }

            var queryString = string.Join("&", queryParameters);

            return "?" + queryString;
        }

        private static string Factory(string propertyName, object property)
        {
            var propertyValue = property?.ToString();
            var propertyValueEncoded = HttpUtility.UrlEncode(propertyValue);
            var result = propertyName + "=" + propertyValueEncoded;

            return result;
        }
    }
}