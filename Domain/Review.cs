using System;

namespace Domain
{
    public class Review
    {
        public Guid Id {get; set;}
        public Guid ServiceId { get; set; }
        public string Writer { get; set; }
        public string Content { get; set; }
        public float Score { get; set; }
    }
}