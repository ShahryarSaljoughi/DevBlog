using DevBlog.Core.Model.Entity;
using DevBlog.Website.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DevBlog.Website.Service
{
    public static class DtoEntityMapper
    {
        public static ArticleDto ToDto(this Article article)
        {
            return new ArticleDto()
            {
                ContentHtml = article.ContentHtml,
                ContentJson = article.ContentJson,
                ContentText = article.ContentText,
                CreationDateTime = article.CreationDateTime,
                Description = article.Description,
                Id = article.Id,
                IsActive = article.IsActive,
                SeenCount = article.SeenCount,
                Tags = article.ArticleTags.Select(at => at.Tag).ToList(),
                Title = article.Title
            };
        }
    }
}
