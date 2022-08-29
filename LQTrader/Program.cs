using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using LatamQuants.Entities;
using Microsoft.Extensions.Configuration;
using LatamQuants.Support;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using LQTrader.ModelViews;

namespace LQTrader
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            autoMapperConfigurations();
            loadConfiguration();
            setApplication();
            var log =configureLog();
            var services = configureServices();
            startApplication(services);
        }

        private static void startApplication(ServiceCollection services)
        {
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var frm = serviceProvider.GetRequiredService<TraderView>();
                Application.Run(frm);
            }
        }

        private static void setApplication()
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
        }

        private static void autoMapperConfigurations()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainProfile());

            });
            mappingConfig.AssertConfigurationIsValid();
            IMapper mapper = mappingConfig.CreateMapper();
            Service.mapper = mapper;
        }

        private static void loadConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            config.GetSection("AppSettings").Bind(AppSettings.Instance);
        }

        private static ILogger configureLog()
        {
            using var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            return log;
        }

        private static ServiceCollection configureServices()
        {
            var services = new ServiceCollection();
            //TODO: Implement LQPrimaryAPI future repository interfaces for Dependency Injection.
            services.AddScoped<TraderView>();
            return services;
        }
    }
}
