using Audit_Benchmark_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Audit_Benchmark_Service.Service_Layer
{
    public class BenchmarkService
    {
        public List<AuditBenchmarkClass> GetListOfBenchmarks()
        {
            List<AuditBenchmarkClass> AuditBenchmarkList = new List<AuditBenchmarkClass>()
            {
                new AuditBenchmarkClass(){ AuditType="Internal",BenchmarkNoAnswers=3 },
                new AuditBenchmarkClass(){ AuditType="SOX",BenchmarkNoAnswers=1 },
            };
            return AuditBenchmarkList;
        }

    }
}
