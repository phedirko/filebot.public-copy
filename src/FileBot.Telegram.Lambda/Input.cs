using Newtonsoft.Json;

namespace FileBot.Telegram.Lambda
{
    public class Input<T>
    {
        [JsonIgnore]
        public T Value => JsonConvert.DeserializeObject<T>(Body, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
