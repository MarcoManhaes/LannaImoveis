using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Domain.Models
{
    public class FichaCadastral
    {
        public int? Id { get; set; }
        public string Uuid { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
