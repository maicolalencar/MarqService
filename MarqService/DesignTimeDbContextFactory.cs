using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MarqService.Data;

namespace MarqService
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MarqServiceContext>
    {
        public MarqServiceContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MarqServiceContext>();
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=MarqServiceContext-01e3afda-f6dd-460b-b72c-e5f0b51b8a6a;Trusted_Connection=True;MultipleActiveResultSets=true";//configuration.GetConnectionString("MarqServiceContext");
            builder.UseSqlServer(connectionString);
            return new MarqServiceContext(builder.Options);
        }
    }
}
