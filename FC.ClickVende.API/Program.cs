namespace FC.ClickVende.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona os controladores ao container de serviços.
            builder.Services.AddControllers();

            // Configuração do Swagger/OpenAPI para ajudar na documentação e teste da API.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registro dos serviços e repositórios com injeção de dependência.
            // ClientService é registrado como Scoped, o que significa que uma instância será criada por requisição.
            builder.Services.AddScoped<IClientService, ClientService>();
            // ClientRepository é registrado como Scoped pelo mesmo motivo.
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

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
