﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Authentication
{
    public class JWTOption
    {
        public required string Issuer { get; init; }  
        public required string Audience { get; init; }
        public required string SecretKey { get; init; }
    }
}
