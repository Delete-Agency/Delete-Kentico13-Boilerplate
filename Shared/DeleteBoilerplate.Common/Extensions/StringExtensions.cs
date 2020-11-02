using CMS.SiteProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeleteBoilerplate.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string OrDefault(this string value, string defaultValue)
        {
            return IsEmpty(value) 
                ? defaultValue
                : value;
        }

        public static string IfEmpty(this string value, string ifEmptyValue)
        {
            return string.IsNullOrWhiteSpace(value)
                ? ifEmptyValue
                : value;
        }
    }
}
