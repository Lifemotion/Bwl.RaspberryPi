using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Services
{
    internal class CameraService : ICameraService
    {
        #region Fields
        private readonly ILogger<CameraService> _logger;
        private readonly IFrameService _frameService;

        private RpiCamMMAL _camera = new RpiCamMMAL();

        public Models.Camera Camera { get; private set; }

        private Models.Camera updateCamera { get; set; }
        private readonly object _lock = new object();
        #endregion

        #region Constructors
        public CameraService(ILogger<CameraService> logger, IFrameService frameService)
        {
            _logger = logger;
            _frameService = frameService;

            Camera = new Models.Camera(Guid.NewGuid());
        }
        #endregion

        #region ICameraService
        public async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Camera Service running.");

            _camera.FrameReady += Camera_FrameReady;
            _camera.CameraParameters.Width = Camera.Width;
            _camera.CameraParameters.Height = Camera.Height;
            _camera.CameraParameters.FPS = Camera.FPS;
            _camera.CameraParameters.Quality = Camera.Quality;
            _camera.CameraParameters.BitRateMbps = Camera.BitRateMbps;
            _camera.CameraParameters.Options = Camera.Options;
            _camera.CameraParameters.ISO = Camera.ISO;
            _camera.CameraParameters.Shutter = Camera.Shutter;
            _camera.Open();

            while (!stoppingToken.IsCancellationRequested)
            {
                lock (_lock)
                {
                    if (updateCamera != null)
                    {
                        _logger.LogInformation($"Parameters: {JsonSerializer.Serialize(updateCamera)}");

                        UpdateParameters(updateCamera.Width, updateCamera.Height, updateCamera.FPS, updateCamera.Quality, updateCamera.BitRateMbps, updateCamera.Shutter, updateCamera.ISO, updateCamera.Options);

                        updateCamera = null;
                    }
                }

                _logger.LogInformation("Processing");
                await Task.Delay(1000, stoppingToken);
            }

            _camera.Close();
        }

        private void Camera_FrameReady(IRpiCam source)
        {
            var camera = (RpiCamMMAL)source;

            byte[] bytes = camera.CreateBytesCopy();
            _frameService.SetFrame(bytes, camera.FrameCounter);
        }

        private void UpdateParameters(int width, int height, int fps, int quality, int bitRateMbps, int shutter, int iso, string options)
        {
            Camera.Width = width;
            Camera.Height = height;
            Camera.FPS = fps;
            Camera.Quality = quality;
            Camera.BitRateMbps = bitRateMbps;
            Camera.Shutter = shutter;
            Camera.ISO = iso;
            Camera.Options = options;

            if (_camera.CameraParameters.Width != Camera.Width
                || _camera.CameraParameters.Height != Camera.Height
                || _camera.CameraParameters.FPS != Camera.FPS
                || _camera.CameraParameters.Quality != Camera.Quality
                || _camera.CameraParameters.BitRateMbps != Camera.BitRateMbps
                || _camera.CameraParameters.Options != Camera.Options)
            {
                _camera.Close();

                Thread.Sleep(5000);

                _camera.CameraParameters.Width = Camera.Width;
                _camera.CameraParameters.Height = Camera.Height;
                _camera.CameraParameters.FPS = Camera.FPS;
                _camera.CameraParameters.Quality = Camera.Quality;
                _camera.CameraParameters.BitRateMbps = Camera.BitRateMbps;
                _camera.CameraParameters.Options = Camera.Options;
                _camera.CameraParameters.ISO = Camera.ISO;
                _camera.CameraParameters.Shutter = Camera.Shutter;

                _camera.Open();
            }
            else
            {
                _camera.CameraParameters.ISO = Camera.ISO;
                _camera.CameraParameters.Shutter = Camera.Shutter;
                _camera.Reconfigure();
            }
        }
        public void SetParameters(int width, int height, int fps, int quality, int bitRateMbps, int shutter, int iso, string options)
        {
            lock(_lock)
            {
                if(updateCamera == null)
                {
                    updateCamera = new Models.Camera(Camera.Id, width, height, fps, quality, bitRateMbps, shutter, iso, options);
                }
            }
        }

        #endregion
    }
}
