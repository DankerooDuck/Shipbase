using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ShipBase.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
#pragma warning disable CS8603 // Possible null reference return.
            return sessionData == null
                ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
