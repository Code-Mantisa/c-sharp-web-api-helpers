namespace WebAPIHelperDemo.Model
{
    public class APIResponse
    {
        public APIResponse(dynamic data, string message, bool isError)
        {
            Data = data;
            Message = message;
            IsError = isError;
        }

        public string Message;
        public dynamic Data;
        public bool IsError;
    }
}