using ApiLannaImoveis.Domain.Interfaces.Repositories;
using ApiLannaImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Data.Repositories
{
    public class CategoriaPessoaRepositorio : ICategoriaPessoaRepositorio
    {
        private readonly ApplicationContext _context;

        public CategoriaPessoaRepositorio(ApplicationContext context)
        {
            _context = context;
        }

        public Task<CategoriaPessoa> Create(CategoriaPessoa obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoriaPessoa>> Get()
        {
            var result = await _context.CategoriaPessoas.ToListAsync();
            return result;
        }

        public Task<CategoriaPessoa> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoriaPessoa obj)
        {
            throw new NotImplementedException();
        }
    }
}
