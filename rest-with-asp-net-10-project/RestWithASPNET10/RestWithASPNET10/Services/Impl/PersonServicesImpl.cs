using RestWithASPNET10.Data.Converter.Contract;
using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;
using RestWithASPNET10.Repositories;

namespace RestWithASPNET10.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonServicesImpl(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entidade = _converter.Parser(person);
            entidade = _repository.Create(entidade);
            return _converter.Parser(entidade);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonDTO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonDTO FindById(long id)
        {
            return _converter.Parser(_repository.FindById(id));
        }

        public PersonDTO Update(PersonDTO person)
        {
            var entidade = _converter.Parser(person);
            entidade = _repository.Update(entidade);
            return _converter.Parser(entidade);
        }
    }
}
