using AttributeRoutingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttributeRoutingDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        public List<Student> slist = new List<Student>()
        {
            new Student() {Id=1,Name="Sourav"},
            new Student() {Id=2,Name=" Manoj"},
            new Student() {Id=3,Name="Shuvam"},
            new Student() {Id=4,Name="Samrat"},
            new Student() {Id=5,Name="Rudra"},
        };

        [HttpGet]
        [Route("getallstudfromdb")]
       public ActionResult GetAllStudents()
        {

            return View(slist);//we are passing list..it will be stored in Model.
        }
       


        [HttpGet]
       [Route("stud/{sid}")]   //you can write your own custom url---just add  routes.MapMvcAttributeRoutes() in routeconfig.cs
        public ActionResult GetStudentById(int sid)
        {
            Student s = slist.Where(x => x.Id==sid).FirstOrDefault();
            return View(s);//We are passing single student object from controller to view...that will be stored in Model variable
        }                    //To access the Properties of student we can write @Model.Name in view

        [HttpGet]
        [Route("students/{studentID}/courses")]
        public ActionResult GetStudentCourses(int studentID)
        {
            List<string> CourseList = new List<string>();
            if (studentID == 1)
                CourseList = new List<string>() { "ASP.NET", "C#.NET", "SQL Server" };
            else if (studentID == 2)
                CourseList = new List<string>() { "ASP.NET MVC", "C#.NET", "ADO.NET" };
            else if (studentID == 3)
                CourseList = new List<string>() { "ASP.NET WEB API", "C#.NET", "Entity Framework" };
            else
                CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
            ViewBag.CourseList = CourseList;
            return View();
        }














    }
}