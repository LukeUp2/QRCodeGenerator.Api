using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using QRCodeGenerator.Api.Services;

namespace QRCodeGenerator.Api.Infrastructure
{
    public class S3StorageAdapter : IStorageService
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly string _bucketName;
        private readonly Amazon.RegionEndpoint region = Amazon.RegionEndpoint.USEast2;
        public S3StorageAdapter(string accessKey, string secretKey, string bucketName)
        {
            _amazonS3 = new AmazonS3Client(accessKey, secretKey, region);

            _bucketName = bucketName;
        }
        public async Task<string> UploadFile(Stream data, string fileName, string contentType)
        {
            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                InputStream = data,
                Key = "key",
                ContentType = contentType
            };

            await _amazonS3.PutObjectAsync(request);

            return $"https://{_bucketName}.s3.{region}.amazonaws.com/{fileName}";
        }
    }
}