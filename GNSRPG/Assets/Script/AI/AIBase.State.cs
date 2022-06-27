using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace AI
{
    public partial class AIBase
    {
        public void SwitchState()
        {
            if(!IsFindTarget)
            {
                AIState = AIState.Patrol;
            }
            Patrol();
            Chace();
            Attack();
        }


        public void SearchEnemy()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(this.transform.position, ViewRange);


            Vector2 dir = Vector2.zero;
            Target = null;

            foreach(Collider2D c2d in collider2Ds)
            {
                if(c2d.CompareTag("Player"))//这里假定player只有一个
                {
                    Target = c2d.gameObject;

                }
            }

            if (Target != null)
            {

                dir = Target.transform.position - transform.position;
                if (Vector2.Angle(dir, Forword) <= (ViewRange / 2))
                {
                    AIState = AIState.Chace;
                    Chace();
                }
                else
                {
                    Target = null;
                }
            }

        }

        public void Patrol()
        {
            SearchEnemy();
            if (AIState==AIState.Patrol)
            {
                if ((transform.position.x - CurPatrolPoint.x) > PatrolRange)
                {
                    Forword.x = -1;
                }
                else if ((transform.position.x - CurPatrolPoint.x) < -PatrolRange)
                {
                    Forword.x = 1;
                }


            }

        }

        public void Chace()
        {
            if(AIState==AIState.Chace&&Target!=null)
            {
                Vector2 dir = Target.transform.position - transform.position;
                float dis = Vector2.Distance(Target.transform.position, transform.position);
                Forword = new Vector2(dir.x, 0).normalized;

                if(dis<Unit.WeaponATK.ATKRange||dis<Unit.WeaponSpecial.ATKRange)
                {
                    AIState = AIState.Attack;


                }
            }
            else if(AIState == AIState.Chace && Target ==null)
            {
                CurPatrolPoint = transform.position;
                AIState = AIState.Patrol;


            }



        }






    }
}
