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
    public class CategoriaPessoaController : ControllerBase
    {
        private ICategoriaPessoaServico _categoriaPessoaServico;

        public CategoriaPessoaController(ICategoriaPessoaServico categoriaPessoaServico)
        {
            _categoriaPessoaServico = categoriaPessoaServico;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaPessoa>> GetCategoriaPessoa()
        {
            return await _categoriaPessoaServico.Get();
        }
    }
}
