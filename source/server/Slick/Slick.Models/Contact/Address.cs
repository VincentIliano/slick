namespace Slick.Models.Contact
{
    public class Address : BaseEntity
    {
        public string Straat { get; set; }
        public string Number { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
    }
}
