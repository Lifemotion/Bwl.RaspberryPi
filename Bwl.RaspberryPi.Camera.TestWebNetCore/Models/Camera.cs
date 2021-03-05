using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Models
{
    public class Camera
    {
        public Guid Id { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ISO { get; set; }

        public Camera()
        {
            Id = Guid.Empty;
        }

        public Camera(int width, int height, int iso):base()
        {
            Width = width;
            Height = height;
            ISO = iso;
        }
    }
}
