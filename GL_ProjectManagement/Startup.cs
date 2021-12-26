using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GL_ProjectManagement.DataAccess.EFCore;
using GL_ProjectManagement.DataAccess.EFCore.Repositories;

namespace GL_ProjectManagement
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
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName:"ProjMgmtDB"));

            //services.AddSingleton<IUserRepository, UserRepoImpl>();
            //services.AddSingleton<IUserRepository, UserRepoSqlEfImpl>();
            //services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            //services.AddScoped<IUserRepository, UserRepoSqlEfImpl>();
            // services.AddScoped<IProjectRepository, ProjectRepoSqlEfImpl>();
            services.AddScoped<UserRepository>();
            services.AddScoped<ProjectRepository>();
            services.AddScoped<TaskRepository>();
            //services.AddScoped<ITaskRepository, TaskRepoSqlEFImpl>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GL_ProjectManagement", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GL_ProjectManagement v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
