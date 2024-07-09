using Microsoft.AspNetCore.Mvc;

namespace SchoolMS.Web.Controllers
{
    public class AttendenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
