﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using Life;
using UnityEngine;

namespace Player
{
    public partial class Player:LifeBase
    {
        public float Speed;
        public int PS;
        public int RushNum;//冲刺次数
        int RushNumCounter;
        public float RushPower;//冲刺速度倍率（相较于移动速度）
        public float RushTime;//冲刺时间

        float RushTimeCounter;

        protected override void Start()
        {
            base.Start();
            RushNumCounter = RushNum;
            RushCost = Temp.RushCost;
        }

        protected override void Update()
        {
            base.Update();
            Speed = AttrCur.CurSpeed;
            PS = AttrCur.CurPS;
            Move();
            Jump();
            Attack();
            SAttack();
            Rush();

            if(IsGround)
            {
                RushNumCounter = RushNum;
            }

            if (IsRushing)
            {
                //    transform.position = Vector2.Lerp(transform.position, rushTarget, rushSpeed*Time.deltaTime);
                //    if(Math.Abs(rushStart.x-rushTarget.x)<0.5f)
                //    {
                //        IsRushing = false;
                //        if(LifeState==LifeState.Rush)
                //        {
                //            LifeState = LifeState.Idle;
                //        }
                //    }
                if(RushTimeCounter>0)
                {
                    if(IsGround)
                    {
                        RB2D.velocity = new Vector2(AttrCur.SpeedMax * RushPower * Forward.x, 0);
                    }
                    else if(RushNumCounter>0)
                    {
                        RushNumCounter--;
                        RB2D.velocity = new Vector2(AttrCur.SpeedMax * RushPower * Forward.x, RB2D.velocity.y);

                    }
                    RushTimeCounter -= Time.deltaTime;
                }
                else
                {
                    RB2D.velocity= new Vector2(AttrCur.CurSpeed*Forward.x, RB2D.velocity.y);
                    IsRushing = false;
                    StartCoroutine(ResetRush());
                    if (LifeState == LifeState.Rush)
                    {
                        LifeState = LifeState.Idle;
                    }
                }


            }

        }


    }
}
