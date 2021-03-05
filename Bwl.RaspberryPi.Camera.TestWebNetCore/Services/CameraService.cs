using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Services
{
    internal class CameraService : ICameraService
    {
        #region Fields
        private readonly ILogger<CameraService> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IFrameService _frameService;

        private Thread _thread;
        #endregion

        #region Constructors
        public CameraService(ILogger<CameraService> logger, IMemoryCache memoryCache, IFrameService frameService)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _frameService = frameService;
        }
        #endregion

        #region ICameraService
        public async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Camera Service running.");

            _memoryCache.Set("_Time", DateTime.Now.ToString());

            //List<CameraParameters> list = new List<CameraParameters>
            //{
            //    new CameraParameters(),
            //    new CameraParameters(width: 1920, height: 1080, quality: 10, iso: 200),
            //    new CameraParameters(width: 640, height: 480, quality: 50, iso: 800),
            //    new CameraParameters(width: 1280, height: 720, quality: 25, iso: 100),
            //    new CameraParameters(width: 1024, height: 768, quality: 50, iso: 400),
            //};

            //int timeout = 10000;
            //using (_camera = new CameraMMAL())
            //{
            //    _camera.FrameReady += Camera_FrameReady;

            //    while (!stoppingToken.IsCancellationRequested)
            //    {
            //        int count;
            //        _memoryCache.TryGetValue("_Count", out count);
            //        count++;
            //        _memoryCache.Set("_Count", count, new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
            //        });
            //        _logger.LogInformation("Camera Service is working. Count: {Count}", count);

            //        CameraParameters cameraParameters = new CameraParameters(width: 1920, height: 1080, quality: 10);
            //        _camera.SetParameters(cameraParameters);
            //        try
            //        {
            //            _camera.Open();
            //        }
            //        catch (Exception ex)
            //        {
            //            _logger.LogInformation("Camera Service. Count: {Count}, {Exception}", count, ex.Message);
            //        }
            //        while (!_camera.IsOpen)
            //        {
            //            await Task.Delay(10, stoppingToken);
            //        }
            //        _logger.LogInformation("Camera Service. OPEN: {Count}", count);

            //        //await Task.Delay(timeout, stoppingToken);
            //        while (!stoppingToken.IsCancellationRequested)
            //        {
            //            var frame = _camera.TakeOrWaitFrame();
            //            if (frame != null)
            //            {
            //                _logger.LogInformation("Camera Service. TakeOrWaitFrame Count: " + _camera.FrameCount + " Length: " + frame.Buffer.Length + " DateTime: " + DateTime.Now.ToString("yyyy.MM.dd.hh:mm:ss.fff"));
            //            }
            //            else
            //            {
            //                _logger.LogInformation("Camera Service. TakeOrWaitFrame fail" + " DateTime: " + DateTime.Now.ToString("yyyy.MM.dd.hh:mm:ss.fff"));
            //                await Task.Delay(500, stoppingToken);
            //            }
            //        }

            //        _camera.Close();
            //        _logger.LogInformation("Camera Service. CLOSE: {Count}", count);
            //    }
            //}

            //var camera = new RpiCamMMAL();
            //camera.FrameReady += Camera_FrameReady;
            //camera.CameraParameters.Width = 640;
            //camera.CameraParameters.Height = 480;
            //camera.CameraParameters.FPS = 20;
            //camera.CameraParameters.Options = "";
            //camera.Open();

            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    _logger.LogInformation("Processing: " + camera.FrameCounter);
            //    await Task.Delay(1000, stoppingToken);
            //}
            //camera.Close();

            //_thread = new Thread(() =>
            //{
            //    _logger.LogInformation("Camera thread started");

            //    var camera = new RpiCamMMAL();
            //    camera.FrameReady += Camera_FrameReady;
            //    camera.CameraParameters.Width = 640;
            //    camera.CameraParameters.Height = 480;
            //    camera.CameraParameters.FPS = 20;
            //    camera.CameraParameters.Options = "";
            //    camera.Open();

            //    while (!stoppingToken.IsCancellationRequested)
            //    {
            //        _logger.LogInformation("Processing");
            //        var bytes = camera.CreateBytesCopy();
            //        if(bytes.Length > 0)
            //        {
            //            _logger.LogInformation($"Processing Length: {bytes.Length} Frames: {camera.FrameCounter}");
            //        }
            //        Thread.Sleep(500);                    
            //    }
            //    camera.Close();
            //    _logger.LogInformation("Camera thread stoped");
            //})
            //{
            //    IsBackground = true
            //};
            //_thread.Start();

            var camera = new RpiCamMMAL();
            camera.FrameReady += Camera_FrameReady;
            //camera.CameraParameters.Width = 640;
            //camera.CameraParameters.Height = 480;
            //camera.CameraParameters.FPS = 20;
            //camera.CameraParameters.Options = "";
            camera.Open();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Processing");
                await Task.Delay(1000, stoppingToken);
            }

            camera.Close();
        }

        private void Camera_FrameReady(IRpiCam source)
        {
            var camera = (RpiCamMMAL)source;

            //var fileName = DateTime.Now.ToString("yyyy_MM_dd_hhmmssfff") + "." + Enum.GetName(typeof(FrameType), e.Frame.Type);
            //File.WriteAllBytes("/home/pi/Camera/" + fileName, e.Frame.Buffer);
            long FrameCount = camera.FrameCounter;
            int FrameBytesLength = camera.FrameBytesLength;
            _logger.LogInformation("Frame saved Count: " + FrameCount + " Length: " + FrameBytesLength + " DateTime: " + DateTime.Now.ToString("yyyy.MM.dd.hh:mm:ss.fff"));
            //byte[] bytes;
            //_memoryCache.TryGetValue("_Bytes", out bytes);
            //bytes = camera.CreateBytesCopy();
            //_memoryCache.Set("_Bytes", camera.CreateBytesCopy(), new MemoryCacheEntryOptions
            //{
            //    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
            //});
            byte[] bytes = camera.CreateBytesCopy();
            _frameService.SetFrame(bytes);
        }
        #endregion
    }
}
