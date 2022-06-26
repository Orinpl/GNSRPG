using System;
using System.Collections;
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
    //玩家面板
    public class PlayerUI : MonoBehaviour
    {
        public static PlayerUI Singleton;

        public Player Player;

        public Image HPBG;//血条底图
        public Image HPFill;//血条填充
        public float HPBarLength;//血条长度
        public float HPBarStandard;//标准血条长度，100血
        RectTransform HPRect;

        public Image PSBG;//体力底图
        public Image PSFill;//体力填充
        public float PSBarLength;//体力条长度
        public float PSBarStandard;//标准体力条长度，100体力
        RectTransform PSRect;

        public float HPCur;//目前血量百分比
        public float PSCur;//目前体力百分比

        public int ClipSize;
        private int CurBullet;
        public Image BulletCell;
        public Image Clip;
        public List<GameObject> BulletList;

        private UIPool UIPool;

        private void Start()
        {
            if(Singleton!=null)
            {
                Destroy(Singleton);
            }
            Singleton = this;

            HPRect = HPBG.rectTransform;
            PSRect = PSBG.rectTransform;


            Player = FindObjectOfType<Player>();
            HPBarLength = (Player.AttrCur.HP / 100) * HPBarStandard;
            PSBarLength = (Player.AttrCur.PS / 100) * HPBarStandard;

            HPRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, HPBarLength);
            PSRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PSBarLength);


            ClipSize = Player.WeaponSpecial.ClipSize;
            UIPool = new UIPool(BulletCell.gameObject);
            BulletList = new List<GameObject>();
        }

        private void Update()
        {
            HPCur = Player.AttrCur.CurHP/Player.AttrCur.HP;
            PSCur = Player.AttrCur.CurPS/Player.AttrCur.PS;
            CurBullet = Player.WeaponSpecial.BulletLeft;

            HPFill.fillAmount = HPCur;
            PSFill.fillAmount = PSCur;

            if(BulletList.Count<CurBullet)
            {
                StartCoroutine(AddBullet(CurBullet - BulletList.Count));
            }
            else if(BulletList.Count>CurBullet)
            {
                RemoveBullet(BulletList.Count - CurBullet);
            }


        }

        public IEnumerator AddBullet(int n)
        {

            for (int i = 0; i < n; i++)
            {
                yield return null;
                BulletList.Add(UIPool.GetUI(Clip.transform));


            }
        }

        public IEnumerator RemoveBullet(int n)
        {
            int count = 0;
            if (BulletList.Count > n)
            {
                count = BulletList.Count - n;
            }
            else
            {
                count = 0;
            }

            for (int i = BulletList.Count - 1; i >= count; i--)
            {
                yield return null;
                UIPool.ReUse(BulletList[i]);
                BulletList.RemoveAt(i);
            }


        }
        

    }
}
