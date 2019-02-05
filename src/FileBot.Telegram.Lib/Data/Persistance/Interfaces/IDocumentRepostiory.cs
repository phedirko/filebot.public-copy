using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FileBot.Telegram.Lib.Data.Persistance.Interfaces
{
    public interface IDocumentRepostiory
    {
        Task<Document> Add();
    }
}
