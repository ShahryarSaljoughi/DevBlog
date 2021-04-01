using DevBlog.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Core.Service.Contract
{
    public interface ITagService
    {
        Task<List<Tag>> GetMatchingTags(string term);
        Task<Tag> SaveTagAsync(string tagTitle);
        Task<Tag> SaveTagAsync(Tag tag);
    }
}
