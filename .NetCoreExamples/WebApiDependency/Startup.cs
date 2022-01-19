using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using WebApiDependency.Data;
using WebApiDependency.Repositories;

namespace WebApiDependency
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
           // services.AddTransient(typeof(IUserRepository), typeof(UserSqlRepository));
           
           // services.AddTransient<IUserRepository>(c => new Repositories.UserSqlRepository(Configuration.GetConnectionString("AccountUserDb")));
            // services.AddTransient(typeof(IUserRepository), typeof(UserORMRepository));
            // services.AddSingleton(typeof(IUserRepository), typeof(UserORMRepository));
             services.AddScoped(typeof(IUserRepository), typeof(UserORMRepository));
                        
           services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AccountUserDb")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            //     app.UseSwagger();
            //     app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiDependency v1"));
            // }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
