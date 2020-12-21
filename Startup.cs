using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskBackEnd.Context;
using TaskBackEnd.IRepos;
using TaskBackEnd.Repos;
using TaskBackEnd.Supervisors;

namespace TaskBackEnd
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
            /*
             * Dependency Inversion
             * how does dependency happened ? 
             * class A and Class B ==> 
             * class  A
             * { 
             * Public B b;
             * }
             * Dependency Inversion Remove Dependencies and convert it to Abstaction( abstract , Interface)
             * Abstaction ==> for each class(Service , Repository ) make Interface 
             * Class A{
             * public IB b; 
             * }
             * Factory : Control for create instance for interface 
             * when project start create one instance for each interface 
             * IA a = new A(); Correct
             * Commen use Way ==> Dependeny Injection 
             * Factory in Dependeny Injection (AddScoped , AddTransiant , AddSingltoon)
             * Add singltoon same  instanece For All Request
             * Add Transiant new instance for each request
             * Add Scoped gather (siglton and Transiant) for each request new instance and for same scoped one instance
             */
            services.AddHealthChecks();
            services.AddDbContext<BankContext>(builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            });  
            services.AddScoped<Isupervisor, Supervisor>();
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<IAccountTypeRepo, AccountTypeRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<ICurrencyRepo, CurrencyRepo>();
            services.AddScoped<ICurrencyRatioRepo, CurrencyRatioRepo>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.AddScoped<IOperationRepo, OperationRepo>();
           
            services.AddScoped<ITestRepo, TestRepo>();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // Enable middleware to serve generated Swagger as a JSON endpoint.
           

        }
    }
}
