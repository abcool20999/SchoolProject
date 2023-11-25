using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolProject.Controllers
{
    public class ClassController : Controller
    {
       
        // GET: Class/List
        // Go to /Views/Class/list.cshtml
        // Browser will open a list of classes
        public ActionResult List()
        {

         //I have to pass the class information to the view
         //I would have to create an instance of the class controller 

         ClassDataController Controller = new ClassDataController();

         // create a list of objects for listing classes
         List<Class> Classes = Controller.ListClasses();

         return View(Classes);

            }
        }


    }