using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;

namespace Player
{
    public class Temp
    {
        public Attr AttrTest;

        public Temp()
        {
            AttrTest = new Attr();
            AttrTest.SpeedMax = 8;
            AttrTest.SpeedStart = 6;
            AttrTest.SpeedA = 2f;
            AttrTest.CurSpeed = 0;
            AttrTest.StopA = 8;
            AttrTest.JumpSpeed = 8;
            AttrTest.JumpTimes = 1;
        }


    }
}
