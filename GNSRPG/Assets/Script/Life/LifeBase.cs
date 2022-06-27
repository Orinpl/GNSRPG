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

        public Vector3 Forward;//用来设置朝向
        

        public AIBase AI;

        public Rigidbody2D RB2D;
        public Collider2D CD2D;

        public bool IsGround;
        public bool IsMove;
        public bool IsToStop;

        public LayerMask Ground;
        public GameObject Foot;
        Collider2D FootColl;

        public int RemainJumpTimes;

        public bool IsATKing;
        public bool CanATK;
        public bool CanSATK;
        public float ATKCD;//攻击CD
        public float SATKCD;//特殊攻击CD
        public float PSRCD;//体力恢复CD
        public float HPRCD;//生命恢复CD

        public float FreezeCounter;//计算被控制的时间

    }
}
