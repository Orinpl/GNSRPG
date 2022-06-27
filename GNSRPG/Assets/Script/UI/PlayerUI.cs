using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using Life;
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

            StartCoroutine(InitUI());
            
        }

        private void Update()
        {
            if (Player.AttrCur != null)
            {
                HPCur = (float)Player.AttrCur.CurHP / Player.AttrCur.HP;
                PSCur = (float)Player.AttrCur.CurPS / Player.AttrCur.PS;
                CurBullet = Player.WeaponSpecial.BulletLeft;

                HPFill.fillAmount = HPCur;
                PSFill.fillAmount = PSCur;
            }


            if (BulletList != null && UIPool != null)
            {
                if (BulletList.Count < CurBullet)
                {
                    AddBullet(CurBullet - BulletList.Count);
                }
                else if (BulletList.Count > CurBullet)
                {
                    RemoveBullet(BulletList.Count - CurBullet);
                }
            }

        }

        public void AddBullet(int n)
        {

            for (int i = 0; i < n; i++)
            {
                BulletList.Add(UIPool.GetUI(Clip.transform));


            }
        }

        public void RemoveBullet(int n)
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
                UIPool.ReUse(BulletList[i]);
                BulletList.RemoveAt(i);
            }


        }

        public IEnumerator InitUI()
        {
            yield return new WaitUntil(() => Player.AttrCur != null);

            HPBarLength = (Player.AttrCur.HP / 100) * HPBarStandard;
            PSBarLength = (Player.AttrCur.PS / 100) * HPBarStandard;


            HPRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, HPBarLength);
            PSRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PSBarLength);

            UIPool = GetComponent<UIPool>();
            UIPool.SetElement(BulletCell.gameObject);
            BulletList = new List<GameObject>();

            yield return new WaitUntil(() => Player.WeaponSpecial != null);

            ClipSize = Player.WeaponSpecial.ClipSize;

        }

        

    }
}
