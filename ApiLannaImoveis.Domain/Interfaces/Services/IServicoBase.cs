using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Domain.Interfaces.Services
{
    public interface IServicoBase<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Create(T obj);
        Task Update(T obj);
        Task Delete(int id);
    }
}
