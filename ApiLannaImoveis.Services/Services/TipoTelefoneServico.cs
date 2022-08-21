using ApiLannaImoveis.Domain.Interfaces.Repositories;
using ApiLannaImoveis.Domain.Interfaces.Services;
using ApiLannaImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Services.Services
{
    public class TipoTelefoneServico : ITipoTelefoneServico
    {
        private readonly ITipoTelefoneRepositorio _tipoTelefoneRepositorio;
        public TipoTelefoneServico(ITipoTelefoneRepositorio tipoTelefoneRepositorio)
        {
            _tipoTelefoneRepositorio = tipoTelefoneRepositorio;
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
            return await _tipoTelefoneRepositorio.Get();
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
