
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

            // Configura��o do Swagger/OpenAPI para ajudar na documenta��o e teste da API.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configura��o da pipeline de requisi��es HTTP.
            if (app.Environment.IsDevelopment())
            {
                // Ativa o Swagger apenas em desenvolvimento para a documenta��o da API.
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Aplica redirecionamento HTTP para HTTPS automaticamente.
            app.UseHttpsRedirection();

            // Ativa o middleware de autoriza��o.
            app.UseAuthorization();

            // Mapeia os controladores para serem acess�veis como endpoints da API.
            app.MapControllers();

            // Inicia a aplica��o.
            app.Run();
        }
    }
}
