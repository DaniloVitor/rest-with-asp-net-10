using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services
{
    public interface IBookServices
    {
        Book Create(Book book);
        void Delete(long id);
        List<Book> FindAll();
        Book FindById(long id);
        Book FindByName(string title);
        Book Update(Book book);
    }
}
