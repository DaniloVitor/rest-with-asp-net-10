using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services
{
    public interface IBookServices
    {
        BookDTO Create(BookDTO book);
        void Delete(long id);
        List<BookDTO> FindAll();
        BookDTO FindById(long id);
        BookDTO FindByName(string title);
        BookDTO Update(BookDTO book);
    }
}
