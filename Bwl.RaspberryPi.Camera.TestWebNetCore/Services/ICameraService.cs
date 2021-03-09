using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Services
{
    public interface ICameraService
    {
        Models.Camera Camera { get;}
        Task DoWork(CancellationToken stoppingToken);
        void SetParameters(int width, int height, int fps, int quality, int bitRateMbps, int shutter, int iso, string options);
    }
}
