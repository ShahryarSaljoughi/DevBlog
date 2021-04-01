using Autofac;
using Autofac.Extensions.DependencyInjection;
using DevBlog.Shared.Utils.ConfigurationManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DevBlog.Core.Db
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            
            RegisterConfiguration(containerBuilder);
            containerBuilder.RegisterType<SmDbContext>();
            var resolver = containerBuilder.Build();
            
            await using var db = resolver.Resolve<SmDbContext>();
            await db.Database.MigrateAsync();
        }

        private static void RegisterConfiguration(ContainerBuilder containerBuilder)
        {
            IConfiguration configuration = ConfigurationAccessor.AppConfig;
            containerBuilder.RegisterInstance<IConfiguration>(configuration).SingleInstance();
        }
    }
}
