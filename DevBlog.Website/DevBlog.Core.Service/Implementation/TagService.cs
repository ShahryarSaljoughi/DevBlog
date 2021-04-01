using DevBlog.Core.Db;
using DevBlog.Core.Model.Entity;
using DevBlog.Core.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.Core.Service.Implementation
{
    public class TagService: ITagService
    {
        public async Task<List<Tag>> GetMatchingTags(string term)
        {
            await using var db = new SmDbContext();
            if (string.IsNullOrWhiteSpace(term))
            {
                return await db.Set<Tag>().Take(10).ToListAsync();
            }
            var result = db.Set<Tag>().Where(tag => tag.Title.Contains(term)).OrderBy(tag => tag.ArticleTags.Count).Skip(0).Take(10);
            return await result.ToListAsync();
        }

        public async Task<Tag> SaveTagAsync(string tagTitle)
        {
            var tag = new Tag() { Title = tagTitle };
            return await SaveTagAsync(tag);
        }

        public async Task<Tag> SaveTagAsync(Tag tag)
        {
            await using var db = new SmDbContext();
            db.Add(tag);
            await db.SaveChangesAsync();
            return tag;
        }
    }
}
