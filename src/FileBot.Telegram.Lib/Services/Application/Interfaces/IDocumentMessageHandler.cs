using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FileBot.Telegram.Lib.Services.Application.Interfaces
{
    public interface IDocumentMessageHandler
    {
        Task Handle(Message message);
    }
}
