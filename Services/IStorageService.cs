using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCodeGenerator.Api.Services
{
    public interface IStorageService
    {
        public Task<string> UploadFile(Stream data, string fileName, string contentType);
    }
}