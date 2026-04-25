
using Microsoft.EntityFrameworkCore;
using WebApi.Configuration;
using WebApi.Context;
using WebApi.DTOs;
using WebApi.Middleware;
using WebApi.Repositry;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddDbContext<ApiContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<Filters.HandelExpAttribute>();
            });
            builder.Services.AddScoped<Repositry.IRepositry<Models.Student>, Repositry.StudentRepositry>();
            builder.Services.AddScoped<IRepositry<DepartmentWithEmpsDTO>, Repositry.DepartmentDtoRepo>();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            MapsterConf.Register();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseHandelExpection();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/error")
                {
                    throw new Exception("This is a test exception.");
                }
                await next();
            });
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
