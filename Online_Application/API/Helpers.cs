using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using Online_Application.ApplicantFormRef;
using Online_Application.ApplicantListRef;
using Online_Application.CourseListRef;




namespace Online_Application.API

{
    public class Helpers
    {
        public static List<CourseList> GetCourses()
        {
            List<CourseList> courses = new List<CourseList>();
            courses = Webservice.course_service().ReadMultiple(null, null, 0).ToList();

            return courses;
        }
        public static List<ApplicantList> GetApplicants()
        {
            List<ApplicantList> applicants = new List<ApplicantList>();
            applicants = Webservice.applicantList_Service().ReadMultiple(null, null, 0).ToList();

            return applicants;
        }
        public static ApplicantForm CreateApplicant(ApplicantForm applicantNo)
        {
            Webservice.applicant_service().Create(ref applicantNo);
            return applicantNo;
        }
        public static ApplicantForm UpdateApplicant(ApplicantForm applicant)
        {
            Webservice.applicant_service().Update(ref applicant);
            return applicant;
        }
       
        public static void  DeleteApplicant( string Key)
        {
            Webservice.applicant_service().Delete(Key);
        }
       


    }
    
    public class Webservice
    {

        public static CourseList_Service  course_service()
        {
            CourseList_Service service = new CourseList_Service();
            service.Url = ConfigurationManager.AppSettings["path"] + "Page/CourseList";
            service.UseDefaultCredentials = false;
            service.Credentials = credentials;

            return service;
        }
        public static ApplicantForm_Service applicant_service()
        {
            ApplicantForm_Service service = new ApplicantForm_Service();
            service.Url = ConfigurationManager.AppSettings["path"] + "Page/ApplicantForm";
            service.UseDefaultCredentials = false;
            service.Credentials = credentials;

            return service;
        }
        public static ApplicantList_Service applicantList_Service()
        {
            ApplicantList_Service service = new ApplicantList_Service();
            service.Url = ConfigurationManager.AppSettings["path"] + "Page/ApplicantList";
            service.UseDefaultCredentials = false;
            service.Credentials = credentials;

            return service;

        }
        private static NetworkCredential credentials = new NetworkCredential(ConfigurationManager.AppSettings["SoapUsername"], ConfigurationManager.AppSettings["SoapPassword"]);
        
    }

    
}