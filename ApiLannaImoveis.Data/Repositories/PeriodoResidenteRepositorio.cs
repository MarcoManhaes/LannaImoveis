using ApiLannaImoveis.Domain.Interfaces.Repositories;
using ApiLannaImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Data.Repositories
{
    public class PeriodoResidenteRepositorio : IPeriodoResidenteRepositorio
    {
        private readonly ApplicationContext _context;

        public PeriodoResidenteRepositorio(ApplicationContext context)
        {
            _context = context;
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
            var result = await _context.PeriodoResidentes.ToListAsync();
            return result;
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
