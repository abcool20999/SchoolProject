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
    public class ClassDataController : ApiController
    {

        ///The database context class which will allow us to access our MySql Database.

        private SchoolDbContext School = new SchoolDbContext();

        ///This controller will access the classes table of the school database.
        /// <summary>
        /// Returns a list of classes in the system
        /// </summary>
        /// <returns>
        /// A list of class  objects
        /// </returns>
        /// <example>
        /// GET api/ClassData/ListClasses --> ["classId":"1", "classcode":"http5101", "classname":"web application development",
        ///                                       "startdate":"2018-09-04T00:00:00", "finishdate":"2018-12-14T00:00:00", "teacherId":"1"]
        /// </example>
  


        [HttpGet]
        [Route("api/ClassData/ListClasses")]
        public List<Class> ListClasses()
        {
            // Create a list to store the classes
            List<Class> Classes = new List<Class>();

            // Installed the MySQL.NET--MySql.Data Connector via NuGet Package Manager
            // Create the connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection
            Conn.Open();

            // Create command
            MySqlCommand cmd = Conn.CreateCommand();

            // Set the SQL command
            cmd.CommandText = "Select * from classes;";

            // Get result set and create a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Loop through the list
            while (ResultSet.Read())
            {
                // Create a new Class object for each record
                Class newClass = new Class();

                // Access Column information by the DB column name as an index

                // Get the class id
                newClass.classId = Convert.ToInt32(ResultSet["classId"]);

                // Get the classcode
                newClass.classcode = ResultSet["classcode"].ToString();

                // Get the teacherid
                newClass.teacherid = Convert.ToInt32(ResultSet["teacherid"]);

                // Get the startdate
                string startdate = ResultSet["startdate"].ToString();
                newClass.startdate = DateTime.Parse(startdate);

                // Get the finishdate
                string finishdate = ResultSet["finishdate"].ToString();
                newClass.finishdate = DateTime.Parse(finishdate);


                // Get the classname
                newClass.classname = ResultSet["classname"].ToString();

                // Add the class object to the list
                Classes.Add(newClass);
            }

            // Close the connection between the MySQL Database and the WebServer 
            Conn.Close();

            // Return the final list of class objects
            return Classes;
        }
    }
}
       



