using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Domain.Models
{
    public class Telefone
    {
        public int? Id { get; set; }
        public string Uuid { get; set; }
        public int Ddd { get; set; }
        public int NumeroTelefone { get; set; }
        public int Ramal { get; set; }
        public int IdTipoTelefone { get; set; }
        public int? IdPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }
    }
}
