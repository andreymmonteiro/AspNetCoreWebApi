using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SmartSchool.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Não é interessante injetar o contexto diretamente no controller, a utilização do contexto dessa forma vai trazer dados de outros models desnecessariamente consumindo recursos
            //O encapsulmaneto é necessário para questões de segurança, ele esconde os membros de uma classe para acesso externo usando identificadores de acesso

            //Aqui estamos dizendo para o nosso serviço que o SmartContext é nosso contexto e estamos usando Sqlite
            services.AddDbContext<SmartContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
                );

            //Toda vez que eu usar o IRepository eu estarei usando o Repository
            #region AddSingleton
            //Quando iniciar o serviço ele vai estanciar o contexto (Repository) e sempre usar a mesma instância. Compartilhando a mesma memória em todas as requisições
            //services.AddSingleton<IRepository, Repository>();
            #endregion
            #region AddTransient
            //Ele nunca vai usar a mesma requisição amesma instância, ou seja. Se houver 5 dependências ou requisições ,serão 5 instâncias distintas
            //services.AddTransient<IRepository, Repository>();
            #endregion
            #region AddScoped
            //Ele cria uma instância e caso houver alguma dependência de outro objeto ele utiliza essa mesma, ele só renova a instância em caso de nova requisição
            services.AddScoped<IRepository, Repository>();
            #endregion

            //Ele é quem define as rotas
            services.AddControllers()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                                                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartSchool.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartSchool.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
