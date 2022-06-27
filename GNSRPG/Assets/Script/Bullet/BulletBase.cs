using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using Hurt;
using UnityEngine;
using Life;
using Weapon;
using PlayerLife;
using EnemyLife;

namespace Bullet
{
    public class BulletBase : Base 
    {
        public BulletType BulletType;
        public TargetType TargetType;
        public List<HurtManager> HurtList;
        public float Speed;
        public float Range;

        public float Duration;
        public float Record;

        public List<LifeBase> HitList;
        public List<LifeBase> DamegeList;

        public Vector2 StartPoint;
        public Vector2 Direction;
        public Vector2 Target;
        public Vector2 LastPosition;

        public float FlyTime;
        public float flyTime;
        public bool IsFire;
        public bool IsFly;

        public bool IsDestroy;

        public WeaponBase Owner;

        public Ray2D Ray2D;

        public bool IsReflect;//只能反射一次

        public void Fire()
        {
            IsFire = true;
            if (BulletType == BulletType.GUN || BulletType == BulletType.SLIMES)
            {
                IsFly = true;
            }
            else if(BulletType==BulletType.SWORD)
            {
                IsFly = false;

            }

        }

        protected override void Start()
        {
            HitList = new List<LifeBase>();
            DamegeList = new List<LifeBase>();
            HurtList = new List<HurtManager>();
            IsReflect = false;
        }


        private void Update()
        {
            if(IsFire)
            {
                if (IsFly)
                {
                    transform.position = Vector2.Lerp(StartPoint, Target, flyTime);
                    GetObj(LastPosition, transform.position);
                    HurtObj();
                    LastPosition = transform.position;
                    flyTime += (1 / FlyTime) * Time.deltaTime;

                    if ((Math.Abs(transform.position.x - Target.x) + Math.Abs(transform.position.y - Target.y)) < 0.1f
                || Record >= Duration)
                    {
                        ToDestroy();
                    }
                }
                else
                {
                    if(Record >= Duration)
                    {
                        HurtObj();
                        ToDestroy();
                    }
                }
                Record += Time.deltaTime;

            }

                

        }

        public void InitBullet(WeaponBase owner, Vector2 start, Vector2 dir)
        {

            
            flyTime = 0;

            Owner = owner;
            StartPoint = start;
            this.transform.position = StartPoint;
            Record = 0;
            LastPosition = new Vector2(transform.position.x, transform.position.y);
            //设置其他属性
            SetTarget(dir);
            gameObject.SetActive(true);
        }

        public void SetTarget(Vector2 dir)
        {
            transform.right = dir;
            Direction = dir;
            Target = StartPoint + Direction.normalized * Range;
            Debug.DrawLine(StartPoint, dir);
            FlyTime = Range / Speed;
        }

        public void GetObj(Vector2 lastPos,Vector2 thisPos)//获取命中目标
        {
            float dis = Vector2.Distance(lastPos, thisPos);
            Ray2D = new Ray2D(thisPos,lastPos - thisPos );
            RaycastHit2D[] hits = Physics2D.RaycastAll(Ray2D.origin, Ray2D.direction, dis);
            foreach(RaycastHit2D r2 in hits)
            {
                if(r2.collider!=null)
                {
                    if (r2.collider.CompareTag("Enemy") || r2.collider.CompareTag("Player"))//
                    {
                        LifeBase lb = r2.collider.gameObject.GetComponent<LifeBase>();
                        if (lb.TargetType!=TargetType)
                        {
                            HitList.Add(r2.collider.gameObject.GetComponent<LifeBase>());
                        }
                        
                    }
                    else if(r2.collider.CompareTag("Bullet"))
                    {
                        BulletBase bb = r2.collider.gameObject.GetComponent<BulletBase>();
                        if (bb != null)
                        {
                            if (bb.TargetType != TargetType&&bb.BulletType==BulletType.SWORD&&!IsReflect)//可以砍回去
                            {
                                Vector2 dir = Vector2.Reflect(transform.right, bb.transform.right);
                                TargetType = bb.TargetType;
                                InitBullet(Owner, transform.position, dir);
                            }
                        }


                    }


                }

            }


        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsFire && !IsFly)
            {
                GameObject go = collision.gameObject;
                if (go.CompareTag("Enemy") || go.CompareTag("Player"))
                {
                    if (go.GetComponent<LifeBase>() != null)
                    {
                        if (go.GetComponent<LifeBase>().TargetType != Owner.Owner.TargetType)
                        {
                            HitList.Add(go.GetComponent<LifeBase>());
                        }
                    }

                }
                else if(go.CompareTag("Bullet"))
                {
                    BulletBase bb = go.GetComponent<BulletBase>();
                    if (bb!=null)
                    {
                        if (bb.TargetType!=TargetType)//可以砍回去
                        {
                            Vector2 dir = Vector2.Reflect(bb.transform.right, transform.right);
                            bb.TargetType = TargetType;
                            bb.InitBullet(bb.Owner, bb.transform.position, dir);
                        }
                    }
                }


            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
        }



        public void HurtObj()//伤害命中的目标
        {
            for (int i = HitList.Count - 1; i >= 0; i--)
            {
                if(!DamegeList.Contains(HitList[i]))
                {
                    HitList[i].GetHurt(HurtList,transform.right);
                    DamegeList.Add(HitList[i]);
                    HitList.RemoveAt(i);

                }
                else
                {
                    HitList.RemoveAt(i);
                }
            }

        }



        public void ToDestroy()//回收子弹
        {
            IsFire = false;

            //若要对DamageList做什么在这里
            TargetType = Owner.Owner.TargetType;

            DamegeList.Clear();
            HurtList.Clear();
            IsReflect = false;

            Owner.BulletPool.ReUse(this.gameObject);
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Ray2D.origin, Ray2D.origin+Ray2D.direction);
        }

    }
}
