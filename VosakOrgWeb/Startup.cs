using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VosakOrgWeb.Extensions;
using VosakOrgRepositoryLayer;
using VosakOrgRepositoryLayer.Seeder;
using VosakOrgServiceLayer;
using VosakOrgWeb.Middleware;

namespace VosakOrgWeb
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
            // Route and Controller
            services.AddControllers(options =>
            {
                options.UseGeneralRoutePrefix("api/v{version:apiVersion}");
            });

            services.AddApiVersioning(options => options.ReportApiVersions = true);

            // MySql
            services.AddDbContextPool<VosakOrgDBContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IPostService, PostService>();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "VosakOrg API",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafik Farhad",
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.RegisterCustomMiddlewares();
            if (env.IsDevelopment())
            {
                // Swagger
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Version: V1");
                });

                // app.UseDeveloperExceptionPage();
            }

            if (Configuration.GetValue<bool>("DbSeed"))
            {
                using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                using var context = serviceScope.ServiceProvider.GetService<VosakOrgDBContext>();
                new TestSeeder(context);
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
