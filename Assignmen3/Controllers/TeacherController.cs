using Assignmen3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignmen3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Teacher/List
        public ActionResult List()
        {
            TeacherdataController controller = new TeacherdataController();
            IEnumerable<Teacher> teacher = controller.ListTeacher();
            return View(teacher);
        }
        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherdataController controller = new TeacherdataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }
    }
}