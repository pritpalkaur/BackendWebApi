using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
//using mMoser.Domin.Models;
using System.Diagnostics;

namespace mMoser.Exceptions.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<mMoserExceptionDbContext>
    {
        public mMoserExceptionDbContext CreateDbContext(string[] args)
        {
            string mainPath = Path.GetFullPath(Path.Combine(System.Environment.CurrentDirectory, @"..\"));
            string folderPath = @"mMoser.Web.NetCore\";
            var builder = new DbContextOptionsBuilder<mMoserExceptionDbContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(mainPath + folderPath)
            .AddJsonFile("appsettings.json")
            .Build();
            builder.UseSqlServer(configuration.GetConnectionString("mMoserDefaultConnection"));
            return new mMoserExceptionDbContext(builder.Options);
        }
    }
}