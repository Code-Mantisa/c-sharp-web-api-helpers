namespace WebAPIHelperDemo.Model
{
    /// <summary>
    /// A class for standard formatting of Data
    /// </summary>
    public class APIResponse
    {
        public APIResponse(dynamic data, string message, bool isError)
        {
            Data = data;
            Message = message;
            IsError = isError;
        }

        /// <summary>
        /// Contains error meaasage and the like
        /// </summary>
        public string Message;

        /// <summary>
        /// The actual data sent for the request
        /// </summary>
        public dynamic Data;

        /// <summary>
        /// Indicates if it is an error or not
        /// </summary>
        public bool IsError;
    }
}