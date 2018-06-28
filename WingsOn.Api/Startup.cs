using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register services
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IFlightsService, FlightsService>();

            // Register repositories
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();

            // Register mappers
            Mapper.Initialize(config => { config.CreateMap<Person, PersonDto>().ReverseMap(); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
