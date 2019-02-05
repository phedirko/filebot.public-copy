using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FileBot.Telegram.Lib.Handlers.Interfaces
{
    public interface ITelegramWebhookHandler
    {
        Task Handle(Update input);
    }
}
