using System.Net.Http;
using System.Web.Http;
using WebAPIHelperDemo.Helpers;

namespace WebAPIHelperDemo.Controllers
{
    [RoutePrefix("api/example")]
    public class ExampleController : ApiController
    {
        private WebAPIHelper webAPIHelper;

        public ExampleController()
        {
            webAPIHelper = new WebAPIHelper();
        }

        [HttpGet]
        [Route("examresult")]
        public HttpResponseMessage ExamResultGet(int studentId)
        {
            if (studentId <= 0)
            {
                return webAPIHelper.CreateBadRequest(Request, "Student Id cannot be less than zero");
            }
            if (studentId > 1000)
            {
                return webAPIHelper.CreateResponse(Request, -101);
            }
            return webAPIHelper.CreateResponse(Request, "Congradulations. You passed in all the subjects.");
        }
    }
}
