using AutoMapper;
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
using PaparaRepositoryPattern.Data.Abstarcts;
using PaparaRepositoryPattern.Data.Concretes;
using PaparaRepositoryPattern.Data.Context;
using PaparaRepositoryPattern.Services.Abstracts;
using PaparaRepositoryPattern.Services.Automapper;
using PaparaRepositoryPattern.Services.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaparaRepositoryPattern.API", Version = "v1" });
            });

            //DbContext
            services.AddDbContext<PaparaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));           
            //Automapper
            services.AddAutoMapper(typeof(MyMapper));
            //Repos
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //Services
            services.AddTransient<ICompanyService, CompanyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaparaRepositoryPattern.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
