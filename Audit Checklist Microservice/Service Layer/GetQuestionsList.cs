using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Audit_Checklist_Microservice.Service_Layer
{
    public class GetQuestionsList
    {
        public List<string> Questions(string AuditType)
        {
            if (AuditType == "Internal")
            {
                return new List<string>()
                {
                    "Have all Change requests followed SDLC before PROD move?",
                    "Have all Change requests been approved by the application owner?",
                    "Are all artifacts like CR document, Unit test cases available?",
                    "Is the SIT and UAT sign-off available?",
                    "Is data deletion from the system done with application owner approval?"
                };
            }
            else if (AuditType == "SOX")
            {
                return new List<string>()
                {
                    "Have all Change requests followed SDLC before PROD move?",
                    "Have all Change requests been approved by the application owner?",
                    "For a major change, was there a database backup taken before and after PROD move?",
                    "Has the application owner approval obtained while adding a user to the system?",
                    "Is data deletion from the system done with application owner approval?"
                };
            }
            else
            {
                return null;
            }
        }
    }
}
