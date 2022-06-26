using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using PlayerLife;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour 
    {
        public static UIManager Singleton;

        public PlayerUI PlayerUI;








        protected virtual void Start()
        {
            if(Singleton!=null)
            {
                Destroy(Singleton);
            }
            Singleton = this;

            PlayerUI = PlayerUI.Singleton;
        }








    }
}
