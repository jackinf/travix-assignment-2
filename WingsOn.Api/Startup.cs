using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WingsOn.Api.Services;
using WingsOn.Dal;
using WingsOn.Domain;
using WingsOn.Domain.Dto;
using WingsOn.Domain.Repository;
using WingsOn.Domain.Services;

namespace WingsOn.Api
{
    public class Startup
    {
        static Startup()
        {
            // Register mappers. TODO: It is currently in static constructor, because it will be on a single thread and run only once. Does not break async unit tests. Though there are better ways of resolving this.
            Mapper.Initialize(config => { config.CreateMap<Person, PersonDto>().ReverseMap(); });
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WingsOn API", Version = "v1" });
                c.IncludeXmlComments(
                    Path.Combine(AppContext.BaseDirectory, GetType().Assembly.GetName().Name + ".xml"),
                    includeControllerXmlComments: true);
            });

            // Register services
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IFlightsService, FlightsService>();

            // Register repositories
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WingsOn API v1");
                c.RoutePrefix = "";
            });
        }
    }
}
