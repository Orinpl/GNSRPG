using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public enum AIState
    {
        Birth,//出生（用于控制ai是否启动）
        Idle,//什么也不做
        ViewAround,//左右巡视
        Patrol,//巡逻
        Attack,//攻击
        Chace,//追击
        Freeze,//被控制
        Death,//死亡


    }
}
