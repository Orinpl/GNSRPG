using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using Hurt;
using Life;
using Player;
using UnityEngine;
using Bullet;

namespace Weapon
{
    [RequireComponent(typeof(BulletPool))]
    public class WeaponBase : Base 
    {
        LifeBase Ower;

        public WeaponType WeaponType;
        public Cost Cost;
        public List<HurtManager> HurtList;

        public float ATKRange;
        public int ClipSize;
        public GameObject BulletPoint;
        public Vector2 BulletPosition;

        public GameObject Bullet;
        public BulletPool BulletPool;

        protected override void Start()
        {
            base.Start();
            BulletPosition = BulletPoint.transform.position;
            BulletPool.SetBullet(Bullet);
        }

        public void Attack(LifeBase ower)
        {
            Ower = ower;
            BulletPool.GetBullet(BulletPosition);


        }    
    }
}
