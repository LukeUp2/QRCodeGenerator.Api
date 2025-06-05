using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCodeGenerator.Api.Requests
{
    public class QRCodeGenerateRequest
    {
        public string Text { get; set; } = "";
    }
}