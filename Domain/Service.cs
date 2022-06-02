using System;
using System.Collections.Generic;

namespace Domain
{
    public class Service
    {
        public Guid Id {get; set;}
        public string Name {get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public float Score { get; set; }
    }
}