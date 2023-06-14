using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Online_Application.API;
using Online_Application.CourseListRef;
using Online_Application.DTO;

namespace Online_Application.Controllers
{
    public class CoursesController : ApiController
    {
        // GET: Courses
 
        // Define your API endpoints
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCourses()
        {
            var courses = Helpers.GetCourses(); // Call the SOAP API method to retrieve courses

            List<CourseDTO> courselist = new List<CourseDTO>();
            foreach (var course in courses)
            {
                var courseDTO = new CourseDTO
                {
                    CourseCode = course.CourseNo,
                    CourseName = course.CourseName,
                    DepartmentNo = course.DepartmentCode,   
                    SchoolName = course.SchoolName,
                    DurationYears = course.Duration
                };
                courselist.Add(courseDTO);
            }
            return Ok(courselist);

        }


    }
}