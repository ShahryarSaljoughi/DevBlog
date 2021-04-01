using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace DevBlog.Core.Service.Contract
{
    public interface ITelegramChannelService
    {
        System.Threading.Tasks.Task<Message> SendTextMessageAsync(string message);
    }
}
