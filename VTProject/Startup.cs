using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VTProject.Models.DatabaseModels;
using VTProject.Models.DomainModels;
using VTProject.Services;
using VTProject.Services.Database;

namespace VTProject
{
    public class Startup
    {
        readonly string AllowedOrigins = "_allowedOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => 
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200");
                                  });
            });

            InitDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(AllowedOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<AutoMapper.IConfigurationProvider>(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketModel, Ticket>();
                cfg.CreateMap<Ticket, TicketModel>();

                cfg.CreateMap<PersonModel, Person>()
                .ForMember(dest => dest.Image,
                opt => opt.MapFrom(src => Convert.ToBase64String(src.Image)));
                cfg.CreateMap<Person, PersonModel>()
                .ForMember(dest => dest.Image,
                opt => opt.MapFrom(src => Convert.FromBase64String(src.Image)));
            }));
            services.AddSingleton<Mapper>();
            services.AddSingleton<TicketDatabaseService>();
            services.AddSingleton<PersonDatabaseService>();
            services.AddSingleton<DatabaseService>();
        }
    }
}
