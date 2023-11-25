using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Student
    {
        //what defines a Student

        //student id
        public int studentId { get; set; }

        //student first_name
        public string studentfname { get; set; }

        //student last_name
        public string studentlname { get; set; }

        //student number
        public string studentnumber { get; set; }

        //enrol date
        public DateTime enroldate { get; set; }
        
    }
}