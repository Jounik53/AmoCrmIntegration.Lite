using Newtonsoft.Json;
using RestSharp.Extensions;
using System;

namespace AmoCrmIntegration.Lite.Utils
{
    /// <summary>
    /// Enum extension class
    /// </summary>
    internal static class EnumExtensions
    {
        internal static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var memberInfo = value.GetType().GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }
    }

    /// <summary>
    /// Serialization Expansion Class
    /// </summary>
    internal static class SerializationExtensions
    {
        internal static T DeserializeTo<T>(this string self) where T : class
        {
            return !self.HasValue() ? null : JsonConvert.DeserializeObject<T>(self);
        }
    }

    /// <summary>
    /// Extension class for working with time and date from the server
    /// </summary>
    internal static class AmoCrmDateTimeConverterExtensions
    {
        internal static long GetTimestamp(this DateTime dateTime)
        {
            return (long)(dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }

        internal static long? GetTimestamp(this DateTime? dateTime)
        {
            return dateTime.HasValue
                ? (long)(dateTime.Value - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds
                : (long?)null;
        }

        internal static DateTime GetDateTime(this long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp).ToLocalTime();
        }

        internal static DateTime? GetDateTime(this long? timestamp)
        {
            return timestamp.HasValue
                ? new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp.Value).ToLocalTime()
                : (DateTime?)null;
        }
    }
}