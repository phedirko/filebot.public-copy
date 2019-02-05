using System.IO;
using System.Threading.Tasks;

namespace FileBot.Telegram.Lib.Services.Proxy.Telegram.Interfaces
{
    public interface ITelegramClient
    {
        Task<Stream> FetchFile(string fileId);
    }
}
