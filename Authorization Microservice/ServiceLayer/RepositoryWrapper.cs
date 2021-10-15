using Authorization_Microservice.Models;
using Authorization_Microservice.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization_Microservice.ServiceLayer
{
    public class RepositoryWrapper
    {
        private DataLayer dataLayer;
        public RepositoryWrapper()
        {
            this.dataLayer = new DataLayer();
        }
        
        public string Validate(PortalLoginDetails loginDetails)
        {
            string validationToken = this.dataLayer.Validate(loginDetails);
            return validationToken;
        }
    }
}
