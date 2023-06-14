using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Online_Application.DTO
{
    public class CourseDTO
    {

        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public string DepartmentNo { get; set; }
        public string SchoolName { get; set; }
        public int DurationYears { get; set; }


    }
   

}