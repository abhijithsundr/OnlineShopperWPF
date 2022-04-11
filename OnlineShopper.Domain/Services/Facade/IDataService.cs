using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopper.Domain.Services.Facade
{
    public interface IDataService<T>
    {
        Task<IAsyncEnumerable<T>> GetAll();

        Task<T?> Get(int id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(int id);
    }
}
