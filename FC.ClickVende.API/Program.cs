namespace FC.ClickVende.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona os controladores ao container de servi�os.
            builder.Services.AddControllers();

            // Configura��o do Swagger/OpenAPI para ajudar na documenta��o e teste da API.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registro dos servi�os e reposit�rios com inje��o de depend�ncia.
            // ClientService � registrado como Scoped, o que significa que uma inst�ncia ser� criada por requisi��o.
            builder.Services.AddScoped<IClientService, ClientService>();
            // ClientRepository � registrado como Scoped pelo mesmo motivo.
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

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
