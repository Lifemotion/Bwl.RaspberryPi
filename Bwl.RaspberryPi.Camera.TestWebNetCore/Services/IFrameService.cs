using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Services
{
    public interface IFrameService
    {
        long Count { get; }
        void SetFrame(byte[] value, long count);
        byte[] GetFrame();
    }
}
