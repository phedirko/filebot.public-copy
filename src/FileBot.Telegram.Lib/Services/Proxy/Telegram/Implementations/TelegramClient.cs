using FileBot.Telegram.Lib.Configuration;
using FileBot.Telegram.Lib.Services.Proxy.Telegram.Interfaces;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;

namespace FileBot.Telegram.Lib.Services.Proxy.Telegram.Implementations
{
    public class TelegramClient : ITelegramClient
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly TelegramConfig _telegramConfig;

        public TelegramClient(IOptions<TelegramConfig> options)
        {
            _telegramConfig = options.Value;
            _telegramBotClient = new TelegramBotClient(_telegramConfig.Token);
        }

        public async Task<Stream> FetchFile(string fileId)
        {
            var ms = new MemoryStream();

            await _telegramBotClient.GetInfoAndDownloadFileAsync(fileId, ms);

            return ms;
        }
    }
}
