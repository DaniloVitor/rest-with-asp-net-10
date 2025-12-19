using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Repositories.Impl
{
    public class BookRepository : IBookRepository
    {
        private MSSQLContext _context;

        public BookRepository(MSSQLContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void Delete(long id)
        {
            Book book = _context.Books.Find(id);
            _context.Remove(book);
            _context.SaveChanges();
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.Find(id);
        }

        public Book Update(Book book)
        {
            Book existingBook = _context.Books.Find(book.Id);
            if (existingBook == null) return null;
            _context.Entry(existingBook).CurrentValues.SetValues(book);
            return book;
        }
    }
}
