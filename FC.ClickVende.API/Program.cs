
using FC.ClickVende.Business.Interfaces;
using FC.ClickVende.Business.Services;
using FC.ClickVende.Data.Interfaces;
using FC.ClickVende.Data.Repositories;

namespace FC.ClickVende.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //TODO - Retirar o Singleton, quando formos usar Database.
            builder.Services.AddSingleton<IClientService, ClientService>();
            builder.Services.AddSingleton<IClientRepository, ClientRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
