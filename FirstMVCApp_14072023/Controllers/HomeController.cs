using FirstMVCApp_14072023.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;

namespace FirstMVCApp_14072023.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _sesson;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _sesson = httpContextAccessor;
        }

        public IActionResult Index()
        {

            List<Student> lstStudent=new List<Student>();
            lstStudent.Add(new Student
            {
                FirstName = "aalok",
                LastName = "Dubey",
                Email = "a@gmail.com"
            });
            lstStudent.Add(new Student
            {
                FirstName = "Praveen",
                LastName = "Dubey",
                Email = "p@gmail.com"
            });
            lstStudent.Add(new Student
            {
                FirstName = "Pthan",
                LastName = "Pathan",
                Email = "c@gmail.com"
            });

            string stringlstStudent = JsonConvert.SerializeObject(lstStudent);



            _sesson.HttpContext.Session.SetString("lststuden", stringlstStudent);


            CookieOptions a = new CookieOptions();
            a.Expires = DateTime.Now.AddMinutes(2);
            a.IsEssential = true;
            a.Path = "/";

            HttpContext.Response.Cookies.Append("pathan", "Searched for flight between mumbai to delhi", a);


            //Boxing
            int ints = 123;
            object b = ints;

            //Unboxing
            int res = (int)b;


            //boxing
            int i = 10;
            ArrayList arrlst = new ArrayList();
            arrlst.Add(i);

            //Unboxing
            int j = (int)arrlst[0];


            double dbla = 2.250;

            string sdouble = dbla.ToString();

            double resultof=Convert.ToInt32(sdouble);



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}