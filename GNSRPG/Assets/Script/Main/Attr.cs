using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Attr
    {
        public int HP;
        public int PS;
        public int ATK;
        public float Crit;// 暴击率
        public float CritHit;//暴击伤害倍率
        public float InvincibleTime;// 无敌帧时间
        public float SpeedMax;// 最大移动速度
        public float SpeedStart;// 起始移动速度
        public float SpeedA;// 移动加速度
        public float StopA;// 停止加速度
        public float JumpSpeed;// 跳跃速度
        public int JumpTimes;//跳跃次数
        public float Armor;// 护甲值
                           //public float Resistance(...);// 各种属性抗性值

        public float RepelTime;// 被击退时受控制的时间
        public float FallDown;// 倒地时间
        public int FallHit;// 倒地承受临界伤害值
        public float FallDur;// 计算承受伤害值持续时间
        public float ATI;// 普通攻击间隔
        public float SATI;// 特殊攻击间隔

        public int CurHP;// 当前生命值
        public int CurPS;// 当前精力值
        public float CurSpeed;// 当前速度

        public Attr()
        {
            HP = 0;
            PS = 0;
            ATK = 0;
            Crit = 0;
            CritHit = 0;



        }


    }
}
