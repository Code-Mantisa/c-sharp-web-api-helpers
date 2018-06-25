using System.Net.Http;
using System.Web.Http;
using WebAPIHelperDemo.Helpers;

namespace WebAPIHelperDemo.Controllers
{
    [RoutePrefix("api/student")]
    public class ExampleController : ApiController
    {
        private WebAPIHelper webAPIHelper;

        public ExampleController()
        {
            webAPIHelper = new WebAPIHelper();
        }

        [HttpGet]
        [Route("result")]
        public HttpResponseMessage ExamResultGet(int studentId)
        {
            if (studentId <= 0)
            {
                // Creating bad request manually
                return webAPIHelper.CreateBadRequest(Request, "Student Id cannot be less than zero");
            }
            if (studentId > 1000)
            {
                // Creating error request from a fixed response
                // The response can be obtained from a business layer function or database
                return webAPIHelper.CreateResponse(Request, -101);
            }

            //Creating a successful response
            return webAPIHelper.CreateResponse(Request, "Congradulations. You passed in all the subjects.");
        }
    }
}
