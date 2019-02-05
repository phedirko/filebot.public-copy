using FileBot.Telegram.Lib.Configuration;
using FileBot.Telegram.Lib.Data.Persistance.Implementations;
using FileBot.Telegram.Lib.Data.Persistance.Interfaces;
using FileBot.Telegram.Lib.Handlers.Interfaces;
using FileBot.Telegram.Lib.Services.Application.Implementations;
using FileBot.Telegram.Lib.Services.Application.Interfaces;
using FileBot.Telegram.Lib.Services.Proxy.AWS.Implementations;
using FileBot.Telegram.Lib.Services.Proxy.AWS.Interfaces;
using FileBot.Telegram.Lib.Services.Proxy.Telegram.Implementations;
using FileBot.Telegram.Lib.Services.Proxy.Telegram.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FileBot.Telegram.Lib.Exteinsions.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHandler<T>(this IServiceCollection services) where T : class, ITelegramWebhookHandler
        {
            return services.AddScoped<ITelegramWebhookHandler, T>();
        }

        public static IServiceCollection AddMessageHandlers(this IServiceCollection services)
        {
            return services.AddScoped<IDocumentMessageHandler, DocumentMessageHandler>();
        }

        public static IServiceCollection AddTelegramClient(this IServiceCollection services)
        {


            return services.AddScoped<ITelegramClient, TelegramClient>();
        }

        public static IServiceCollection AddS3(this IServiceCollection services)
        {
            return services.AddScoped<IAmazonS3Proxy, AmazonS3Proxy>();
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            return services.AddScoped<IDocumentRepostiory, DocumentRepository>();
        }

        //todo: configure via env vars

        public static IServiceCollection Configure(this IServiceCollection services)
        {
            services.Configure<TelegramConfig>(c =>
            {
                c.MaxFileSizeKbs = 1024 * 20;
                c.Token = "";
            });

            return services.Configure<AWSS3Config>(c =>
            {
                c.AccessKey = "";
                c.SecretKey = "";
                c.FileBotBucket = "";
            });
        }
    }
}
