using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevBlog.Core.Db;
using DevBlog.Core.Model.Entity;
using DevBlog.Core.Service.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DevBlog.Website.ParamContainer;
using DevBlog.Website.Dto;
using DevBlog.Website.Service;

namespace DevBlog.Website.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IConfiguration Configuration { get; set; }
        private IArticleService ArticleService { get; set; }
        public ArticleController(IConfiguration configuration, IArticleService articleService)
        {
            ArticleService = articleService;
            Configuration = configuration;
        }

        [HttpPost]
        public async Task<List<ArticleDto>> GetArticles([FromBody] GetArticlesParamContainer paramContainer, CancellationToken cancellationToken)
        {
            var articles = await ArticleService.GetArticlesAsync(paramContainer.PageSize, paramContainer.PageNo);
            var dtos = from article in articles
                       select article.ToDto();

            foreach (var dto in dtos)
                foreach (var tag in dto.Tags)
                {
                    tag.Articles = null;
                    tag.ArticleTags = null;
                }
            return dtos.ToList();
        }

        [HttpGet]
        public async Task<ActionResult<ArticleDto>> GetArticle(Guid articleId, CancellationToken cancellation)
        {
            if (articleId == default)
                return BadRequest();
            var article = await ArticleService.GetArticle(articleId);
            if (article is null)
                return NotFound();
            var dto = article.ToDto();

            foreach (var tag in dto.Tags)
            {
                tag.Articles = null;
                tag.ArticleTags = null;
            }
            return article.ToDto();
        }
    }
}
