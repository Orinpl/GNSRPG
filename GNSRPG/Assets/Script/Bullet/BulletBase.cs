using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using Hurt;
using UnityEngine;
using Life;

namespace Bullet
{
    public class BulletBase : Base 
    {
        public BulletType BulletType;
        public List<HurtManager> HurtList;
        public float Speed;
        public float Range;
        public float Duration;
        public List<LifeBase> HitList = new List<LifeBase>();
        public List<LifeBase> DamegeList = new List<LifeBase>();

        public Vector2 StartPoint;
        public Vector2 Direction;
        public Vector2 Target;

        public void Fly()
        {



        }

        private void FixedUpdate()
        {
            
        }


        public void SetTarget(Vector2 dir)
        {
            Direction = dir;
            Target = StartPoint + Direction.normalized * Range;
            
        }

    }
}
