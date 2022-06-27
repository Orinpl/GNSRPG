using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Main;
using Life;
using PlayerLife;

namespace EnemyLife
{
    public class Enemy : LifeBase 
    {

        protected override void Start()
        {
            base.Start();
            AI.InitAI(this);

        }

        public override void InitTest()
        {
            Temp = new Temp();
            AttrOri = Temp.Slime;
            AttrCur = AttrOri;
            AttrCur.Init();
            AttrCur.RepelPow = RepelPow;
            AttrCur.RepelSpeed = RepelSpeed;
            AttrCur.RepelTime = RepelTime;
        }

        public override void NockBack(Vector2 from)
        {
            base.NockBack(from);
        }


    }
}
