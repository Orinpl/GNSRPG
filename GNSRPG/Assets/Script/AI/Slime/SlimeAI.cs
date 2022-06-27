using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PlayerLife;
using EnemyLife;
using Life;
using Main;

namespace AI
{
    public class SlimeAI:AIBase
    {
        public override void Attack()
        {
            base.Attack();
            if(AIState==AIState.Attack)
            {
                Unit.WeaponATK.Attack(Unit);

            }



        }



    }
}
