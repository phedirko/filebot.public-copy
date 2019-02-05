using FileBot.Telegram.Lib.Handlers.Interfaces;
using FileBot.Telegram.Lib.Services.Application.Interfaces;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FileBot.Telegram.Lib.Handlers.Implementations
{
    public class TelegramWebhookHandler : ITelegramWebhookHandler
    {
        private readonly IDocumentMessageHandler _documentMessageHandler;

        public TelegramWebhookHandler(IDocumentMessageHandler documentMessageHandler)
        {
            _documentMessageHandler = documentMessageHandler;
        }

        public async Task Handle(Update update)
        {
            await _documentMessageHandler.Handle(update.Message);
        }
    }
}
