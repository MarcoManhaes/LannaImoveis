using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Domain.Models
{
    public class PeriodoResidente
    {
        public int? Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Endereco> EnderecosResidenteCidade { get; set; }
        public virtual ICollection<Endereco> EnderecosResidenteEndereco { get; set; }
    }
}
