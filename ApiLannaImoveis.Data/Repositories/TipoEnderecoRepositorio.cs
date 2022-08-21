using ApiLannaImoveis.Domain.Interfaces.Repositories;
using ApiLannaImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Data.Repositories
{
    public class TipoEnderecoRepositorio : ITipoEnderecoRepositorio
    {
        private readonly ApplicationContext _context;

        public TipoEnderecoRepositorio(ApplicationContext context)
        {
            _context = context;
        }

        public Task<TipoEndereco> Create(TipoEndereco obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TipoEndereco>> Get()
        {
            return await _context.TipoEnderecos.ToListAsync();
        }

        public Task<TipoEndereco> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(TipoEndereco obj)
        {
            throw new NotImplementedException();
        }
    }
}
