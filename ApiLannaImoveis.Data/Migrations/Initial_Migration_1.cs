using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLannaImoveis.Data.Migrations
{
    [Migration(1)]
    public class Initial_Migration_1 : Migration
    {
        public override void Up()
        {
            #region[+] categoria_pessoa
            string sqlCategoriaPessoa = @"CREATE TABLE categoria_pessoa (
                                        id        INTEGER      UNIQUE PRIMARY KEY AUTOINCREMENT NOT NULL,
                                        codigo    INTEGER      UNIQUE,
                                        descricao VARCHAR (20) );";
            #endregion

            #region[+] tipo_endereco
            string sqlTipoEndereco =    @"CREATE TABLE tipo_endereco (
                                        id        INTEGER      UNIQUE PRIMARY KEY AUTOINCREMENT NOT NULL,
                                        codigo    INTEGER      UNIQUE,
                                        descricao VARCHAR (20) );";
            #endregion

            #region[+] periodo_residente
            string sqlPeriodoResidente = @"CREATE TABLE periodo_residente (
                                        id        INTEGER      UNIQUE PRIMARY KEY AUTOINCREMENT NOT NULL,
                                        codigo    INTEGER      UNIQUE,
                                        descricao VARCHAR (20) );";
            #endregion

            #region[+] tipo_telefone
            string sqlTipoTelefone = @"CREATE TABLE tipo_telefone (
                                        id        INTEGER      UNIQUE PRIMARY KEY AUTOINCREMENT NOT NULL,
                                        codigo    INTEGER      UNIQUE,
                                        descricao VARCHAR (20) );";
            #endregion

            #region[+] pessoa_juridica
            string sqlPessoaJuridica = @"CREATE TABLE pessoa_juridica (
                                        id               INTEGER      PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
                                        uuid             VARCHAR (40) UNIQUE,
                                        razao_social     VARCHAR (60),
                                        nome_fantasia    VARCHAR (60),
                                        cnpj             BIGINT,
                                        nome_responsavel VARCHAR (60),
                                        cpf_responsavel  BIGINT);";
            #endregion

            #region[+] pessoa_fisica
            string sqlPessoaFisica = @"CREATE TABLE pessoa_fisica (
                                    id              INTEGER      PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
                                    uuid            VARCHAR (40) UNIQUE,
                                    nome            VARCHAR (60),
                                    apelido         VARCHAR (20),
                                    nome_pai        VARCHAR (60),
                                    nome_mae        VARCHAR (60),
                                    data_nascimento DATETIME,
                                    cpf             BIGINT,
                                    rg              VARCHAR (14),
                                    nacionalidade   VARCHAR (30),
                                    naturalidade    VARCHAR (30) );";
            #endregion

            #region[+] ficha_cadastral
            string sqlFichaCadastral = @"CREATE TABLE fica_cadastral (
                                        id               INTEGER      PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
                                        uuid             VARCHAR (40) UNIQUE,
                                        data_criacao     DATETIME     NOT NULL,
                                        data_atualizacao DATETIME );";
            #endregion

            #region[+] pessoa
            string sqlPessoa = @"CREATE TABLE pessoa (
                                id                  INTEGER      PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
                                uuid                VARCHAR (40) UNIQUE,
                                id_pessoa_fisica    INTEGER      CONSTRAINT fk_pessoa_pessoa_fisica REFERENCES pessoa_fisica (id),
                                id_pessoa_juridica  INTEGER      CONSTRAINT fk_pessoa_pessoa_juridica REFERENCES pessoa_juridica (id),
                                id_categoria_pessoa INTEGER      CONSTRAINT fk_pessoa_categoria_pessoa REFERENCES categoria_pessoa (id),
                                id_ficha_cadastral  INTEGER      CONSTRAINT fk_pessoa_ficha_cadastral REFERENCES fica_cadastral (id) );";
            #endregion

            #region[+] telefone
            string sqlTelefone = @"CREATE TABLE telefone (
                                id               INTEGER      PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
                                uuid             VARCHAR (40) UNIQUE,
                                ddd              INTEGER,
                                numero_telefone  INTEGER,
                                ramal            INTEGER,
                                id_tipo_telefone INTEGER      CONSTRAINT fk_telefone_tipo_telefone REFERENCES tipo_telefone (id),
                                id_pessoa        INTEGER      CONSTRAINT fk_telefone_pessoa REFERENCES pessoa (id) );";
            #endregion

            #region[+] email
            string sqlEmail = @"CREATE TABLE email (
                                id        INTEGER       PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
                                uuid      VARCHAR (40)  UNIQUE,
                                email     VARCHAR (70),
                                descricao VARCHAR (150),
                                id_pessoa INTEGER       CONSTRAINT fk_email_pessoa REFERENCES pessoa (id) );";
            #endregion

            #region[+] endereco 
            string sqlEndereco = @"CREATE TABLE endereco (
                                id                    INTEGER      PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
                                uuid                  VARCHAR (40) UNIQUE,
                                cep                   INTEGER,
                                logradouro            VARCHAR (70),
                                numero                VARCHAR (8),
                                bairro                VARCHAR (40),
                                cidade                VARCHAR (40),
                                uf                    VARCHAR (2),
                                referencia            VARCHAR (50),
                                id_tipo_endereco      INTEGER      CONSTRAINT fk_endereco_tipo_endereco REFERENCES tipo_endereco (id),
                                id_residente_endereco INTEGER      CONSTRAINT fk_endereco_periodo_residente_endereco REFERENCES periodo_residente (id),
                                id_residente_cidade   INTEGER      CONSTRAINT fk_endereco_periodo_residente_cidade REFERENCES periodo_residente (id),
                                id_pessoa             INTEGER      CONSTRAINT fk_endereco_pessoa REFERENCES pessoa (id) );";
            #endregion

            #region[+]
            string sqlPopupaCategoriaPessoa = @"PRAGMA ignore_check_constraints = 1; 
                                                INSERT INTO `categoria_pessoa` (`id`, `codigo`, `descricao`) VALUES
                                                    (1, 1, 'Pretendente'),
	                                                (2, 2, 'Fiador'),
	                                                (3, 3, 'Cônjuge');
                                                PRAGMA ignore_check_constraints = 0; ";
            #endregion

            #region[+]  
            string sqlPopupaPeriodoResidente = @"PRAGMA ignore_check_constraints = 1; 
                                                INSERT INTO `periodo_residente` (`id`, `codigo`, `descricao`) VALUES
	                                                (1, 1, 'até 1 ano'),
	                                                (2, 2, 'de 1 a 2 anos'),
	                                                (3, 3, 'de 2 a 3 anos'),
	                                                (4, 4, 'de 3 a 4 anos'),
	                                                (5, 5, 'de 4 a 5 anos'),
	                                                (6, 6, 'mais de 5 anos');
                                                PRAGMA ignore_check_constraints = 0;";
            #endregion

            #region[+]  
            string sqlPopupaTipoEndereco = @"PRAGMA ignore_check_constraints = 1 ;
                                            INSERT INTO `tipo_endereco` (`id`, `codigo`, `descricao`) VALUES
	                                            (1, 1, 'Residencial'),
	                                            (2, 2, 'Comercial'),
	                                            (3, 3, 'Cônjuge');
                                            PRAGMA ignore_check_constraints = 0;";
            #endregion

            #region[+]  
            string sqlPopupaTipoTelefone = @"PRAGMA ignore_check_constraints = 1;
                                            INSERT INTO `tipo_telefone` (`id`, `codigo`, `descricao`) VALUES
	                                            (1, 1, 'Pessoal'),
	                                            (2, 2, 'Residencial'),
	                                            (3, 3, 'Comercial');
                                            PRAGMA ignore_check_constraints = 0;";
            #endregion

            #region[+] Execute
            Execute.Sql(sqlCategoriaPessoa);
            Execute.Sql(sqlTipoEndereco);
            Execute.Sql(sqlPeriodoResidente);
            Execute.Sql(sqlTipoTelefone);
            Execute.Sql(sqlPessoaJuridica);
            Execute.Sql(sqlPessoaFisica);
            Execute.Sql(sqlFichaCadastral);
            Execute.Sql(sqlPessoa);
            Execute.Sql(sqlTelefone);
            Execute.Sql(sqlEmail);
            Execute.Sql(sqlEndereco);
            Execute.Sql(sqlPopupaCategoriaPessoa);
            Execute.Sql(sqlPopupaPeriodoResidente);
            Execute.Sql(sqlPopupaTipoEndereco);
            Execute.Sql(sqlPopupaTipoTelefone);
            #endregion
        }

        public override void Down()
        {
            #region[+] Downgrade
            Delete.Table("categoria_pessoa");
            Delete.Table("tipo_endereco");
            Delete.Table("periodo_residente");
            Delete.Table("tipo_telefone");
            Delete.Table("pessoa_juridica");
            Delete.Table("pessoa_fisica");
            Delete.Table("pessoa");
            Delete.Table("telefone");
            Delete.Table("email");
            Delete.Table("endereco");
            #endregion
        }
    }
}
