using Application.Queries;
using Application.Services;
using Domain.Services;

namespace WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var allowUI = "_allowUI";

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<ILoggingService, LoggingService>();
            builder.Services.AddSingleton<ICalculatorService, CalculatorService>();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetEitherQuery).Assembly);
            });
            builder.Services.AddCors(cfg =>
            {
                cfg.AddPolicy(
                    name: allowUI,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:8080");
                    });
            });


            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(allowUI);
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}