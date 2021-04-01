using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DevBlog.Shared.Utils
{
    public static class DateUtil
    {
        public static string Prettify(this DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset is null)
                return string.Empty;
            return dateTimeOffset.Value.ToString("D");
        }
    }
}
