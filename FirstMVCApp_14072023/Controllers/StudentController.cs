using FirstMVCApp_14072023.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FirstMVCApp_14072023.Controllers
{
    public class StudentController : Controller
    {
        private readonly IHttpContextAccessor _sesson;

        public StudentController(IHttpContextAccessor httpContextAccessor)
        {
            _sesson = httpContextAccessor;
        }
        //ViewResult
        public ViewResult Index()
        {

            string strvalue = _sesson.HttpContext.Session.GetString("lststuden");
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(strvalue);




            string result = _sesson.HttpContext.Session.GetString("Praveen");
            string cookieValue = _sesson.HttpContext.Request.Cookies["pathan"];
            return View();

        }
        //Content Result
        public ContentResult CntResult()
        {
            return Content("Hello This is a content Result");
        }
        //EmptyResult
        public EmptyResult empty()
        {
            return new EmptyResult();
        }

    }
}
