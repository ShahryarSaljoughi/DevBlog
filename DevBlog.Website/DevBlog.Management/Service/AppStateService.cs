using DevBlog.Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.Management.Service
{
    public static class AppStateService
    {
        private static Component? currentPage = null;
        public static Component CurrentPage
        {
            get
            {
                return currentPage ?? Component.Articles;
            }
            set
            {
                currentPage = value;
            }
        }

        public static Action OnStateChanged { get; set; }
    }
}
