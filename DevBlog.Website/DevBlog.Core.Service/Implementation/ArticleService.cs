using DevBlog.Core.Db;
using DevBlog.Core.Model.Entity;
using DevBlog.Core.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DevBlog.Shared.Utils.ConfigurationManager;
using Microsoft.Extensions.Configuration;

namespace DevBlog.Core.Service.Implementation
{
    public class ArticleService : IArticleService
    {
        public ITelegramChannelService ChannelService { get; set; }
        public ArticleService(ITelegramChannelService channel)
        {
            ChannelService = channel;
        }
        public async Task<List<Article>> GetArticlesAsync()
        {
            await using var db = new SmDbContext();
            var articles =
                from article in db.Set<Article>()
                select article;
            var result = await articles.ToListAsync(); 
            return result;
        }

        public async Task<List<Article>> GetArticlesAsync(int pageSize = 10, int pageNo = 1)
        {
            await using var db = new SmDbContext();
            var articles =
                from article in db.Set<Article>()
                orderby article.CreationDateTime descending
                select article;
            var result = await articles.Include(a => a.ArticleTags).ThenInclude(at => at.Tag).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
            return result;
            
        }

        public async Task<Article> GetArticle(Guid Id)
        {
            await using var db = new SmDbContext();
            var result = await db.Set<Article>().Include(a => a.ArticleTags).ThenInclude(at => at.Tag).FirstOrDefaultAsync(article => article.Id == Id);
            return result;
        }

        public async Task PublishArticleOnTelegramChannel(Article article)
        {
            var blogAddress = ConfigurationAccessor.AppConfig.GetValue<string>("BlogAddress");
            var message = $@"
📄 New Article Just Published
📍Title = {article.Title}
📗 {article.Description}
🔗 link = {blogAddress}/articles/{article?.Id}
⏰ <date time>

_____
🖍 subscribe this channel to get updated whenever articles get published on shahryarslg.irs
";
            await ChannelService.SendTextMessageAsync(message);
        }
    }
}
