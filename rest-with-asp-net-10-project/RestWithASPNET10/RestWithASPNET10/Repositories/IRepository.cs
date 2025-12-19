using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Base;

namespace RestWithASPNET10.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        void Delete(long id);
        List<T> FindAll();
        T FindById(long id);
        T Update(T item);
        bool Exists(long id);
    }
}
