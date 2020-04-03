using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Quarantine.Api.Graphql;
using Quarantine.Api.Graphql.Queries;
using Quarantine.Api.Graphql.Types;
using Quarantine.Core.Repositories;
using Quarantine.Core.Services;
using Quarantine.Data;
using Quarantine.Data.Repositories;

namespace Quarantine.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            // kestrel
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

            services.AddDbContext<QuarantineDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");

                options.UseMySql(connectionString,
                    mySqlOptions => { mySqlOptions.ServerVersion(new Version(10, 5, 1), ServerType.MariaDb); });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Quarantine API", Version = "v1"});
            });


            // GRAPHQL

            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = _env.IsDevelopment();
                    options.ExposeExceptions = _env.IsDevelopment();
                    options.UnhandledExceptionDelegate = ctx => { Console.WriteLine(ctx.OriginalException); };
                }).AddNewtonsoftJson(settings => { })
                .AddDataLoader()
                .AddGraphTypes(typeof(RootSchema), ServiceLifetime.Scoped);

            // services.AddSingleton<IDocumentExecuter, SerialDocumentExecuter>();

            services.AddScoped<RootSchema>();

            // END GRAPHQL

            services.AddScoped<AuthorService>();
            services.AddScoped<BookService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quarantine API"); });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // GRAPHQL
            app.UseGraphQL<RootSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                PlaygroundSettings = new Dictionary<string, object>
                {
                    {"editor.cursorShape", "line"},
                    {
                        "editor.fontFamily",
                        "'Source Code Pro', 'Consolas', 'Inconsolata', 'Droid Sans Mono', 'Monaco', monospace`"
                    },
                    {"editor.fontSize", 14},
                    {"editor.reuseHeaders", true},
                    {"editor.theme", "dark"},
                    {"general.betaUpdates", true},
                    {"prettier.printWidth", 80},
                    {"prettier.tabWidth", 2},
                    {"prettier.useTabs", false},
                    {"tracing.hideTracingResponse", false},
                }
            });

            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();

            var context = serviceScope.ServiceProvider.GetRequiredService<QuarantineDbContext>();
            context.Database.Migrate();
        }
    }
}