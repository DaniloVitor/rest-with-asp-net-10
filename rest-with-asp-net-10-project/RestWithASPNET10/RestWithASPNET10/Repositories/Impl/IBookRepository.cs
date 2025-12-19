using RestWithASPNET10.Model;

namespace RestWithASPNET10.Repositories.Impl
{
    public interface IBookRepository
    {
        Book Create(Book book);
        void Delete(long id);
        List<Book> FindAll();
        Book FindById(long id);
        Book Update(Book book);
    }
}
