using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Buff;
using Weapon;
using AI;

namespace Life
{
    public partial class LifeBase:Base
    {
        public Attr AttrOri;
        public Attr AttrCur;
        public BuffManager BuffManager;
        public LifeState LifeState;


        public GameObject WATK;
        public GameObject WSATK;
        public WeaponBase WeaponATK;//基础攻击武器
        public WeaponBase WeaponSpecial;//特殊武器
        //public GameObject WeaponPoint;
        //Vector3 WeaponPosition;



        public AIBase AI;

        protected Rigidbody2D RB2D;
        protected Collider2D CD2D;

        public bool IsGround;
        public bool IsMove;
        public bool IsToStop { get => !IsMove; }

        public LayerMask Ground;
        public GameObject Foot;
        Collider2D FootColl;

        public int RemainJumpTimes;

        public bool IsATKing;
        public bool CanATK;
        public float ATKCD;//攻击CD
        public float SATKCD;//特殊攻击CD

    }
}
