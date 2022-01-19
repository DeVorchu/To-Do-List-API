using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoApp.Models.Domains;
using MySql.Data.MySqlClient;
using MySql.EntityFrameworkCore.Extensions;

using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000",
                                                          "http://localhost:3001")
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod()
                                                    .AllowCredentials(); 
                                  });
            });


            services.AddScoped<UnitOfWork, UnitOfWork>();


            services.AddDbContext<db_e337Context>(options =>
            options.UseMySQL(Configuration.GetConnectionString("db_e337Context")));



            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                .RequireCors(MyAllowSpecificOrigins); 
            });

            app.UseCors(options =>
                options.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
        }
    }
}
