using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Domain.Models
{
    public class Pessoa
    {
        public int? Id { get; set; }
        public string Uuid { get; set; }
        public int? IdPessoaFisica { get; set; }
        public int? IdPessoaJuridica { get; set; }
        public int? IdCategoriaPessoa { get; set; }
        public int? IdFichaCadastral { get; set; }

        public virtual CategoriaPessoa CategoriaPessoa { get; set; }
        public virtual FichaCadastral FichaCadastral { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }

    }
}
