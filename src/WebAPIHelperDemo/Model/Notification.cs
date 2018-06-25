using System;
using System.Collections.Generic;
using System.Net;

namespace WebAPIHelperDemo.Model
{
    public static class Notification
    {
        private static readonly Dictionary<int, Tuple<string, HttpStatusCode>> notifications = new Dictionary<int, Tuple<string, HttpStatusCode>>()
        {
            { -1,  Tuple.Create("Oops! An Internal Error Occured.", HttpStatusCode.InternalServerError) },
            { -101,  Tuple.Create("The specified student Id does not exists.", HttpStatusCode.NotFound) }
        };

        public static Tuple<string, HttpStatusCode> GetNotification(int code)
        {
            Tuple<string, HttpStatusCode> value;
            bool hasValue = notifications.TryGetValue(code, out value);
            if (!hasValue)
            {
                value = Tuple.Create("Oops! An Internal Error Occured", HttpStatusCode.InternalServerError);
            }
            return value;
        }
    }
}