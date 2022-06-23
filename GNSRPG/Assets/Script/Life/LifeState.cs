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
        Attack,//攻击
        Freeze,//不受控制的状态，如被击退、眩晕、倒地等
        Flying,//在空中的状态
        Death,//死亡
    }
}
