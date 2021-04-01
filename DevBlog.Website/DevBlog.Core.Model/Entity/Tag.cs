using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.Core.Model.Entity
{
    public class Tag: Entity
    {
        public string Title { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
