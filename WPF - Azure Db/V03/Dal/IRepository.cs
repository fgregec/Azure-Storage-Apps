using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V03.Dal
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        IList<T> GetAll();
        T Get(int id);
    }
}
