using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Domain.Models
{
    public class Endereco
    {
        public int? Id { get; set; }
        public string Uuid { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Referencia { get; set; }
        public int IdTipoEndereco { get; set; }
        public int IdResidenteEndereco { get; set; }
        public int IdResidenteCidade { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual PeriodoResidente PeriodoResidenteCidade { get; set; }
        public virtual PeriodoResidente PeriodoResidenteEndereco { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }
    }
}
