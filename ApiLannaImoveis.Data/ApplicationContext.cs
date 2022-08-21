using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Data.Entity.Core.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite.EF6;
using ApiLannaImoveis.Data.Configurations;
using ApiLannaImoveis.Domain.Models;

namespace ApiLannaImoveis.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base(CreateConnection(), true)
        {
            DbConfiguration.SetConfiguration(new SQLiteConfiguration());
            Database.SetInitializer<ApplicationContext>(null);
        }

        private static DbConnection CreateConnection()
        {
            string connectionString = ConnectionStringConfiguration.ObterConnectionString();

            return new SQLiteConnection(connectionString);
        }

        public class SQLiteConfiguration : DbConfiguration
        {
            public SQLiteConfiguration()
            {
                SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
                SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
                SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
            }
        }

        public bool Commit()
        {
            try
            {
                lock (this)
                {
                    return this.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual DbSet<CategoriaPessoa> CategoriaPessoas { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<FichaCadastral> FichaCadastrals { get; set; }
        public virtual DbSet<PeriodoResidente> PeriodoResidentes { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public virtual DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<TipoEndereco> TipoEnderecos { get; set; }
        public virtual DbSet<TipoTelefone> TipoTelefones { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Pessoa>().ToTable("pessoa");
            modelBuilder.Entity<PessoaJuridica>().ToTable("pessoa_juridica");
            modelBuilder.Entity<PessoaFisica>().ToTable("pessoa_fisica");
            modelBuilder.Entity<CategoriaPessoa>().ToTable("categoria_pessoa");
            modelBuilder.Entity<FichaCadastral>().ToTable("ficha_cadastral");
            modelBuilder.Entity<PeriodoResidente>().ToTable("periodo_residente");
            modelBuilder.Entity<TipoEndereco>().ToTable("tipo_endereco");
            modelBuilder.Entity<TipoTelefone>().ToTable("tipo_telefone");
            modelBuilder.Entity<Email>().ToTable("email");
            modelBuilder.Entity<Endereco>().ToTable("endereco");
            modelBuilder.Entity<Telefone>().ToTable("telefone");

            modelBuilder.Entity<Endereco>().Property(x => x.IdTipoEndereco).HasColumnName("id_tipo_endereco");
            modelBuilder.Entity<Endereco>().Property(x => x.IdResidenteEndereco).HasColumnName("id_residente_endereco");
            modelBuilder.Entity<Endereco>().Property(x => x.IdResidenteCidade).HasColumnName("id_residente_cidade");
            modelBuilder.Entity<Endereco>().Property(x => x.IdPessoa).HasColumnName("id_pessoa");
            


            modelBuilder.Entity<Pessoa>()
                .HasMany<Email>(p => p.Emails)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey<int>(e => e.IdPessoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Pessoa>()
                .HasMany<Endereco>(p => p.Enderecos)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey<int>(e => e.IdPessoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Pessoa>()
                .HasMany<Telefone>(p => p.Telefones)
                .WithOptional(t => t.Pessoa)
                .HasForeignKey<int?>(e => e.IdPessoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FichaCadastral>()
                .HasMany<Pessoa>(fc => fc.Pessoas)
                .WithOptional(p => p.FichaCadastral)
                .HasForeignKey<int?>(e => e.IdFichaCadastral)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CategoriaPessoa>()
                .HasMany<Pessoa>(c => c.Pessoas)
                .WithOptional(p => p.CategoriaPessoa)
                .HasForeignKey<int?>(p => p.IdCategoriaPessoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PessoaJuridica>()
                .HasMany<Pessoa>(pj => pj.Pessoas)
                .WithOptional(p => p.PessoaJuridica)
                .HasForeignKey<int?>(p => p.IdPessoaJuridica)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PessoaFisica>()
                .HasMany<Pessoa>(pf => pf.Pessoas)
                .WithOptional(p => p.PessoaFisica)
                .HasForeignKey<int?>(p => p.IdPessoaFisica)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TipoTelefone>()
                .HasMany<Telefone>(tt => tt.Telefones)
                .WithRequired(t => t.TipoTelefone)
                .HasForeignKey<int>(p => p.IdTipoTelefone)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PeriodoResidente>()
                .HasMany<Endereco>(pr => pr.EnderecosResidenteEndereco)
                .WithRequired(e => e.PeriodoResidenteEndereco)
                .HasForeignKey<int>(e => e.IdResidenteEndereco)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PeriodoResidente>()
                .HasMany<Endereco>(pr => pr.EnderecosResidenteCidade)
                .WithRequired(e => e.PeriodoResidenteCidade)
                .HasForeignKey<int>(e => e.IdResidenteCidade)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TipoEndereco>()
                .HasMany<Endereco>(te => te.Enderecos)
                .WithRequired(e => e.TipoEndereco)
                .HasForeignKey<int>(e => e.IdTipoEndereco)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Email>()
                .HasRequired(e => e.Pessoa)
                .WithRequiredPrincipal();

            modelBuilder.Entity<Telefone>()
                .HasOptional(t => t.Pessoa);

            modelBuilder.Entity<Telefone>()
                .HasRequired(t => t.TipoTelefone)
                .WithRequiredPrincipal();

            modelBuilder.Entity<Pessoa>()
                .HasOptional(p => p.CategoriaPessoa);

            modelBuilder.Entity<Pessoa>()
                .HasOptional(p => p.PessoaJuridica);

            modelBuilder.Entity<Pessoa>()
                .HasOptional(p => p.PessoaFisica);

            modelBuilder.Entity<Pessoa>()
                .HasOptional(p => p.FichaCadastral);

            modelBuilder.Entity<Endereco>()
                .HasRequired(e => e.Pessoa)
                .WithRequiredPrincipal();

            modelBuilder.Entity<Endereco>()
                .HasRequired(e => e.PeriodoResidenteEndereco)
                .WithRequiredPrincipal();

            modelBuilder.Entity<Endereco>()
                .HasRequired(e => e.PeriodoResidenteCidade)
                .WithRequiredPrincipal();

            modelBuilder.Entity<Endereco>()
                .HasRequired(e => e.TipoEndereco)
                .WithRequiredPrincipal();
        }
    }
}