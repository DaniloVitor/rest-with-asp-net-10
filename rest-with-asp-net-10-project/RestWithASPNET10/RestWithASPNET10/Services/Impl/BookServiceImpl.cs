using RestWithASPNET10.Model;
using RestWithASPNET10.Repositories;
using System;

namespace RestWithASPNET10.Services.Impl
{
    public class BookServiceImpl : IBookServices
    {
        private IRepository<Book> _repository;

        public BookServiceImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book FindByName(string title)
        {
            throw new NotImplementedException();
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
