using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Models
{
    public class Camera
    {
        #region Properties
        public Guid Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int FPS { get; set; }
        public int Quality { get; set; }
        public int BitRateMbps { get; set; }
        public int Shutter { get; set; }
        public int ISO { get; set; }
        public string Options { get; set; }
        #endregion

        #region Constructors
        public Camera()
        {
        }
        public Camera(Guid id, int width = 640, int height = 480, int fps = 30, int quality = 0, int bitRateMbps = 0, int shutter = 0, int iso = 0, string options = "")
            : base()
        {
            Id = id;
            Width = width;
            Height = height;
            FPS = fps;
            Quality = quality;
            BitRateMbps = bitRateMbps;
            Shutter = shutter;
            ISO = iso;
            Options = options;
        }
        #endregion
    }
}
