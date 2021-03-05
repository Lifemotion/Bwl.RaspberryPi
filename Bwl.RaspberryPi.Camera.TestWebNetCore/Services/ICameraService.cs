using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Services
{
    internal interface ICameraService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}
