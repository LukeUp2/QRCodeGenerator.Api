using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Api.Requests;
using QRCodeGenerator.Api.Response;
using QRCodeGenerator.Api.UseCases.QRCode.Generate;

namespace QRCodeGenerator.Api.Controllers
{
    [ApiController]
    [Route("qrcode")]
    public class QRCodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Working :)");
        }

        [HttpPost("generate")]
        public async Task<ActionResult> Generate(QRCodeGenerateRequest request, [FromServices] GenerateQRCodeUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}