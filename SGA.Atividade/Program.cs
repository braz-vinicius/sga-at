using Microsoft.EntityFrameworkCore;
using SGA.Atividade.Data;
using SGA.Atividade.IntegrationEvents;
using SGA.Atividade.Repositories;
using SGA.Atividade.Services;

namespace SGA.Atividade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHostedService<WorkerServiceBus>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DbContext, AtividadeDbContext>();

            builder.Services.AddTransient<IAtividadeRepository, AtividadeRepository>();
            builder.Services.AddTransient<IAtividadeService, AtividadeService>();

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