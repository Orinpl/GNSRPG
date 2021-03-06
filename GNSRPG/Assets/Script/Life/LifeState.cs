using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public enum LifeState
    {
        Birth,//出生
        Idle,//普通状态
        Move,//移动
        Rush,//冲刺
        Attack,//攻击
        SpecialAttack,//特殊攻击
        Freeze,//不受控制的状态，如被击退、眩晕、倒地等
        Invincible,// 无敌状态
        Flying,//在空中的状态
        Death,//死亡
    }
}
