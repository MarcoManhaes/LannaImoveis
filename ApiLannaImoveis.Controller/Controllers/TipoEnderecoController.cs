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
    public class TipoEnderecoController : ControllerBase
    {
        private ITipoEnderecoServico _tipoEnderecoServico;

        public TipoEnderecoController(ITipoEnderecoServico tipoEnderecoServico)
        {
            _tipoEnderecoServico = tipoEnderecoServico;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoEndereco>> GetCategoriaPessoa()
        {
            return await _tipoEnderecoServico.Get();
        }
    }
}
