using HotChoco.Dapper.Api.Dtos;
using System.Collections.Generic;

namespace HotChoco.Dapper.Api.Services
{
    public interface IPersonService
    {
        PersonDto GetFirst();
        List<PersonDto> GetAll();
        List<PersonDto> FilterByFirstName(string firstName);
        List<PersonDto> GetPersonAddress();
        int SavePerson(PersonDto person);
    }
}
