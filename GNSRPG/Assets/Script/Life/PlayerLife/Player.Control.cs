using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Main;
using Life;
using Weapon;
using System.Collections;

namespace PlayerLife
{
    public partial class Player:LifeBase
    {
        public void Move()
        {
            bool flag = true;
            if (Input.GetKeyDown(KeyCode.D)|| (Input.GetKeyUp(KeyCode.A) && Input.GetKey(KeyCode.D)))
            {
                Forward = new Vector3(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyUp(KeyCode.D) && Input.GetKey(KeyCode.A)))
            {
                Forward = new Vector3(-1, 0, 0);
            }

            if ((Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A))
                &&LifeState!=LifeState.Freeze&&LifeState!=LifeState.Rush)
            {
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
                RB2D.velocity = new Vector2(Forward.x * AttrCur.CurSpeed, RB2D.velocity.y);

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
            IsToStop = true;
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
                if(CanATK&&LifeState!=LifeState.Freeze)
                {
                    if (WeaponATK.Attack(this))
                    {
                        LifeState = LifeState.Attack;
                    }
                }    
            }

        }

        public void SAttack()//特殊攻击
        {
            if(Input.GetKeyDown(KeyCode.U))
            {
                if(CanSATK && LifeState != LifeState.Freeze)
                {
                    if (WeaponSpecial.Attack(this))
                    {
                        LifeState = LifeState.SpecialAttack;
                    }
                }
            }

        }

        public override void NockBack()
        {

        }

        //Vector2 rushTarget;
        //Vector2 rushStart;
        //float rushSpeed;
        public bool IsRushing;
        public Cost RushCost;
        public void Rush()//冲刺
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if(LifeState!=LifeState.Rush)
                {
                    LifeState = LifeState.Rush;
                    RushTimeCounter = RushTime;
                }
                //rushTarget = transform.position + new Vector3(Forward.x * RushRange, 0, 0);
                //rushStart = transform.position;
                //rushSpeed = AttrCur.CurSpeed * RushPower;

                if (AttrCur.CurPS >= RushCost.PS)
                {
                    PSCost(RushCost.PS);
                    IsRushing = true;
                }
            }
        }

        IEnumerator ResetRush()
        {
            yield return new WaitUntil(() => IsGround);
            RushNumCounter = RushNum;
        }

    }
}
