using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WingsOn.Domain;
using WingsOn.Domain.Dto;

namespace WingsOn.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Register mappers
            Mapper.Initialize(config => { config.CreateMap<Person, PersonDto>().ReverseMap(); });

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
