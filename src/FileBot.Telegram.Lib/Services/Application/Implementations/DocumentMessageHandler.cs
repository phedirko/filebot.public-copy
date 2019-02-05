using FileBot.Telegram.Lib.Configuration;
using FileBot.Telegram.Lib.Data.Persistance.Interfaces;
using FileBot.Telegram.Lib.Services.Application.Interfaces;
using FileBot.Telegram.Lib.Services.Proxy.AWS.Interfaces;
using FileBot.Telegram.Lib.Services.Proxy.Telegram.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FileBot.Telegram.Lib.Services.Application.Implementations
{
    public class DocumentMessageHandler : IDocumentMessageHandler
    {
        private readonly ITelegramClient _telegramClient;
        private readonly IAmazonS3Proxy _amazonS3Proxy;
        private readonly IDocumentRepostiory _documentRepostiory;
        private readonly TelegramConfig _telegramConfig;

        public DocumentMessageHandler(
            ITelegramClient telegramClient, 
            IAmazonS3Proxy amazonS3Proxy,
            IDocumentRepostiory documentRepostiory,
            IOptions<TelegramConfig> options)
        {
            _telegramClient = telegramClient;
            _amazonS3Proxy = amazonS3Proxy;
            _documentRepostiory = documentRepostiory;
            _telegramConfig = options.Value;
        }

        public async Task Handle(Message message)
        {
            var document = message.Document;

            //if (document.FileSize > _telegramConfig.MaxFileSizeKbs)
            //    throw new NotSupportedException($"Files bigger than {_telegramConfig.MaxFileSizeKbs} KBs not supported");

            Console.WriteLine($"Filesize: {document.FileSize}");

            var documentStream = await _telegramClient.FetchFile(message.Document.FileId);

            await _amazonS3Proxy.PutObject(documentStream);
            documentStream.Close();

            await _documentRepostiory.Add();
        }
    }
}
