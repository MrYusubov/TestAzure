using Newtonsoft.Json;

namespace ECommerceApp.UI.ExtentionMethods
{
    public static class SessionExtentionMethods
    {
        public static void SetObject(this ISession session,string key, object obj)
        {
            string objectString=JsonConvert.SerializeObject(obj);
            session.SetString(key, objectString);
        }

        public static T? GetObject<T>(this ISession session,string key) where T : class 
        {
            string objectString=session.GetString(key);
            if(string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            T result=JsonConvert.DeserializeObject<T>(objectString);
            return result;
        }
    }
}
