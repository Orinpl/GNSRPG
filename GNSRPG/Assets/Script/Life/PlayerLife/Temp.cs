using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using Weapon;
using Hurt;

namespace PlayerLife
{
    public class Temp
    {
        public Attr AttrTest;

        public Cost BladeCost;
        public Cost BulletCost;
        public Cost RushCost;

        public HurtManager ATKD;
        public HurtManager SATKD;

        public Attr Slime;


        public Temp()
        {
            AttrTest = new Attr();
            AttrTest.SpeedMax = 8;
            AttrTest.SpeedStart = 6;
            AttrTest.SpeedA = 2f;
            AttrTest.CurSpeed = 0;
            AttrTest.StopA = 8;
            AttrTest.JumpSpeed = 8;
            AttrTest.JumpTimes = 2;
            AttrTest.PS = 100;
            AttrTest.HP = 100;
            AttrTest.PSRecover = 50;
            AttrTest.ATI = 0;

            Slime = new Attr();
            Slime.SpeedMax = 3;
            Slime.SpeedStart = 2;
            Slime.SpeedA = 1;
            Slime.CurSpeed = 0;
            Slime.PS = 100;
            Slime.HP = 100;
            Slime.PSRecover = 10;
            Slime.ATI = 2;
            Slime.SATI = 2;




            BladeCost = new Cost();
            BulletCost = new Cost();
            BladeCost.BulletNum = 0;
            BladeCost.PS = 10;
            BulletCost.PS = 50;
            BulletCost.BulletNum = 1;

            RushCost = new Cost();
            RushCost.PS = 10;

            ATKD = new HurtManager();
            ATKD.ATK = 10;
            ATKD.HurtType = HurtType.Cut;

            SATKD = new HurtManager();
            SATKD.ATK = ATKD.ATK * 4;
            SATKD.HurtType = HurtType.Cut;


        }


    }
}
