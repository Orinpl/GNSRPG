using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Life
{
    public class LifePool : MonoBehaviour 
    {
        private GameObject LifeObj;
        private LifeBase LifeBase;

        public List<GameObject> LifeToUse = new List<GameObject>();
        public List<GameObject> LifeUsing = new List<GameObject>();



        protected void Start()
        {
            

        }



        public GameObject GetLife(Vector3 Postion)
        {
            if (LifeToUse.Count <= 0)
            {
                GameObject life = Instantiate(LifeObj, Postion, Quaternion.identity);
                LifeBase = life.GetComponent<LifeBase>();
                LifeBase.LifePool = this;
                return life;
            }
            else
            {
                GameObject life = LifeToUse[0];
                LifeUsing.Add(life);
                LifeToUse.RemoveAt(0);
                return life;
            }
        }

        public void ReUse(GameObject life)
        {
            if (LifeUsing.Contains(life))
            {
                LifeUsing.Remove(life);
            }
            LifeToUse.Add(life);

            life.SetActive(false);
        }

        public void SetLife(GameObject gameObject)
        {
            LifeObj = gameObject;
        }




    }
}
