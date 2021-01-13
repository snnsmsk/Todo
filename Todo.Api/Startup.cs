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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Api.Model;
using ToDo.Business.Service;
using ToDo.Data.DbContexts;
using ToDo.Data.Model;

namespace ToDo.Api
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
            services.AddCors();

            services.AddControllers();

            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(HttpGlobalExceptionFilter));
                config.EnableEndpointRouting = false;
            });

            var connectionString = Configuration["connectionStrings:todolistDBConnectionString"];

            services.AddDbContext<ToDoDbContext>(opt =>
                                               opt.UseSqlServer(connectionString));

            services.AddScoped<IToDoDbContext>(provider => provider.GetService<ToDoDbContext>());

            services.AddScoped<IToDoService, ToDoService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo { Title = "ToDoList API", Version = "V1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "ToDoList API V1");
            });
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DsToDo, ToDoDto>();
            CreateMap<ToDoDto, DsToDo>();
            CreateMap<ToDoCreateDto, DsToDo>();
            CreateMap<ToDoUpdateDto, DsToDo>();
        }
    }
}
