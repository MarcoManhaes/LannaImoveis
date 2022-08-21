using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Domain.Models
{
    public class CategoriaPessoa
    {
        //public CategoriaPessoa()
        //{
        //    Pessoas = new HashSet<Pessoa>();
        //}

        public int? Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
