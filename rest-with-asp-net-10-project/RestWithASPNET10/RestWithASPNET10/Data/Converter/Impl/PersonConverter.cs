using RestWithASPNET10.Data.Converter.Contract;
using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;

namespace RestWithASPNET10.Data.Converter.Impl
{
    public class PersonConverter : IParser<PersonDTO, Person>, IParser<Person, PersonDTO>
    {
        public Person Parser(PersonDTO origin)
        {
           if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public PersonDTO Parser(Person origin)
        {
             if (origin == null) return null;
            return new PersonDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> ParseList(List<PersonDTO> origin)
        {
            if(origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }

        public List<PersonDTO> ParseList(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }
    }
}
