
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

            // Configuração do Swagger/OpenAPI para ajudar na documentação e teste da API.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configuração da pipeline de requisições HTTP.
            if (app.Environment.IsDevelopment())
            {
                // Ativa o Swagger apenas em desenvolvimento para a documentação da API.
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Aplica redirecionamento HTTP para HTTPS automaticamente.
            app.UseHttpsRedirection();

            // Ativa o middleware de autorização.
            app.UseAuthorization();

            // Mapeia os controladores para serem acessíveis como endpoints da API.
            app.MapControllers();

            // Inicia a aplicação.
            app.Run();
        }
    }
}
