using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using Life;
using UnityEngine;

namespace Player
{
    public partial class Player:LifeBase
    {
        public float Speed;


        protected override void Start()
        {
            base.Start();
        }

        protected void Update()
        {
            Speed = AttrCur.CurSpeed;
            Move();
            Jump();
        }


    }
}
