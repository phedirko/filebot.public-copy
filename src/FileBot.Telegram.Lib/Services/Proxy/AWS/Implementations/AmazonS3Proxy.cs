using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using FileBot.Telegram.Lib.Configuration;
using FileBot.Telegram.Lib.Services.Proxy.AWS.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileBot.Telegram.Lib.Services.Proxy.AWS.Implementations
{
    public class AmazonS3Proxy : IAmazonS3Proxy
    {
        private readonly AmazonS3Client _amazonS3Client;
        private readonly AWSS3Config _config;

        public AmazonS3Proxy(IOptions<AWSS3Config> options)
        {
            _config = options.Value;
            _amazonS3Client = new AmazonS3Client(_config.AccessKey, _config.SecretKey, RegionEndpoint.EUCentral1);
        }

        public async Task PutObject(Stream stream)
        {
            var request = new PutObjectRequest
            {
                BucketName = _config.FileBotBucket,
                InputStream = stream,
                Key = Guid.NewGuid().ToString() // pass as param
            };

            await _amazonS3Client.PutObjectAsync(request);
        }
    }
}
