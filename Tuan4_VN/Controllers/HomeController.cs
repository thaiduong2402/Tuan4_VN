using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_VN.Models;
namespace Tuan4_VN.Controllers
{
    public class HomeController : Controller
    {
        Tuan4 db = new Tuan4();
        public ActionResult Index()
        {
            var upcomingsuorse = db.Courses.Where(x => x.DateTime > DateTime.Now).OrderBy(x => x.DateTime).ToList();
            foreach(Course i in upcomingsuorse)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(i.LecturerId);
                i.LecturerId = user.Name;
            }
            return View(upcomingsuorse);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}