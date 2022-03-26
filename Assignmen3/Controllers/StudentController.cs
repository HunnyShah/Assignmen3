using Assignmen3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignmen3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Student/List
        public ActionResult List()
        {
            StudentdataController controller = new StudentdataController();
            IEnumerable<Students> teacher = controller.ListStudents();
            return View(teacher);
        }
        //GET : /Student/Show/{id}
        public ActionResult Show(int id)
        {
            StudentdataController controller = new StudentdataController();
            Students NewStudent = controller.FindStudents(id);

            return View(NewStudent);
        }
    }
}