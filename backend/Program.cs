using backend.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Load environment variables
            DotNetEnv.Env.Load();

            var connectionString =
                $"Server={Environment.GetEnvironmentVariable("DB_HOST")};"
                + $"Port={Environment.GetEnvironmentVariable("DB_PORT")};"
                + $"Database={Environment.GetEnvironmentVariable("DB_NAME")};"
                + $"User={Environment.GetEnvironmentVariable("DB_USER")};"
                + $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};";

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
