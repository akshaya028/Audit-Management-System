﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AuditSeverityMicroService.RepositoryLayer
{
    public partial class Logindetail
    {
        public int ProjectId { get; set; }
        public string UserName { get; set; }
        public string Passwrd { get; set; }
    }
}
