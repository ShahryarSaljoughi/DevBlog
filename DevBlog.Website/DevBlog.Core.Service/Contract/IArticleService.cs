using DevBlog.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Core.Service.Contract
{
    public interface IArticleService
    {
        Task<Article> GetArticle(Guid Id);
        Task<List<Article>> GetArticlesAsync();
        Task<List<Article>> GetArticlesAsync(int pageSize = 10, int pageNo = 1);
        Task PublishArticleOnTelegramChannel(Article article);
    }
}
