using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V03.Dal
{
    public static class RepositoryFactory
    {
        public static TRepository GetRepositoryInstance<T, TRepository>(params object[] args)
            where TRepository : IRepository<T>{
            return (TRepository)Activator.CreateInstance(typeof(TRepository), args);
        }
    }
}
