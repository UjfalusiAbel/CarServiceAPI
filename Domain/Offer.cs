using System;

namespace Domain
{
    public class Offer
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
    }
}