using Assignmen3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

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
        [Route("/Teacher/list/{SearchKey}")]
        public ActionResult List(string SearchKey)
        {
            Debug.WriteLine("The key is: " + SearchKey);
            TeacherdataController controller = new TeacherdataController();
            IEnumerable<Teacher> teacher = controller.ListTeacher(SearchKey);
            return View(teacher);
        }
        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherdataController controller = new TeacherdataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }
        //GET : /Author/New
        public ActionResult New()
        {
            return View();
        }

        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherdataController controller = new TeacherdataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }
        //GET : /Author/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherdataController controller = new TeacherdataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmpNo, DateTime hiredate, decimal sal)
        {
            //Identify that this method is running
            //Identify the inputs provided from the form

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.Hiredate = hiredate;
            NewTeacher.salary = sal;

            TeacherdataController controller = new TeacherdataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }
    }
}