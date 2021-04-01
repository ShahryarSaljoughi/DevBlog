using DevBlog.Core.Service.Contract;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DevBlog.Core.Service.Implementation
{
    public class TelegramChannelService : ITelegramChannelService
    {
        private readonly TelegramBotClient _client;
        private readonly ChatId _channelChatId;
        private const string botToken = "1262458283:AAGrSu4p82HPm8ILy1cXD1heeEjQwZ6U35g";
        private const string telegramProxyServer = "https://tcf.anydevelopercan.com/bot";

        public TelegramChannelService()
        {
            _client = new TelegramBotClient("1262458283:AAGrSu4p82HPm8ILy1cXD1heeEjQwZ6U35g");
            typeof(TelegramBotClient)
                    .GetField("_baseRequestUrl", BindingFlags.Instance | BindingFlags.NonPublic)
                    .SetValue(_client, $"{new Uri(new Uri(telegramProxyServer), "bot")}{botToken}/");

            _channelChatId = -1001470245362;
        }
        public async Task<Message> SendTextMessageAsync(string message)
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message));

            return await _client.SendTextMessageAsync(_channelChatId, message);
        }
    }
}
