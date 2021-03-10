using Bwl.RaspberryPi.Camera.TestWebNetCore.Models;
using Bwl.RaspberryPi.Camera.TestWebNetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Controllers
{
    [ApiController]
    public class FrameController : ControllerBase
    {
        public readonly IFrameService _frameService;

        public FrameController(IFrameService frameService)
        {
            _frameService = frameService;
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult<Frame> Get(Guid id)
        {
            byte[] value = _frameService.GetFrame();
            if (value != null)
            {
                return new Frame(_frameService.Count, value);
            }
            return NoContent();
        }

        [HttpGet()]
        [ActionName("Image")]
        [Route("api/[controller]/[action]")]
        public IActionResult GetImage()
        {
            byte[] value = _frameService.GetFrame();
            if (value != null)
            {
                return new FileContentResult(value, "image/jpeg");
            }
            return NoContent();
        }

    }
}
