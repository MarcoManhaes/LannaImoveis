using ApiLannaImoveis.Domain.Interfaces.Repositories;
using ApiLannaImoveis.Domain.Interfaces.Services;
using ApiLannaImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Services.Services
{
    public class TipoEnderecoServico : ITipoEnderecoServico
    {
        private readonly ITipoEnderecoRepositorio _tipoEnderecoRepositorio;
        public TipoEnderecoServico(ITipoEnderecoRepositorio tipoEnderecoRepositorio)
        {
            _tipoEnderecoRepositorio = tipoEnderecoRepositorio;
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
            return await _tipoEnderecoRepositorio.Get();
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
