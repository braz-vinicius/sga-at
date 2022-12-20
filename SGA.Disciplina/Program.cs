using Microsoft.EntityFrameworkCore;
using SGA.Disciplina.Data;
using SGA.Disciplina.Repositories;
using SGA.Disciplina.Services;

namespace SGA.Disciplina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DbContext, DisciplinaDbContext>();
            builder.Services.AddTransient<IDisciplinaRepository, DisciplinaRepository>();
            builder.Services.AddTransient<IDisciplinaService, DisciplinaService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}