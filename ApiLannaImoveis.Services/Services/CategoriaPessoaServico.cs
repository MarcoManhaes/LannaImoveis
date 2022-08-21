using ApiLannaImoveis.Domain.Interfaces.Repositories;
using ApiLannaImoveis.Domain.Interfaces.Services;
using ApiLannaImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Services.Services
{
    public class CategoriaPessoaServico : ICategoriaPessoaServico
    {
        private readonly ICategoriaPessoaRepositorio _categoriaPessoaRepositorio;
        public CategoriaPessoaServico(ICategoriaPessoaRepositorio categoriaPessoaRepositorio)
        {
            _categoriaPessoaRepositorio = categoriaPessoaRepositorio;
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
            return await _categoriaPessoaRepositorio.Get();
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
