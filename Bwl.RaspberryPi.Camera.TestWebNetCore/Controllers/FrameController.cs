using Bwl.RaspberryPi.Camera.TestWebNetCore.Models;
using Bwl.RaspberryPi.Camera.TestWebNetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameController : ControllerBase
    {
        public readonly IFrameService _frameService;

        public FrameController(IFrameService frameService)
        {
            _frameService = frameService;
        }

        [HttpGet("{id}")]
        public ActionResult<Frame> Get(Guid id)
        {
            byte[] value = _frameService.GetFrame();
            if(value != null)
            {                
                return new Frame(_frameService.Count, Convert.ToBase64String(value));
            }
            return NoContent();
        }
    }
}
