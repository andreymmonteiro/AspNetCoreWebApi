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

            //N�o � interessante injetar o contexto diretamente no controller, a utiliza��o do contexto dessa forma vai trazer dados de outros models desnecessariamente consumindo recursos
            //O encapsulmaneto � necess�rio para quest�es de seguran�a, ele esconde os membros de uma classe para acesso externo usando identificadores de acesso

            //Aqui estamos dizendo para o nosso servi�o que o SmartContext � nosso contexto e estamos usando Sqlite
            services.AddDbContext<SmartContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
                );

            //Toda vez que eu usar o IRepository eu estarei usando o Repository
            #region AddSingleton
            //Quando iniciar o servi�o ele vai estanciar o contexto (Repository) e sempre usar a mesma inst�ncia. Compartilhando a mesma mem�ria em todas as requisi��es
            //services.AddSingleton<IRepository, Repository>();
            #endregion
            #region AddTransient
            //Ele nunca vai usar a mesma requisi��o amesma inst�ncia, ou seja. Se houver 5 depend�ncias ou requisi��es ,ser�o 5 inst�ncias distintas
            //services.AddTransient<IRepository, Repository>();
            #endregion
            #region AddScoped
            //Ele cria uma inst�ncia e caso houver alguma depend�ncia de outro objeto ele utiliza essa mesma, ele s� renova a inst�ncia em caso de nova requisi��o
            services.AddScoped<IRepository, Repository>();
            #endregion

            //Ele � quem define as rotas
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
