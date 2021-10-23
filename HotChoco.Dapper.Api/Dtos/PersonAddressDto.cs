namespace HotChoco.Dapper.Api.Dtos
{
    public class PersonAddressDto
    {
        public int PersonAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PersonId { get; set; }
    }
}
