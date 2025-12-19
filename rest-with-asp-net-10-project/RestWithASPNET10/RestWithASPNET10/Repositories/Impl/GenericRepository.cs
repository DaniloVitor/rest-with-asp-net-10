using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Model.Base;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MSSQLContext _context;
        private DbSet<T> _dataSet;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public T Create(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            var item = _dataSet.Find(id);
            if (item == null) return;
            _context.Remove(item);
            _context.SaveChanges();
        }

        public bool Exists(long id)
        {
            return _dataSet.Any(item => item.Id == id);
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(long id)
        {
            return _dataSet.Find(id);
        }

        public T Update(T item)
        {
            T existingItem = _dataSet.Find(item.Id);
            if (existingItem == null) return null;
            _context.Entry(existingItem).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return item;
        }
    }
}
