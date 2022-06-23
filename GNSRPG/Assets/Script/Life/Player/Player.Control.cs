using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Main;
using Life;

namespace Player
{
    public partial class Player:LifeBase
    {
        public void Move()
        {
            bool flag = true;
            int dir = 1;
            if(Input.GetKey(KeyCode.D))
            {
                dir = 1;
                flag = true;
            }
            else if(Input.GetKey(KeyCode.A))
            {
                dir = -1;
                flag = true;
            }
            else
            {
                flag = false;
            }

            if (flag)
            {
                transform.localScale = new Vector3(dir, 1, 1);
                RB2D.velocity = new Vector2(dir * AttrCur.CurSpeed, RB2D.velocity.y);

                IsMove = true;
                if (LifeState == LifeState.Idle)
                {
                    LifeState = LifeState.Move;
                }
            }
            else
            {
                IsMove = false;
                if (LifeState == LifeState.Move)
                {
                    Stop();
                    LifeState = LifeState.Idle;
                }
            }
        }

        public void Stop()
        {
            RB2D.velocity = new Vector2(0, RB2D.velocity.y);
        }


    }
}
