using System;
using System.Collections.Generic;
using System.Text;
using DevBlog.Core.Service.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace DevBlog.Core.Service.Implementation
{
    public static class DependencyUtils
    {
        public static void RegisterCommonDependencies(this IServiceCollection services)
        {
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ITelegramChannelService, TelegramChannelService>();
        }
    }
}
