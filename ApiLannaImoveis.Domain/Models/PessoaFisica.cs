using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Domain.Models
{
    public class PessoaFisica
    {
        public int? Id { get; set; }
        public string Uuid { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimento { get; set; }
        public long Cpf { get; set; }
        public long? Rg { get; set; }
        public string Nacionalidade { get; set; }
        public string Naturalidade { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
