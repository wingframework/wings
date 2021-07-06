using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wings.Examples.UseCase.Server.Seed;
using Wings.Framework.Ui.Core.Services;

namespace Wings.Examples.UseCase.Server
{

    public class Program
    {
        public static async Task Main(string[] args)
        {
         
            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //await InitSeedDb(services);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static async Task InitSeedDb(IServiceProvider services)
        {
            //var config = services.GetRequiredService<IConfiguration>();
            //if (config.GetValue<bool>("initDb"))
            //{
                try
                {
                    // ��ʼ��Ĭ�ϵĿ�������Դ
                    await SeedData.InitializeDefaultDeveloperResource(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            //}
        }
    }
}
