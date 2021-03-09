using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Services
{
    public class FrameService : IFrameService
    {
        #region Fields        
        private readonly object _lock = new object();
        private long _count;
        private byte[] _bytes;
        #endregion

        #region Properties        
        public long Count {
            get
            {
                lock(_lock)
                {
                    return _count;
                }
            }
        }
        #endregion

        #region Methods        
        public byte[] GetFrame()
        {
            lock (_lock)
            {
                return _bytes;
            }
        }
        public void SetFrame(byte[] value, long count)
        {
            lock (_lock)
            {
                _bytes = value;
                _count = count;
            }
        }
        #endregion
    }
}