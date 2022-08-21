using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Domain.Models
{
    public class Email
    {
        public int? Id { get; set; }
        public string Uuid { get; set; }
        public string Email1 { get; set; }
        public string Descricao { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
