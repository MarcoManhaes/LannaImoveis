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
    public class TipoTelefoneController : ControllerBase
    {
        private ITipoTelefoneServico _tipoTelefoneServico;

        public TipoTelefoneController(ITipoTelefoneServico tipoTelefoneServico)
        {
            _tipoTelefoneServico = tipoTelefoneServico;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoTelefone>> GetCategoriaPessoa()
        {
            return await _tipoTelefoneServico.Get();
        }
    }
}
