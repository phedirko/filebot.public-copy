using System;

namespace FileBot.Telegram.Lib.Data.Models
{
    public class Document
    {
        public Guid Id { get; set; }

        public DateTime UploadedOnUtc { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FileKey { get; set; }

        public string SecretKey { get; set; }
    }
}
