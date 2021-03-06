using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    partial class UIPool : MonoBehaviour 
    {
        public GameObject UIElement;
        public List<GameObject> UIToUse;
        public List<GameObject> UIUsing;

        private void Start()
        {
            UIToUse = new List<GameObject>();
            UIUsing = new List<GameObject>();

        }

        public GameObject GetUI(Transform parent)
        {
            GameObject ui = new GameObject();
            if(UIToUse.Count>0)
            {
                ui = UIToUse[0];
                UIUsing.Add(UIToUse[0]);
                UIToUse.RemoveAt(0);
                ui.transform.SetParent(parent);
            }
            else
            {
                ui = Instantiate(UIElement, parent);

            }
            ui.SetActive(true);
            
            return ui;

        }

        public void ReUse(GameObject go)
        {
            if(UIUsing.Contains(go))
            {
                UIUsing.Remove(go);
            }
            UIToUse.Add(go);

            go.SetActive(false);

        }

        public void SetElement(GameObject element)
        {
            UIElement = element;
        }


    }
}
