using ApiLannaImoveis.Data;
using ApiLannaImoveis.Data.Configurations;
using ApiLannaImoveis.Data.Migrations;
using ApiLannaImoveis.Data.Repositories;
using ApiLannaImoveis.Domain.Interfaces.Repositories;
using ApiLannaImoveis.Domain.Interfaces.Services;
using ApiLannaImoveis.Services.Services;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SQLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LannaImoveis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ExecuteMigration();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencyInjection(services);

            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LannaImoveisAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
            //options.WithOrigins("http://localhost:3000")
            //       .AllowAnyHeader()
            //       .AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LannaImoveisAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }

        static void ExecuteMigration()
        {
            Console.WriteLine("Create the announcer to output the migration messages...");
            var announcer = new ConsoleAnnouncer();

            Console.WriteLine("Processor specific options (usually none are needed)...");
            var options = new ProcessorOptions();

            Console.WriteLine("Use SQLite...");
            var processorFactory = new SQLiteProcessorFactory();

            Console.WriteLine("Get ConnectionString...");
            var connectionString = ConnectionStringConfiguration.ObterConnectionString();

            Console.WriteLine("Initialize the processor...");
            using (var processor = processorFactory.Create(
                connectionString,
                announcer,
                options))
            {
                Console.WriteLine("Configure the runner...");
                var context = new RunnerContext(announcer);

                Console.WriteLine("Create the migration runner...");
                Console.WriteLine("Specify the assembly with the migrations...");
                var runner = new MigrationRunner(
                    typeof(Initial_Migration_1).Assembly,
                    context,
                    processor);

                Console.WriteLine("Run the migrations...");
                runner.MigrateUp();
            }
        }

        private static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();

            services.AddScoped<ICategoriaPessoaServico, CategoriaPessoaServico>();
            services.AddScoped<ICategoriaPessoaRepositorio, CategoriaPessoaRepositorio>();

            services.AddScoped<IPeriodoResidenteServico, PeriodoResidenteServico>();
            services.AddScoped<IPeriodoResidenteRepositorio, PeriodoResidenteRepositorio>();

            services.AddScoped<ITipoEnderecoServico, TipoEnderecoServico>();
            services.AddScoped<ITipoEnderecoRepositorio, TipoEnderecoRepositorio>();

            services.AddScoped<ITipoTelefoneServico, TipoTelefoneServico>();
            services.AddScoped<ITipoTelefoneRepositorio, TipoTelefoneRepositorio>();



            //services.AddScoped<ICategotiaPessoaServico, CategotiaPessoaServico>();
            //services.AddScoped<ICategotiaPessoaServico, CategotiaPessoaServico>();
        }
    }
}
