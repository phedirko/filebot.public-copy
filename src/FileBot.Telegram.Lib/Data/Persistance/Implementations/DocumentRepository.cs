using FileBot.Telegram.Lib.Data.Persistance.Interfaces;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FileBot.Telegram.Lib.Data.Persistance.Implementations
{
    public class DocumentRepository : IDocumentRepostiory
    {
        public Task<Document> Add()
        {
            Console.WriteLine("Added new doc");

            return Task.FromResult(new Document());
        }
    }
}
