using Audit_Benchmark_Service.Models;
using Audit_Benchmark_Service.Service_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Audit_Benchmark_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditBenchmarkController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditBenchmarkController));
        // GET: api/<AuditBenchmarkController>
        
        [AllowAnonymous]
        [HttpGet]
        public List<AuditBenchmarkClass> Get()
        {
            _log4net.Info("In Audit benchmark");
            BenchmarkService benchmarkService = new BenchmarkService();
            _log4net.Info("List of benchmark is returned");
            return benchmarkService.GetListOfBenchmarks();
        }

    }
}
