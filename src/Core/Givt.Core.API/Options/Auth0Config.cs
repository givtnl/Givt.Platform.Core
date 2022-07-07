﻿namespace Givt.Core.API.Options
{
    public class Auth0Config
    {
        public const string SectionName = "Auth0";
        public string Key { get; set; }
        public string Domain { get; set; }
        public string Audience { get; set; }
    }
    
}
