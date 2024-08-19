using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Diagnostics;

namespace mMoser.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WebApiApplicationDbContext>
    {
        public WebApiApplicationDbContext CreateDbContext(string[] args)
        {
            string mainPath = Path.GetFullPath(Path.Combine(System.Environment.CurrentDirectory, @"..\"));
            string folderPath = @"mMoser.Web.NetCore\";
            var builder = new DbContextOptionsBuilder<WebApiApplicationDbContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(mainPath + folderPath)
            .AddJsonFile("appsettings.json")
            .Build();
            builder.UseSqlServer(configuration.GetConnectionString("mMoserDefaultConnection"));
            return new WebApiApplicationDbContext(builder.Options);
        }
    }
}
