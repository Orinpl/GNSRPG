using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Life;
using Main;

namespace Map.Loader
{
    [RequireComponent(typeof(LifePool))]
    public class LifeLoader : MonoBehaviour
    {
        LifePool LifePool;
        LifeBase LifeBase;
        public GameObject Unit;
        public float ProductCD;//生产间隔
        public int MaxNum;//最大数量
        float cd;

        private void Start()
        {
            LifePool = GetComponent<LifePool>();
            LifeBase = Unit.GetComponent<LifeBase>();
            LifePool.SetLife(Unit);
            cd = ProductCD;
        }

        private void Update()
        {
            if (LifePool.LifeUsing.Count < MaxNum)
            {
                if (cd > 0)
                {
                    cd -= Time.deltaTime;
                }
                else
                {
                    cd = ProductCD;

                    LifePool.GetLife(transform.position);

                }
            }



        }

    }
}
