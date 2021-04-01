using DevBlog.Core.Model.Marker;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.Core.Model.Entity
{
    public class Article : Entity
    {
        public Article() : base() 
        {
            CreationDateTime = DateTimeOffset.Now;
            IsActive = true;
        }

        public virtual DateTimeOffset? CreationDateTime { get; set; }
        public virtual int? SeenCount { get; set; }
        public virtual bool? IsActive { get; set; }
        public virtual string ContentJson { get; set; }
        public virtual string ContentText { get; set; }
        public virtual string ContentHtml { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }
        
    }
}
