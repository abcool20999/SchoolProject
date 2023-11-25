using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolProject.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace SchoolProject.Controllers
{
    public class TeacherDataController : ApiController
    {
        ///The database context class which will allow us to access our MySql Database.

        private SchoolDbContext School = new SchoolDbContext();

        ///This controller will access the teachers table of the school database.
        /// <summary>
        /// Returns a list of Teachers first and lastname in the system
        /// </summary>
        /// <returns>
        /// A list of teachers objects
        /// </returns>// This controller will access the teachers table of our school database
        /// <example>
        /// GET api/TeacherData/ListTeachers --> ["employeenumber":"T321", "hiredate":"2016-08-05T00:00:00", "salary":"55.30",
        ///                                       "teacherId":"1", "teacherfname":"Alexander", "teacherlname":"Bennet"]
        /// </example>



        [HttpGet]
        [Route("api/TeacherData/ListTeachers")]
        public List<Teacher> ListTeachers()
        {
            // Create a list to store the teachers
            List<Teacher> Teachers = new List<Teacher>();

            // Installed the MySQL.NET--MySql.Data Connector via NuGet Package Manager
            // Create the connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection
            Conn.Open();

            // Create command
            MySqlCommand cmd = Conn.CreateCommand();

            // Set the SQL command
            cmd.CommandText = "Select * from teachers";

            // Get result set and create a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Loop through the list
            while (ResultSet.Read())
            {
                // Create a new Teacher object for each record
                Teacher newTeacher = new Teacher();

                // Access Column information by the DB column name as an index

                // Get the teacher id
                newTeacher.teacherId = Convert.ToInt32(ResultSet["teacherid"]);

                // Get the teacher's firstname
                newTeacher.teacherfname = ResultSet["teacherfname"].ToString();

                // Get the teacher's lastname
                newTeacher.teacherlname = ResultSet["teacherlname"].ToString();

                // Get the hire date
                string HireDate = ResultSet["hiredate"].ToString();
                newTeacher.hiredate = DateTime.Parse(HireDate);

                // Get the employee number
                newTeacher.employmeenumber = ResultSet["employeenumber"].ToString();

                // Get the salary
                newTeacher.salary = ResultSet["salary"].ToString();

                // Add the Teacher object to the list
                Teachers.Add(newTeacher);
            }

            // Close the connection between the MySQL Database and the WebServer 
            Conn.Close();

            // Return the final list of teacher objects
            return Teachers;
        }

        /// <summary>
        /// Find a Teacher by the input id
        /// </summary>
        /// <param name="TeacherId">the teacherid primary key in the database</param>
        /// <returns>
        /// this returns a teacher object
        /// </returns> 
        /// <example>
        /// GET api/TeacherData/FindTeacher/{TeacherId} -> {"TeacherId":"1","employmeenumber":"T505","hiredate":"2015-10-23T00:00:00",
        ///                                                 "salary":"79.63"}
        /// 
        /// GET api/TeacherData/FindTeacher/{TeacherId} -> {"TeacherId":"4","employmeenumber":"T371","hiredate":"2016-11-23T00:00:00",
        ///                                                 "salary":"50.63"}
        /// </example>

        [HttpGet]
        [Route("api/TeacherData/FindTeacher/{TeacherId}")]
        public Teacher FindTeacher(int TeacherId)
        {

            //Create Connection
            MySqlConnection Conn = School.AccessDatabase();


            //Open Connection
            Conn.Open();


            //Create a command
            MySqlCommand command = Conn.CreateCommand();


            //Set the command text
            command.CommandText = "SELECT teachers.teacherid, teachers.employeenumber, teachers.hiredate, teachers.salary, classes.classname FROM classes JOIN teachers ON classes.teacherid = teachers.teacherid WHERE teachers.teacherid = " + TeacherId;


            //Result Set
            MySqlDataReader ResultSet = command.ExecuteReader();

            Teacher SelectedTeacher = new Teacher();
            while (ResultSet.Read())
            {  
                //Get the teacherId
                SelectedTeacher.teacherId = Convert.ToInt32
                (ResultSet["teacherid"]);
               
                //Get the employeenumber
                SelectedTeacher.employmeenumber = ResultSet["employeenumber"].ToString();
                
                //Get the hiredate
                SelectedTeacher.hiredate = DateTime.Parse(ResultSet["hiredate"].ToString());
                
                //Get the salary
                SelectedTeacher.salary = ResultSet["salary"].ToString();
                
                //Get the classname
                SelectedTeacher.classname = ResultSet["classname"].ToString();  




            }
            //Close connection
            Conn.Close();

            return SelectedTeacher;

        }
        /// <summary>
        /// It displays a list of teacher names represented with the searchkey entered in the search textbox.
        /// </summary>
        /// <param name="TeacherSearchKey">The Teachers to search for</param>
        /// <returns>
        /// It returns names of teachers that match the teacher names in the search box
        /// </returns>
        /// <example>
        /// GET api/TeacherData/FindTeacher/{TeacherSearchKey} -> {"TeacherId":"1","employmeenumber":"T505","hiredate":"2015-10-23T00:00:00",
        ///                                                 "salary":"79.63", "teacherfname":"Linda", "teacherlname":"Chan"}
        /// 
        /// </example>
        

        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{TeacherSearchKey}")]
        public IEnumerable<Teacher> ListTeachers(string TeacherSearchKey)
        {
            Debug.WriteLine("Trying to do an API search for " + TeacherSearchKey);

            // Create Connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open Connection
            Conn.Open();

            // Create a command
            MySqlCommand command = Conn.CreateCommand();

            // Set the command text
            command.CommandText = "SELECT * FROM teachers WHERE LOWER(teacherfname) LIKE LOWER('%" + TeacherSearchKey + "%') OR LOWER(teacherlname) LIKE LOWER('%" + TeacherSearchKey + "%')";


            // Result Set
            MySqlDataReader ResultSet = command.ExecuteReader();

            // Create a list to store the fetched teachers
            List<Teacher> teachers = new List<Teacher>();

            // Loop through the result set
            while (ResultSet.Read())
            {
                // Fetch data and create a Teacher object
                Teacher newTeacher = new Teacher();
                
                //Get the teacherId
                newTeacher.teacherId = Convert.ToInt32(ResultSet["teacherid"]);
                
                //Get the employee number
                newTeacher.employmeenumber = ResultSet["employeenumber"].ToString();
                
                //Get the hiredate
                newTeacher.hiredate = DateTime.Parse(ResultSet["hiredate"].ToString());
                
                //Get the salary
                newTeacher.salary = ResultSet["salary"].ToString();
                
                //Get the teacher first name
                newTeacher.teacherfname = ResultSet["teacherfname"].ToString();
                
                //Get the teacher lastname
                newTeacher.teacherlname = ResultSet["teacherlname"].ToString();

                // Add the new Teacher object to the list
                teachers.Add(newTeacher);
            }

            // Close the connection
            Conn.Close();

            // Return the list of teachers
            return teachers;
        }
    }
}