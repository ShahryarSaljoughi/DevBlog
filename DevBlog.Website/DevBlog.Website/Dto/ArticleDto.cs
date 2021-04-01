using DevBlog.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.Website.Dto
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset? CreationDateTime { get; set; }
        public virtual int? SeenCount { get; set; }
        public virtual bool? IsActive { get; set; }
        public virtual string ContentJson { get; set; }
        public virtual string ContentText { get; set; }
        public virtual string ContentHtml { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public ICollection<Tag> Tags { get; set; }
        
    }
}
