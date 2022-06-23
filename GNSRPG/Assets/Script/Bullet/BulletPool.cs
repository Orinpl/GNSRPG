using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Main;


namespace Bullet
{
    public class BulletPool:Base
    {
        public GameObject BulletObj;
        public List<GameObject> BulletToUse = new List<GameObject>();
        public List<GameObject> BulletUsing = new List<GameObject>();
        public GameObject GetBullet(Vector3 Postion)
        {
            if(BulletToUse.Count<=0)
            {
                GameObject bullet = Instantiate(BulletObj, Postion, Quaternion.identity);
                return bullet;
            }
            else
            {
                GameObject bullet = BulletToUse[0];
                BulletUsing.Add(bullet);
                BulletToUse.RemoveAt(0);
                return bullet;
            }
        }

        public void ReUse(GameObject bullet)
        {
            if(BulletUsing.Contains(bullet))
            {
                BulletUsing.Remove(bullet);
            }
            BulletToUse.Add(bullet);

        }

        public void SetBullet(GameObject gameObject)
        {
            BulletObj = gameObject;
        }

    }
}
