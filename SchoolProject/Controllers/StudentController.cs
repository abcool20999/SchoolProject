using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/List
        // Go to /Views/Student/list.cshtml
        // Browser will open a list of students
        public ActionResult List()
        {


            //I have to pass the student information to the view
            //I would have to create an instance of the student controller 

            StudentDataController Controller = new StudentDataController();

            // create a list of objects for listing students
            List<Student> Students = Controller.ListStudents();

            return View(Students);

        }
    }
}