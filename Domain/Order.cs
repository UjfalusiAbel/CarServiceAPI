using System;

namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarMaker { get; set; }
        public string CarType { get; set; }
    }
}