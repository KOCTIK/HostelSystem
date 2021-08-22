using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostelsystem.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<object> GetAll();
        IEnumerable<object> GetFiltered(Filter filter);
        void Add(TEntity entity);
    }
}
