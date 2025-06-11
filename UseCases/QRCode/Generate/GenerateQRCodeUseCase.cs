using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRCoder;
using QRCodeGenerator.Api.Requests;
using QRCodeGenerator.Api.Response;
using QRCodeGenerator.Api.Services;

namespace QRCodeGenerator.Api.UseCases.QRCode.Generate
{
    public class GenerateQRCodeUseCase
    {
        private readonly IStorageService _storageService;

        public GenerateQRCodeUseCase(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<QRCodeGeneratedResponse> Execute(QRCodeGenerateRequest request)
        {
            var qrGenerator = new QRCoder.QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(request.Text, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var qrCode = new BitmapByteQRCode(qrCodeData);

            byte[] png = qrCode.GetGraphic(20);
            var streamedQRCode = new MemoryStream(png);
            var url = await _storageService.UploadFile(streamedQRCode, Guid.NewGuid().ToString(), "image/png");

            return new QRCodeGeneratedResponse
            {
                Url = url,
            };
        }
    }
}