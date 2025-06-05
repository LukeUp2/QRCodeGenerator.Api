using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QRCodeGenerator.Api.Infrastructure;
using QRCodeGenerator.Api.Services;
using QRCodeGenerator.Api.UseCases.QRCode.Generate;

namespace QRCodeGenerator.Api
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddUseCases(services);
            AddS3Storage(services, configuration);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<GenerateQRCodeUseCase>();
        }

        private static void AddS3Storage(IServiceCollection services, IConfiguration configuration)
        {
            var accessKey = configuration.GetValue<string>("Settings:S3:accessKey");
            var secretKey = configuration.GetValue<string>("Settings:S3:secretKey");
            var bucketName = configuration.GetValue<string>("Settings:S3:bucketName");

            services.AddScoped<IStorageService>(opt => new S3StorageAdapter(accessKey!, secretKey!, bucketName!));
        }
    }
}