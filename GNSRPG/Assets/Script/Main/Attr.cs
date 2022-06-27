using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hurt;
using UnityEngine;

namespace Main
{
    public class Attr
    {
        public int HP;
        public int PS;
        public int ATK;
        public float Crit;// 暴击率
        public float CritHit;//暴击伤害倍率
        public float SpeedMax;// 最大移动速度
        public float SpeedStart;// 起始移动速度
        public float SpeedA;// 移动加速度
        public float StopA;// 停止加速度
        public float JumpSpeed;// 跳跃速度
        public int JumpTimes;//跳跃次数
        public float Armor;// 护甲值
                           //public float Resistance(...);// 各种属性抗性值

        public float RepelTime;// 被击退时受控制的时间
        public float RepelSpeed;
        public float RepelPow;
        public Vector2 RepelFrom;
        public float InvincibleTime;// 无敌帧时间
        //public float RepelSpeed;//被击退的速度(取1倍移速）

        public float FallDown;// 倒地时间
        public int FallHit;// 倒地承受临界伤害值
        public float FallDur;// 计算承受伤害值持续时间
        public float ATI;// 普通攻击间隔
        public float SATI;// 特殊攻击间隔

        public int CurHP;// 当前生命值
        public int CurPS;// 当前精力值
        public float CurSpeed;// 当前速度

        public int PSRecover;//精力回复速度
        public float PSRI;//精力回复间隔
        public int HPRecover;//生命回复速度
        public float HPRI;//生命恢复间隔



        public Attr()
        {
            HP = 100;
            PS = 100;
            ATK = 0;
            Crit = 0;
            CritHit = 0;
            PSRI = 1;
            HPRI = 1;

            RepelTime = 0.5f;
            InvincibleTime = 4;

        }

        public void Init()
        {
            CurHP = HP;
            CurPS = PS;


        }

        public void CalculateDamage(List<HurtManager> hurtList)
        {
            int hurt = 0;
            foreach(HurtManager hM in hurtList)
            {
                switch(hM.HurtType)
                {
                    case HurtType.Cut:
                        hurt = (int)(hM.ATK - Armor);
                        CurHP -= hurt;
                        break;
                    case HurtType.Posion:
                        //TODO:后面补充buff
                        break;
                }
            }


        }


    }
}
