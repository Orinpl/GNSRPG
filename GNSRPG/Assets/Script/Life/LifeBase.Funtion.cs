using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Buff;
using Weapon;
using AI;
using Hurt;
using PlayerLife;

namespace Life
{
    public partial class LifeBase
    {
        protected Temp Temp;
        protected override void Start()
        {
            base.Start();
            LifeState = LifeState.Idle;
            InitTest();

            RB2D = GetComponent<Rigidbody2D>();
            CD2D = GetComponent<Collider2D>();

            Ground = LayerMask.GetMask("Ground");
            FootColl = Foot.GetComponent<Collider2D>();

            //Instantiate(WATK, this.transform.position, Quaternion.identity);
            //Instantiate(WSATK, this.transform.position, Quaternion.identity);
            WeaponATK = WATK.GetComponent<WeaponBase>();
            WeaponSpecial = WSATK.GetComponent<WeaponBase>();
            WeaponATK.SetCost(Temp.BladeCost);
            WeaponSpecial.SetCost(Temp.BulletCost);
            WATK.SetActive(false);
            WSATK.SetActive(false);

            //WeaponPosition = WeaponPoint.transform.position;
            CanATK = true;
            Forward = new Vector3(1, 0, 0);

            IsToStop = false;
        }

        public virtual void InitTest()
        {
            Temp = new Temp();
            AttrOri = Temp.AttrTest;
            AttrCur = AttrOri;
            AttrCur.Init();
            RemainJumpTimes = AttrCur.JumpTimes;
        }




        protected void FixedUpdate()
        {

            if (IsMove)
            {
                if (AttrCur.CurSpeed < AttrCur.SpeedMax)
                {
                    AttrCur.CurSpeed += AttrCur.SpeedA * Time.deltaTime;
                }
                else if(AttrCur.CurSpeed>=AttrCur.SpeedMax)
                {
                    AttrCur.CurSpeed = AttrCur.SpeedMax;
                }
            }

            //if(IsToStop)
            //{
            //    if (AttrCur.CurSpeed > 0)
            //    {
            //        AttrCur.CurSpeed -= AttrCur.StopA * Time.deltaTime;
            //    }
            //    else
            //    {
            //        AttrCur.CurSpeed = 0;
            //        IsToStop = false;
            //    }
            //    RB2D.velocity = new Vector2(AttrCur.CurSpeed*Forward.x, RB2D.velocity.y);
            //}

            if(FootColl.IsTouchingLayers(Ground))
            {
                IsGround = true;
                if (LifeState == LifeState.Flying)
                {
                    LifeState = LifeState.Idle;
                }
                RemainJumpTimes = AttrCur.JumpTimes;
            }
            else
            {
                IsGround = false;
                if(LifeState!=LifeState.Attack&&LifeState!=LifeState.Freeze&&LifeState!=LifeState.Rush
                    &&LifeState!=LifeState.SpecialAttack)
                {
                    LifeState = LifeState.Flying;
                }
                
            }

            if(LifeState==LifeState.Attack)
            {
                ATKCD -= Time.deltaTime;
                CanATK = false;
            }
            if (LifeState == LifeState.SpecialAttack)
            {
                SATKCD -= Time.deltaTime;
                CanSATK = false;
            }

            if (ATKCD <= 0 && SATKCD <= 0) 
            {
                if (LifeState == LifeState.Attack && ATKCD <= 0)
                {
                    LifeState = LifeState.Idle;
                }
                else if(LifeState==LifeState.SpecialAttack && SATKCD <= 0)
                {
                    LifeState = LifeState.Idle;
                }
                ATKCD = AttrCur.ATI;
                CanATK = true;

                SATKCD = AttrCur.SATI;
                CanSATK = true;

            }

            

        }

        protected virtual void Update()
        {
            transform.right = Forward;
            if (PSRCD<=0)
            {
                PSRecover();
                PSRCD = AttrCur.PSRI;
            }
            else
            {
                PSRCD -= Time.deltaTime;

            }

            if (LifeState == LifeState.Freeze)
            {
                if (FreezeCounter > 0)
                {
                    RB2D.velocity = AttrCur.RepelFrom.normalized * AttrCur.SpeedMax * 2;
                    FreezeCounter -= Time.deltaTime;
                    ATKCD = AttrCur.ATI;
                    SATKCD = AttrCur.SATI;
                }
                else
                {
                    LifeState = LifeState.Idle;
                }

            }
        }

        public void GetHurt(List<HurtManager> hurtList,Vector2 from)//结算伤害
        {
            AttrCur.CalculateDamage(hurtList);
            NockBack(from);

        }

        public virtual void NockBack(Vector2 from)//被击退,from为子弹的方向
        {
            if(LifeState!=LifeState.Invincible)
            {
                AttrCur.RepelFrom = from;
                FreezeCounter = AttrCur.RepelTime;
                LifeState = LifeState.Freeze;


            }




        }

        public void FallDown()//倒地
        {

        }

        public void PSCost(int num)//体力消耗
        {
            AttrCur.CurPS -= num;
        }

        public void SetPSRecover(int num)//体力恢复
        {
            AttrCur.PSRecover = num;

        }

        public virtual void PSRecover()//体力恢复
        {
            AttrCur.CurPS += AttrCur.PSRecover;
            if(AttrCur.CurPS>AttrCur.PS)
            {
                AttrCur.CurPS = AttrCur.PS;
            }
        }

    }
}
