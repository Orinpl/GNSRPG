using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Buff;
using Weapon;
using AI;

namespace Life
{
    public partial class LifeBase:Base
    {
        private void FixedUpdate()
        {
            if (IsMove)
            {
                if (AttrCur.CurSpeed < AttrCur.SpeedMax)
                {
                    AttrCur.CurSpeed += AttrCur.SpeedA * Time.deltaTime;
                }
            }
        }



    }
}
