using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using System;

namespace RestWithASPNET10.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        private MSSQLContext _context;

        public PersonServicesImpl(MSSQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(long id)
        {
            var existingPerson = _context.Persons.Find(id);
            if (existingPerson == null) return;

            _context.Remove(existingPerson);
            _context.SaveChanges();
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.Find(id);
        }

        public Person Update(Person person)
        {
            var existingPerson = _context.Persons.Find(person.Id);
            if (existingPerson == null) return null;
            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }

        private Person MockPerson(int i)
        {
            var person = new Person
            {
                Id = new Random().Next(1, 1000),
                FirstName = "Danilo - " + i,
                LastName = "Vitor - " + i,
                Address = "123 - " + i,
                Gender = "Male - " + i
            };

            return person;
        }
    }
}
