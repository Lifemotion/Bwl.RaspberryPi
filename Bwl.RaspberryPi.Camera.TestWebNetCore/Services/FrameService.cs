using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Services
{
    public class FrameService : IFrameService
    {
        private readonly object _lock = new object();
        private long _count;
        private byte[] _bytes;

        public long Count {
            get
            {
                long count;
                lock(_lock)
                {
                    count = _count;
                }
                return count;
            }
        }

        public byte[] GetFrame()
        {
            byte[] bytes;
            lock (_lock)
            {
                bytes = _bytes;
            }
            return bytes;
        }

        public void SetFrame(byte[] value)
        {
            lock (_lock)
            {
                _bytes = value;
                _count++;
            }
        }
    }
}
