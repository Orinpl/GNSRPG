using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using Weapon;

namespace Player
{
    public class Temp
    {
        public Attr AttrTest;

        public Cost BladeCost;
        public Cost BulletCost;
        public Cost RushCost;


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
            AttrTest.PS = 100;
            AttrTest.PSRecover = 50;
            AttrTest.ATI = 0;



            BladeCost = new Cost();
            BulletCost = new Cost();
            BladeCost.BulletNum = 0;
            BladeCost.PS = 10;
            BulletCost.PS = 50;
            BulletCost.BulletNum = 1;

            RushCost = new Cost();
            RushCost.PS = 10;






        }


    }
}
