using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Buff;
using Weapon;
using AI;
using Player;

namespace Life
{
    public partial class LifeBase
    {
        protected override void Start()
        {
            base.Start();
            Temp Temp = new Temp();
            AttrOri = Temp.AttrTest;
            AttrCur = AttrOri;
            LifeState = LifeState.Idle;

            RB2D = GetComponent<Rigidbody2D>();
            CD2D = GetComponent<Collider2D>();

            Ground = LayerMask.GetMask("Ground");
            RemainJumpTimes = AttrCur.JumpTimes;
            FootColl = Foot.GetComponent<Collider2D>();

            //Instantiate(WATK, this.transform.position, Quaternion.identity);
            //Instantiate(WSATK, this.transform.position, Quaternion.identity);
            WeaponATK = WATK.GetComponent<WeaponBase>();
            WeaponSpecial = WSATK.GetComponent<WeaponBase>();
            WATK.SetActive(false);
            WSATK.SetActive(false);

            //WeaponPosition = WeaponPoint.transform.position;
            CanATK = true;

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

            if(IsToStop)
            {
                if (AttrCur.CurSpeed > 0)
                {
                    AttrCur.CurSpeed -= AttrCur.StopA * Time.deltaTime;
                }
                else
                {
                    AttrCur.CurSpeed = 0;
                }
                int dir = RB2D.velocity.x >= 0 ? 1 : -1;
                RB2D.velocity = new Vector2(AttrCur.CurSpeed*dir, RB2D.velocity.y);
            }

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
                LifeState = LifeState.Flying;
            }

            if(LifeState==LifeState.Attack)
            {
                ATKCD -= Time.deltaTime;
                CanATK = false;
            }

            if (ATKCD <= 0)
            {
                if (LifeState == LifeState.Attack)
                {
                    LifeState = LifeState.Idle;
                }
                ATKCD = AttrCur.ATI;
                CanATK = true;
            }

        }



    }
}
