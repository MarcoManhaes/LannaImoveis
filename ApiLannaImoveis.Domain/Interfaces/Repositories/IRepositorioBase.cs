using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Domain.Interfaces.Repositories
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Create(T obj);
        Task Update(T obj);
        Task Delete(int id);
    }
}
