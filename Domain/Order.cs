namespace Domain
{
    public class Order
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarMaker { get; set; }
        public string CarType { get; set; }
        public Offer OfferType { get; set; }
        
    }
}