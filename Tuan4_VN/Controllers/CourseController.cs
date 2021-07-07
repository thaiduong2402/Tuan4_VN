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
    public class CourseController : Controller
    {
        Tuan4 db = new Tuan4();
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            Course obj = new Course();
            obj.list = db.Categories.ToList();
            return View(obj);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course obj)
        {
            ModelState.Remove("LecturerId");
            if (!ModelState.IsValid)
            {
                obj.list = db.Categories.ToList();
                return View("Create", obj);
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            obj.LecturerId = user.Id;
            db.Courses.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}