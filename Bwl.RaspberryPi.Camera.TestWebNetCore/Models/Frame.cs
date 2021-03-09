using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Models
{
    public class Frame
    {
        #region Properties
        public long Count { get; private set; }
        public string Value { get; private set; }
        #endregion

        #region Constructors
        public Frame()
        {
        }
        public Frame(long count, string value) : base()
        {
            Count = count;
            Value = value;
        }
        #endregion
    }
}
