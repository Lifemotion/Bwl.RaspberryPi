using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Models
{
    public class Frame
    {
        public long Count { get; private set; }
        public string Value { get; private set; }

        public Frame()
        {
        }

        public Frame(long count, string value) : base()
        {
            Count = count;
            Value = value;
        }
    }
}
