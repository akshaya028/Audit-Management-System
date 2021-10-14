using Audit_Checklist_Microservice.Filters;
using Audit_Checklist_Microservice.Service_Layer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Audit_Checklist_Microservice.Controllers
{
    [Route("api")]
    [ApiController]

    public class AuditChecklistController : ControllerBase
    {

        //public string AuditType = "Internal";

        // GET: api/<AuditChecklistController>
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistController));
        
        [HttpGet("AuditCheckListQuestions")]
        //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        //[CustomAuthFilter]
        [Authorize]
        public ActionResult<List<string>> Get(string auditType)
        {
            _log4net.Info("Get method of checklist microservice is invoked");
            var identity = User.Identity as ClaimsIdentity;
            if(identity!=null)
            {
                if (ModelState.IsValid)
                {
                    GetQuestionsList getQuestion = new GetQuestionsList();

                    List<string> QuestionList = getQuestion.Questions(auditType);

                    if (QuestionList != null)
                    {
                        _log4net.Info("Question list for " + auditType + " is returned");
                        return Ok(QuestionList);
                    }
                    else
                    {
                        _log4net.Info("Audit Type Mismatch!");
                        return new BadRequestObjectResult("Audit Type Mismatch!");
                    }
                }

                else
                {
                    _log4net.Error("Model state is invalid");
                    return new BadRequestResult();
                }
            }
            else
            {
                return Unauthorized("User is unauthorized");
            }
            

        }

        
    }
}
