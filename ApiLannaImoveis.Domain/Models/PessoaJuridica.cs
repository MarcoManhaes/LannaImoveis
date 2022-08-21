using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Domain.Models
{
    public class PessoaJuridica
    {
        public int? Id { get; set; }
        public string Uuid { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public long Cnpj { get; set; }
        public string NomeResponsavel { get; set; }
        public long? CpfResponsavel { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
