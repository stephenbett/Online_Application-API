using Online_Application.API;
using Online_Application.ApplicantFormRef;
using Online_Application.ApplicantListRef;
using Online_Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Online_Application.Controllers
{
    public class ApplicantController : ApiController
    {
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetApplicants()
        {
            var applicants = Helpers.GetApplicants();// Call the SOAP API method to retrieve Applicant

            List<ApplicantDTO> applicantlist = new List<ApplicantDTO>();
            foreach (var applicant in applicants)
            {
                var appliantDTO = new ApplicantDTO
                {
                    applicationNo = applicant.ApplicantNo,
                    FirstName = applicant.FirstName,
                    SurnameName = applicant.Surname,
                    FullName = applicant.FullName,


                      
                };
                applicantlist.Add(appliantDTO);
            }
            return Ok(applicantlist);
        }
            
        [HttpPost]
        public IHttpActionResult CreateApplicant(ApplicantForm applicant)
        {
            try
            {
                // Call the CreateApplicant method to create a new applicant
                // ApplicantForm createdApplicant = YourWebService.CreateApplicant(applicant);
                applicant = Helpers.CreateApplicant(applicant);
                return Ok(applicant);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the creation process
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateApplicant([FromUri] string id,[FromBody] ApplicantForm applicant)           
        {
            try
            {
                // Set the ID of the applicant to be updated
                applicant.ApplicantNo = id;


                // Call the UpdateApplicant method to update the applicant details
                 Helpers.UpdateApplicant(applicant);

                return Ok();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the update process
                return InternalServerError(ex);
            }
        }


        [HttpDelete]
        public IHttpActionResult DeleteApplicant(string key)
        {
            try
            {
                // Call the DeleteApplicant method to delete the applicant by ID
                Helpers.DeleteApplicant(key);

                return Ok();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the delete process
                return InternalServerError(ex);
            }
        }




    }
}



    

