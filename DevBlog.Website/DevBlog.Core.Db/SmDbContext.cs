using DevBlog.Core.Model.Marker;
using DevBlog.Shared.Utils.ConfigurationManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBlog.Core.Db
{
    public class SmDbContext : DbContext
    {

        public SmDbContext() : base(
            new DbContextOptionsBuilder<SmDbContext>()
               .UseNpgsql(ConfigurationAccessor.AppConfig.GetValue<string>("ConnectionString"))
               .UseSnakeCaseNamingConvention().Options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var types = typeof(IEntity).Assembly.GetExportedTypes()
                .Where(t => t.GetInterface(typeof(IEntity).FullName) != null && !t.IsAbstract);
            foreach (var type in types)
            {
                modelBuilder.Entity(type); // include typ in model
            }
        }
    }
}

