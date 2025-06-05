using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Api.Requests;
using QRCodeGenerator.Api.Response;

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

        [HttpGet("generate")]
        public ActionResult Generate(QRCodeGenerateRequest request)
        {
            var response = new QRCodeGeneratedResponse
            {
                Url = "teste.com"
            };

            return Ok(response);
        }
    }
}