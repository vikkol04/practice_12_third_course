using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserApi.Data;

namespace ConsoleApp1
{
    public class Kolokolnikov_var_4
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddDbContext<UsersContext>(opt => opt.UseInMemoryDatabase("UsersList"));

            // Configuring Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "User API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}