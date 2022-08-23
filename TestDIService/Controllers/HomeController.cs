using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using TestDIService.Interface;
using TestDIService.Models;

namespace TestDIService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ISchool _school1;
        private readonly ISchool _school2;
        private readonly ITeacher _teacher1;
        private readonly ITeacher _teacher2;
        private readonly IStudent _student1;
        private readonly IStudent _student2;

        public HomeController(ILogger<HomeController> logger,ISchool school1, ISchool school2, ITeacher teacher1, ITeacher teacher2, IStudent student1, IStudent student2)
        {
            _logger = logger;
            _school1 = school1;
            _school2 = school2;
            _teacher1 = teacher1;
            _teacher2 = teacher2;
            _student1 = student1;
            _student2 = student2;
        }

        public IActionResult Index()
        {
            var str = new StringBuilder();
            str.Append($"Transient1:<span style='color:red;'>{_school1.GetHashCode()}</span></br>");
            str.Append($"Transient2:<span style='color:red;'>{_school2.GetHashCode()}</span></br></br>");
            str.Append($"Scope1:<span style='color:blue;'>{_teacher1.GetHashCode()}</span></br>");
            str.Append($"Scope2:<span style='color:blue;'>{_teacher2.GetHashCode()}</span></br></br>");
            str.Append($"Singleton1:<span style='color:green;'>{_student1.GetHashCode()}</span></br>");
            str.Append($"Singleton2:<span style='color:green;'>{_student2.GetHashCode()}</span></br></br>");
            Response.ContentType = "text/html";
            return Content(Convert.ToString(str));
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