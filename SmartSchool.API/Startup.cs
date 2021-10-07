using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SmartSchool.API.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

            //Ele � quem define as rotas
            services.AddControllers()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                                                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //Estou passando a aplica��o de dom�nios dos assemblies. O AutoMapper vai procurar dentro das Dlls qual que � a classe que herda de Profile
            //Basicamente mapear os Dtos e as models, o dom�nio
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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


            #region Defir vers�o ou vers�es da web api

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            }).AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });


            var apiProviderDescription = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();
            #endregion


            
            services.AddSwaggerGen(c =>
            {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    c.SwaggerDoc(
                        description.GroupName, 
                        
                        new OpenApiInfo
                        {
                            Title = "SmartSchool API",
                            Description = description.GroupName,
                            Version = description.ApiVersion.ToString(),
                            TermsOfService = new Uri("http://elementare.inf.br"),
                            License = new OpenApiLicense
                            {
                                Name = "Smart School License",
                                Url = new Uri("http://elementare.inf.br")
                            },
                            Contact = new OpenApiContact
                            {
                                Name = "Andrey Monteiro",
                                Email = "andrey@elementare.inf.br",
                                Url = new Uri("http://elementare.inf.br")
                            }
                        });
                }
                
                //Pega o nome do arquivo xml
                var xmlComentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //Pega local onde esta rodando aaplica��o
                var xmlComentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlComentsFile);
                //concatena o caminho com o nome do arquivo para que seja poss�vel visualizar os coment�rios
                c.IncludeXmlComments(xmlComentsFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiProviderDescription)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                {
                    foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                    {
                        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                    
                });
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
