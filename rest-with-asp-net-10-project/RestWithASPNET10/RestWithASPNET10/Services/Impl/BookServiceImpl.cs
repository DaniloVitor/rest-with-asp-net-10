using RestWithASPNET10.Data.Converter.Contract;
using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;
using RestWithASPNET10.Repositories;
using System;

namespace RestWithASPNET10.Services.Impl
{
    public class BookServiceImpl : IBookServices
    {
        private IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookServiceImpl(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookDTO Create(BookDTO book)
        {
            var entidade = _converter.Parser(book);
            entidade = _repository.Create(entidade);
            return _converter.Parser(entidade);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookDTO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookDTO FindById(long id)
        {
            return _converter.Parser(_repository.FindById(id));
        }

        public BookDTO FindByName(string title)
        {
            throw new NotImplementedException();
        }

        public BookDTO Update(BookDTO book)
        {
            var entidade = _converter.Parser(book);
            entidade = _repository.Update(entidade);
            return _converter.Parser(entidade);
        }
    }
}
