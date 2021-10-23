using HotChoco.Dapper.Api.Dtos;
using HotChoco.Dapper.Api.Services;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;

namespace HotChoco.Dapper.Api.QueryResolver
{
    [ExtendObjectType("Query")]
    public class PersonQueryResolver
    {
        public PersonDto GetFirstPerson([Service] IPersonService personService)
        {
            return personService.GetFirst();
        }

        public List<PersonDto> GetAllPerson([Service] IPersonService personService)
        {
            return personService.GetAll();
        }

        public List<PersonDto> FilterByFirstName(string firstName, [Service] IPersonService personService)
        {
            return personService.FilterByFirstName(firstName);
        }

        public List<PersonDto> GetPersonAddress([Service] IPersonService personService)
        {
            return personService.GetPersonAddress();
        }
    }
}
