using System.Collections.Generic;

namespace HotChoco.Dapper.Api.Dtos
{
    public class PersonDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public List<PersonAddressDto> Address { get; set; }
    }
}
