using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Teacher
    {
        //what defines a Teacher

        //Teacher id
        public int teacherId { get; set; }

        //Teacher first_name
        public string teacherfname { get; set; }

        //Teacher last_name
        public string teacherlname {  get; set; }

        //hiredate
        public DateTime hiredate { get; set; }
        
        //teacher employeenumber
        public string employmeenumber { get; set; }
        //teacher salary
        public string salary { get; set; }
        //teachers classes
        public string classname { get; set; }
    }
}

