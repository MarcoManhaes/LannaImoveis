using ApiLannaImoveis.Domain.Interfaces.Repositories;
using ApiLannaImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Data.Repositories
{
    public class TipoTelefoneRepositorio : ITipoTelefoneRepositorio
    {
        private readonly ApplicationContext _context;

        public TipoTelefoneRepositorio(ApplicationContext context)
        {
            _context = context;
        }

        public Task<TipoTelefone> Create(TipoTelefone obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TipoTelefone>> Get()
        {
            return await _context.TipoTelefones.ToListAsync();
        }

        public Task<TipoTelefone> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(TipoTelefone obj)
        {
            throw new NotImplementedException();
        }
    }
}
