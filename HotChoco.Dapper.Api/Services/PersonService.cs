using Dapper;
using HotChoco.Dapper.Api.Dtos;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotChoco.Dapper.Api.Services
{
    public class PersonService: IPersonService
    {
        private readonly IConfiguration _configuration;

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("MyWorldDbConnection"));
            }
        }
        public PersonService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PersonDto GetFirst()
        {

            using (var conn = Connection)
            {
                var query = "Select top 1 * from Persons";
                var person = conn.Query<PersonDto>(query).FirstOrDefault();
                return person;
            }
        }

        public List<PersonDto> GetAll()
        {
            using (var conn = Connection)
            {
                var query = "Select * from Persons";
                var persons = conn.Query<PersonDto>(query).ToList();
                return persons;
            }
        }

        public List<PersonDto> FilterByFirstName(string firstName)
        {
            using(var conn = Connection)
            {
                var query = "Select * from Persons where FirstName = @firstName";
                var persons = conn.Query<PersonDto>(query, new { firstName }).ToList();
                return persons;
            }
        }

        public List<PersonDto> GetPersonAddress()
        {
            using (var conn = Connection)
            {
                var query = @"
                            Select * From Persons

                            Select * From PersonAddress
                            ";

                var result = conn.QueryMultiple(query);
                var persons = result.Read<PersonDto>().ToList();
                var address = result.Read<PersonAddressDto>().ToList();
                foreach (var person in persons)
                {
                    person.Address = address.Where(_ => _.PersonId == person.ID).ToList();
                }
                return persons;
            }
        }

        public int SavePerson(PersonDto person)
        {
            using(var conn = Connection)
            {
                var command = @"INSERT INTO Persons(LastName, FirstName, Age)
                                VALUES (@LastName, @FirstName, @Age)";

                var saved = conn.Execute(command, param: person);
                return saved;
            }
        }
    }

    
}
