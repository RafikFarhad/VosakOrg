using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VosakOrgRepositoryLayer;

namespace VosakOrgWeb
{
    public class DesignTimeVosakOrgDbContextFactory  : IDesignTimeDbContextFactory<VosakOrgDBContext>
    {
        public VosakOrgDBContext CreateDbContext(string[] args)
        {

            // Get environment
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<VosakOrgDBContext>();
            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));

            return new VosakOrgDBContext(optionsBuilder.Options);
        }
    }
}
