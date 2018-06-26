using System;
using System.Net;
using System.Net.Http;
using WebAPIHelperDemo.Model;

namespace WebAPIHelperDemo.Helpers
{
    public class WebAPIHelper
    {
        private APIResponse apiResponse;

        /// <summary>
        /// Creates a error or successful response based on the data to be sent
        /// </summary>
        /// <param name="request">The http request</param>
        /// <param name="data">The data to be sent</param>
        /// <returns>The http response</returns>
        public HttpResponseMessage CreateResponse(HttpRequestMessage request, object data)
        {
            if (data == null || (data is bool && Convert.ToBoolean(data) == false))
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

        /// <summary>
        /// Creates an error response with a 500 status code(Internal Server error)
        /// </summary>
        /// <param name="request">The http request</param>
        /// <param name="errorText">Error message to be sent</param>
        /// <param name="data">Any data to be sent</param>
        /// <returns>The http response</returns>
        public HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, string errorText, object data = null)
        {
            apiResponse = new APIResponse(data, errorText, true);
            return request.CreateResponse(HttpStatusCode.InternalServerError, apiResponse);
        }

        /// <summary>
        /// Creates a http response with 400 status code(Bad Request)
        /// </summary>
        /// <param name="request">The http request</param>
        /// <param name="errorText">Error message to be sent</param>
        /// <returns>The http response</returns>
        public HttpResponseMessage CreateBadRequest(HttpRequestMessage request, string errorText)
        {
            apiResponse = new APIResponse(null, errorText, true);
            return request.CreateResponse(HttpStatusCode.BadRequest, apiResponse);
        }
    }
}