using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Quarantine.Data
{
    public class QuarantineDbContextFactory: IDesignTimeDbContextFactory<QuarantineDbContext>
    {
        public QuarantineDbContext CreateDbContext(string[] args)
        {
            // var sharedPath = "/../Quarantine.Api/";
            
            var currentDirectory = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                // .AddJsonFile(currentDirectory + sharedPath + "appsettings.json", false)
                // .AddJsonFile(currentDirectory + sharedPath  + "appsettings.Development.json", false)
                .AddJsonFile(currentDirectory +  "/appsettings.json", false)
                .AddJsonFile(currentDirectory +  "/appsettings.Development.json", false)
                .AddEnvironmentVariables()
                .Build();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<QuarantineDbContext>();
            
            builder.UseMySql(connectionString, optionsBuilder =>
            {
                optionsBuilder.ServerVersion(new Version(10,5,1), ServerType.MariaDb);
            });

            return new QuarantineDbContext(builder.Options);
        }
    }
}