using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Buff;
using Life;

namespace AI
{
    public partial class AIBase : MonoBehaviour
    {

        public AIState AIState;
        protected LifeBase Unit;//ai控制的单位

        protected Rigidbody2D RB2D;

        public GameObject Target;//攻击目标
        public bool IsFindTarget { get=> Target != null; }

        public float ViewAngle;// 视野角度
        public float ViewRange;//视野范围
        public float PatrolRange;//巡逻范围

        public Vector2 CurPatrolPoint;//当前巡逻地

        public Vector2 Forword;

        public bool IsMove
        {
            get
            {
                if(AIState == AIState.Patrol || AIState == AIState.Chace)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool IsRun;


        protected virtual void Start()
        {
            AIState = AIState.Birth;

            IsRun = true;
            AIState = AIState.Idle;

            
        }

        protected virtual void Update()
        {

            if(IsRun)
            {
                Sync();

                if(Unit.LifeState!=LifeState.Freeze)
                {
                    Move();
                    SwitchState();
                }
                GetHurt();




            }






        }


        public void InitAI(LifeBase lifeBase)
        {
            SetUnit(lifeBase);
            RB2D = Unit.RB2D;
            CurPatrolPoint = transform.position;
            Target = null;
            Forword = new Vector2(1, 0);



        }

        public void SetUnit(LifeBase lifeBase)
        {
            Unit = lifeBase;


        }


        public virtual void Move()
        {
            if (AIState == AIState.Patrol || AIState == AIState.Chace)
            {
                RB2D.velocity = new Vector2(Unit.Forward.x * Unit.AttrCur.CurSpeed, RB2D.velocity.y);
            }
            else if(AIState==AIState.Idle||AIState==AIState.Attack)
            {
                RB2D.velocity = new Vector2(0, RB2D.velocity.y);
            }



        }

        public virtual void Attack()
        {




        }

        public virtual void Jump()
        {


        }

        public void Sync()
        {

            Unit.Forward = Forword;
            Unit.IsMove = IsMove;



        }

        public void GetHurt()
        {
            if(Unit.FreezeCounter>0)
            {
                Forword = new Vector2(-(int)Unit.AttrCur.RepelFrom.normalized.x, 0);

            }

        }

    }
}
