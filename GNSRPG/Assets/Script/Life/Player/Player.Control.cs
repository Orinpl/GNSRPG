using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Main;
using Life;
using System.Collections;

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
                if(Math.Abs(AttrCur.CurSpeed)<AttrCur.SpeedStart)
                {
                    AttrCur.CurSpeed = AttrCur.SpeedStart;
                }
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
                    ToStop();
                    LifeState = LifeState.Idle;
                }
            }
        }

        public void ToStop()
        {
            Stop();


        }

        public void Stop()
        {
            //RB2D.velocity = new Vector2(0, RB2D.velocity.y);
            AttrCur.CurSpeed = AttrCur.SpeedStart;
        }

        public void Jump()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(RemainJumpTimes>0)
                {
                    RB2D.velocity = new Vector2(RB2D.velocity.x, AttrCur.JumpSpeed);
                    StartCoroutine(ReduceJumpTime());
                }
            }
        }

        IEnumerator ReduceJumpTime()
        {

            yield return new WaitUntil(() => !IsGround);
            RemainJumpTimes--;

        }


        public void Attack()//普通攻击
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                if(CanATK&&LifeState!=LifeState.Freeze&&LifeState!=LifeState.Flying)
                {
                    LifeState = LifeState.Attack;
                    WeaponATK.Attack(this);

                }    
            }

        }




    }
}
