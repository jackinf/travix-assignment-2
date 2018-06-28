using System.Collections.Generic;

namespace WingsOn.Domain.Repository
{
    public interface IRepository<T> where T : DomainObject
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Save(T element);
    }
}
