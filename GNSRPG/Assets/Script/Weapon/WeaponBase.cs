using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using Hurt;
using Life;
using PlayerLife;
using UnityEngine;
using Bullet;
using System.Collections;

namespace Weapon
{
    [System.Serializable]
    public class WeaponBase : Base 
    {
        LifeBase Owner;

        public WeaponType WeaponType;

        protected Cost Cost;
        public List<HurtManager> HurtList;

        public float ATKRange;
        public int ClipSize;//弹夹容量
        public int BulletLeft;//剩余子弹

        public GameObject BulletPoint;
        public Vector2 BulletPosition { get => BulletPoint.transform.position; }

        public GameObject Bullet;
        public BulletPool BulletPool;

        public BulletBase BulletBase;
        public GameObject BulletToFire;

        public float Angle;//挥舞角度或者散射角度
        public Quaternion TargetPoint;
        public Quaternion RotationOri;
        float RotSpeed;
        public float ATKAnim;//攻击前摇时间
        float tempCounter;
        public bool IsWaving;
        public bool IsShooting;
        public bool IsCanFire;

        private Vector2 BulletDir;

        protected override void Start()
        {
            base.Start();
            BulletPool = GetComponent<BulletPool>();
            BulletPool.SetBullet(Bullet);
            IsWaving = false;
            IsCanFire = false;
            RotationOri = transform.rotation;
            tempCounter = ATKAnim;
        }

        private void Update()
        {
            if(IsWaving)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, TargetPoint, RotSpeed * Time.deltaTime);
                if(Quaternion.Angle(transform.localRotation,TargetPoint) <0.01f)
                {
                    BulletDir = Owner.Forward;
                    IsWaving = false;
                    IsCanFire = true;
                    transform.rotation = RotationOri;
                }

            }

            if(IsShooting)
            {
                if(tempCounter>0)
                {
                    tempCounter -= Time.deltaTime;
                }
                else
                {
                    tempCounter = ATKAnim;
                    IsCanFire = true;
                }

            }

        }

        public bool Attack(LifeBase owner)
        {
            Owner = owner;
            bool flag = ATKCost();
            IsCanFire = false;
            if (flag)
            {
                gameObject.SetActive(true);
                if (WeaponType == WeaponType.SWORD)
                {
                    Wave();
                }
                else if (WeaponType == WeaponType.GUN)
                {
                    Shoot();
                }
                StartCoroutine(Fire());
            }
            return flag;
        }

        IEnumerator Fire()
        {
            yield return new WaitUntil(() => IsCanFire);

            BulletToFire = BulletPool.GetBullet(BulletPosition);
            BulletBase = BulletToFire.GetComponent<BulletBase>();
            BulletBase.InitBullet(this, BulletPosition, BulletDir);
            BulletBase.Fire();
            gameObject.SetActive(false);
        }



        public void Wave()
        {
            transform.right = Owner.Forward;
            TargetPoint = Quaternion.Euler(0, 0, Angle);
            RotSpeed = Math.Abs(Angle / ATKAnim);
            IsWaving = true;
        }

        public void Shoot()
        {
            transform.right = Owner.Forward;
            BulletDir = Quaternion.AngleAxis(UnityEngine.Random.Range(-Angle / 2, Angle / 2), Vector3.forward) * Owner.Forward;
            //后退动作
            IsCanFire = true;
        }

        public bool ATKCost()//根据子弹和自身属性来Cost
        {
            if (Owner.AttrCur.CurPS < Cost.PS || BulletLeft < Cost.BulletNum)
            {
                return false;
            }
            else
            {
                Owner.AttrCur.CurPS -= Cost.PS;
                SubBullet(Cost.BulletNum);
                return true;
            }
        }

        public void SetBullet(int num)
        {
            BulletLeft = num;


        }

        public void AddBullet(int num)
        {
            BulletLeft += num;
            if(BulletLeft>ClipSize)
            {
                BulletLeft = ClipSize;
            }
        }

        public void SubBullet(int num)
        {
            BulletLeft -= num;
            if(BulletLeft<0)
            {
                BulletLeft = 0;
            }
        }    

        public void SetCost(Cost cost)
        {
            Cost = cost;
        }
    }
}
