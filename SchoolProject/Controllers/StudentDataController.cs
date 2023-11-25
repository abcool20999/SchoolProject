using MySql.Data.MySqlClient;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolProject.Controllers
{
    public class StudentDataController : ApiController
    {
        ///The database context class which will allow us to access our MySql Database.

        private SchoolDbContext School = new SchoolDbContext();

        ///This controller will access the students table of the school database.
        /// <summary>
        /// Returns a list of students first and lastname in the system
        /// </summary>
        /// <returns>
        /// A list of student objects
        /// </returns>
        /// <example>
        /// GET api/StudentData/ListStudents --> ["studentId":"1", "studentfname":"Sarah", "studentlname":"Valdez",
        ///                                       "studentnumber":"N1678", "enroldate":"2018-06-18T00:00:00"];
        /// </example>

        [HttpGet]
        [Route("api/StudentData/ListStudents")]
        public List<Student> ListStudents()
        {
            // Create a list to store the students
            List<Student> Students = new List<Student>();

            // Installed the MySQL.NET--MySql.Data Connector via NuGet Package Manager
            // Create the connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection
            Conn.Open();

            // Create command
            MySqlCommand cmd = Conn.CreateCommand();

            // Set the SQL command
            cmd.CommandText = "Select * from students;";

            // Get result set and create a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Loop through the list
            while (ResultSet.Read())
            {
                // Create a new Student object for each record
                Student newStudent = new Student();

                // Access Column information by the DB column name as an index

                // Get the student id
                newStudent.studentId = Convert.ToInt32(ResultSet["studentId"]);

                // Get the student's firstname
                newStudent.studentfname = ResultSet["studentfname"].ToString();

                // Get the student's lastname
                newStudent.studentlname = ResultSet["studentlname"].ToString();

                // Get the enrolment date
                string enroldate = ResultSet["enroldate"].ToString();
                newStudent.enroldate = DateTime.Parse(enroldate);

                // Get the student number
                newStudent.studentnumber = ResultSet["studentnumber"].ToString();

                // Add the Student object to the list
                Students.Add(newStudent);
            }

            // Close the connection between the MySQL Database and the WebServer 
            Conn.Close();

            // Return the final list of student objects
            return Students;
        }
    }
}
