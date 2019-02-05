using System.Threading.Tasks;

using Amazon.Lambda.Core;
using FileBot.Telegram.Lib.Exteinsions.ServiceCollection;
using FileBot.Telegram.Lib.Handlers.Implementations;
using FileBot.Telegram.Lib.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Types;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace FileBot.Telegram.Lambda
{
    public class Function
    {
        private readonly ITelegramWebhookHandler _handler;
        private readonly IServiceCollection _services;

        public Function()
        {
            _services = new ServiceCollection()
                .AddHandler<TelegramWebhookHandler>()
                .AddS3()
                .AddMessageHandlers()
                .AddTelegramClient()
                .AddPersistance()
                .Configure();

            _handler = _services.BuildServiceProvider().GetRequiredService<ITelegramWebhookHandler>();
        }
        public async Task FunctionHandler(Input<Update> input, ILambdaContext context)
        {
            await _handler.Handle(input.Value);
        }
    }
}
