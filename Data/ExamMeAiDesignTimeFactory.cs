using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ExamMeAI.Data
{
    public class ExamMeAiDesignTimeFactory : IDesignTimeDbContextFactory<ExamMeAiContext>
    {
        public ExamMeAiContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            // adjust these keys to your project if you have a different name
            var connectionString = config.GetConnectionString("DefaultConnection")
                                   ?? config.GetConnectionString("ExamMeAiContext")
                                   ?? throw new InvalidOperationException("Connection string not found. Add 'DefaultConnection' or 'ExamMeAiContext' to appsettings.json.");

            var optionsBuilder = new DbContextOptionsBuilder<ExamMeAiContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ExamMeAiContext(optionsBuilder.Options);
        }
    }
}