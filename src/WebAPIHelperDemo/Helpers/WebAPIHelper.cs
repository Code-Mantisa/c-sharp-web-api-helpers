using System;
using System.Net;
using System.Net.Http;
using WebAPIHelperDemo.Model;

namespace WebAPIHelperDemo.Helpers
{
    public class WebAPIHelper
    {
        private APIResponse apiResponse;

        public HttpResponseMessage CreateResponse(HttpRequestMessage request, object data)
        {
            if (data == null)
            {
                apiResponse = new APIResponse(null, "Oops! An Error occured.", true);
                return request.CreateResponse(HttpStatusCode.InternalServerError, apiResponse);
            }
            else if (data is bool && Convert.ToBoolean(data) == false)
            {
                apiResponse = new APIResponse(null, "Oops! An Error occured.", true);
                return request.CreateResponse(HttpStatusCode.InternalServerError, apiResponse);
            }
            else if (data is int && Convert.ToInt32(data) < 0)
            {
                Tuple<string, HttpStatusCode> resData = Notification.GetNotification(Convert.ToInt32(data));
                apiResponse = new APIResponse(null, resData.Item1, true);
                return request.CreateResponse(resData.Item2, apiResponse);
            }
            else
            {
                apiResponse = new APIResponse(data, "", false);
                return request.CreateResponse(HttpStatusCode.OK, apiResponse);
            }
        }

        public HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, string errorText)
        {
            apiResponse = new APIResponse(null, errorText, true);
            return request.CreateResponse(HttpStatusCode.InternalServerError, apiResponse);
        }

        public HttpResponseMessage CreateBadRequest(HttpRequestMessage request, string errorText)
        {
            apiResponse = new APIResponse(null, errorText, true);
            return request.CreateResponse(HttpStatusCode.BadRequest, apiResponse);
        }
    }
}