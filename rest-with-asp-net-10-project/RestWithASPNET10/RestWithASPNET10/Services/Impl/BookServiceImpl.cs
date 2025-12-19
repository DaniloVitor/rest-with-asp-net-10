using Mapster;
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
        }

        public BookDTO Create(BookDTO book)
        {
            var entidade = book.Adapt<Book>();
            entidade = _repository.Create(entidade);
            return entidade.Adapt<BookDTO>();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<BookDTO>>();
        }

        public BookDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BookDTO>();
        }

        public BookDTO Update(BookDTO book)
        {
            var entidade = book.Adapt<Book>();
            entidade = _repository.Update(entidade);
            return entidade.Adapt<BookDTO>();
        }
    }
}
