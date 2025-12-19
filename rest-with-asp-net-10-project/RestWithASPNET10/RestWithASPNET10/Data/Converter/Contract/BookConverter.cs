using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;

namespace RestWithASPNET10.Data.Converter.Contract
{
    public class BookConverter : IParser<BookDTO, Book>, IParser<Book, BookDTO>
    {
        public List<Book> ParseList(List<BookDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }

        public List<BookDTO> ParseList(List<Book> origin)
        {
            if(origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }

        public Book Parser(BookDTO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LauchDate = origin.LauchDate,
                Price = origin.Price
            };
        }

        public BookDTO Parser(Book origin)
        {
            if (origin == null) return null;
            return new BookDTO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LauchDate = origin.LauchDate,
                Price = origin.Price
            };
        }
    }
}
