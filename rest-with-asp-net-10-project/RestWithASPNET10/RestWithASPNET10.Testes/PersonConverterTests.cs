using FluentAssertions;
using RestWithASPNET10.Data.Converter.Impl;
using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;

namespace RestWithASPNET10.Testes
{
    public class PersonConverterTests
    {
        private readonly PersonConverter _converter;

        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }

        [Fact]
        public void Parse_ShouldConvertPersonDTOToPerson()
        {
            var dto = new PersonDTO
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Address = "123 Main Stret",
                Gender = "Male"
            };

            var expectedPerson = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Address = "123 Main Stret",
                Gender = "Male"
            };

            var person = _converter.Parser(dto);
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Address.Should().Be(expectedPerson.Address);
            person.Gender.Should().Be(expectedPerson.Gender);

            person.Should().BeEquivalentTo(expectedPerson);
        }

        [Fact]
        public void Parse_NullPersonDTOShouldReturnNull()
        {
            PersonDTO dto = null;
            var person = _converter.Parser(dto);
            person.Should().BeNull();
        }


        [Fact]
        public void Parse_ShouldConvertPersonToPersonDTO()
        {
            var entity = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Address = "123 Main Stret",
                Gender = "Male"
            };

            var expectedPerson = new PersonDTO
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Address = "123 Main Stret",
                Gender = "Male"
            };

            var person = _converter.Parser(entity);
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Address.Should().Be(expectedPerson.Address);
            person.Gender.Should().Be(expectedPerson.Gender);
            person.Should().BeEquivalentTo(expectedPerson);
        }

        [Fact]
        public void Parse_NullPersonShouldReturnNull()
        {
            Person entity = null;
            var person = _converter.Parser(entity);
            person.Should().BeNull();
        }

        public void ParseList_ShouldConvertPersonDTOListToPersonList()
        {
            var dtoList = new List<PersonDTO>
            {
                new PersonDTO
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Test",
                    Address = "Brasil",
                    Gender = "Male"
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Danilo",
                    LastName = "Vitor",
                    Address = "Brasil",
                    Gender = "Male"
                }
            };

            var personList = _converter.ParseList(dtoList);

            personList.Should().NotBeNull();
            personList.Should().HaveCount(2);
            personList[0].Should().BeEquivalentTo(new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Address = "Brasil",
                Gender = "Male"
            });
            personList[1].Should().BeEquivalentTo(new Person
            {
                Id = 2,
                FirstName = "Danilo",
                LastName = "Vitor",
                Address = "Brasil",
                Gender = "Male"
            });

            personList[0].FirstName.Should().Be("Test");
            personList[1].FirstName.Should().Be("Danilo");
        }


        [Fact]
        public void Parse_NullListPersonDTOShouldReturnNull()
        {
            List<PersonDTO> dto = null;
            var listPerson = _converter.ParseList(dto);
            listPerson.Should().BeNull();
        }
    }
}
