using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SayfamaHosgeldinAPI.Business.Abstract;
using SayfamaHosgeldinAPI.Business.Concrete;
using SayfamaHosgeldinAPI.Context;
using SayfamaHosgeldinAPI.Core.DataAccess;
using SayfamaHosgeldinAPI.Core.DataAccess.EntityFramework;

namespace SayfamaHosgeldinAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            

            var connectionString = Configuration.GetConnectionString("BloggingDatabase");
            services.AddDbContext<DbContext, InterviewContext>(options =>
            {
                options.UseSqlServer(connectionString);
               // options.EnableSensitiveDataLogging();
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserService, UserManager>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LoginRegister.WebAPI", Version = "v1" });
            });


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoginRegister.WebAPI V1"));
            }

            //   app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
