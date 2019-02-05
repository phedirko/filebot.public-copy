using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Xunit;

namespace FileBot.Telegram.Lambda.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var func = new Function();

            var input = new Input<Update>();
            input.Body = JsonConvert.SerializeObject(new Update());

            await func.FunctionHandler(input, null);
        }
    }
}
