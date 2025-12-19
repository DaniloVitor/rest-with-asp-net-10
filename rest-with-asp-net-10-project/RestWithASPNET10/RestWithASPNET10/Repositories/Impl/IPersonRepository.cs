using RestWithASPNET10.Model;

namespace RestWithASPNET10.Repositories.Impl
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
