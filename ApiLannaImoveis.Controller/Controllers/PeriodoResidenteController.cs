using ApiLannaImoveis.Domain.Interfaces.Services;
using ApiLannaImoveis.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLannaImoveis.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodoResidenteController : ControllerBase
    {
        private IPeriodoResidenteServico _periodoResidenteServico;

        public PeriodoResidenteController(IPeriodoResidenteServico periodoResidenteServico)
        {
            _periodoResidenteServico = periodoResidenteServico;
        }

        [HttpGet]
        public async Task<IEnumerable<PeriodoResidente>> GetCategoriaPessoa()
        {
            return await _periodoResidenteServico.Get();
        }
    }
}
