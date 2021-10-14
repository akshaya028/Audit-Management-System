using Authorization_Microservice.Models;
using Authorization_Microservice.RepositoryLayer;
using Authorization_Microservice.ServiceLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authorization_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthManager authManager;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthorizationController));
        public AuthorizationController(IAuthManager authManager)
        {
            this.authManager = authManager;
        }    

        // GET: api/<AuthorizationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] PortalLoginDetails loginDetails)
        {
            _log4net.Info("In Authorization controller ");
            var token = authManager.Validate(loginDetails);
            if (token!=null)
            {
                _log4net.Info("Token generated successfully");
                return Ok(new{ Token = token });
            }
            else
            {
                _log4net.Info("Token is not generated");
                return Unauthorized();
            }
        }
    }
}
