using ApiLannaImoveis.Domain.Interfaces.Repositories;
using ApiLannaImoveis.Domain.Interfaces.Services;
using ApiLannaImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Services.Services
{
    public class PeriodoResidenteServico : IPeriodoResidenteServico
    {
        private readonly IPeriodoResidenteRepositorio _periodoResidenteRepositorio;
        public PeriodoResidenteServico(IPeriodoResidenteRepositorio periodoResidenteRepositorio)
        {
            _periodoResidenteRepositorio = periodoResidenteRepositorio;
        }

        public Task<PeriodoResidente> Create(PeriodoResidente obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PeriodoResidente>> Get()
        {
            return await _periodoResidenteRepositorio.Get();
        }

        public Task<PeriodoResidente> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(PeriodoResidente obj)
        {
            throw new NotImplementedException();
        }
    }
}
