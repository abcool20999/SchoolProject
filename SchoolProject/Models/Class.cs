using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Class
    {
            //what defines a Class

            //class id
            public int classId { get; set; }

            //classcode
            public string classcode { get; set; }

            //teacherid
            public int teacherid { get; set; }

            //startdate
            public DateTime startdate { get; set; }

            //finishdate
            public DateTime finishdate { get; set; }
            
            //classname
            public string classname { get; set; }

    }
    }
