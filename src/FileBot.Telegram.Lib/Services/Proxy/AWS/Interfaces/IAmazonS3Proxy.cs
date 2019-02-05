using System.IO;
using System.Threading.Tasks;

namespace FileBot.Telegram.Lib.Services.Proxy.AWS.Interfaces
{
    public interface IAmazonS3Proxy
    {
        Task PutObject(Stream stream);
    }
}
