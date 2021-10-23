using HotChoco.Dapper.Api.Dtos;
using HotChoco.Dapper.Api.Services;
using HotChocolate;
using HotChocolate.Types;

namespace HotChoco.Dapper.Api.MutationResolver
{
    [ExtendObjectType("Mutation")]
    public class PersonMutationResolver
    {

        public int SavePerson(PersonDto person,[Service] IPersonService personService)
        {
            return personService.SavePerson(person);
        }
    }
}
