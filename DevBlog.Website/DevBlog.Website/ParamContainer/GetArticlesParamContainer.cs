using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.Website.ParamContainer
{
    public class GetArticlesParamContainer
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}
