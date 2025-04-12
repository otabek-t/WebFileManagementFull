
using Microsoft.AspNetCore.Http.Features;
using System.Threading.RateLimiting;
using WebFileManagement.Service.Services;
using WebFileManagement.StorageBroker.Services;

namespace WebFileManagement.Server
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

            builder.Services.AddScoped<IStorageService, StorageService>();
            builder.Services.AddSingleton<IStorageBrokerService, LocalStorageBrokerService>();
            //builder.Services.AddSingleton<IStorageBrokerService, AwsStorageService>();
            //builder.Services.AddSingleton<IStorageService, StorageService>();
            //builder.Services.AddTransient<IStorageService, StorageService>();

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Limits.MaxRequestBodySize = long.MaxValue;
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = 5242880000 * 3;
            });

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
