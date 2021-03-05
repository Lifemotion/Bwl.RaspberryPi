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
    public class CameraController : ControllerBase
    {
        public readonly ICameraService _cameraService;

        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet]
        public IEnumerable<Models.Camera> Get()
        {
            return new[] { _cameraService.Camera };
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Camera> Get(Guid id)
        {
            var item = _cameraService.Camera.Id == id ? _cameraService.Camera : null;
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid? id, Models.Camera camera)
        {
            if (id != camera.Id)
            {
                return BadRequest();
            }

            var item = _cameraService.Camera.Id == id ? _cameraService.Camera : null;
            if (item == null)
            {
                return NotFound();
            }

            _cameraService.SetParameters(camera.Width, camera.Height, camera.ISO);

            return NoContent();
        }
    }
}
