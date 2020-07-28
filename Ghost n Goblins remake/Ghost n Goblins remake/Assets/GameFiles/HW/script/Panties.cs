using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HairongWu{
    public class Panties : MonoBehaviour
    {
        [HideInInspector]
        public bool isPantiesOn;

        public void GetAttacked()
        {
            isPantiesOn = false;
            PantiesImageUpdate();
        }

        public void Recover()
        {
            isPantiesOn = true;
            PantiesImageUpdate();
        }

        private void PantiesImageUpdate()
        {
            if (isPantiesOn)
            {
                gameObject.GetComponent<Image>().sprite = GameObject.FindGameObjectWithTag("player").GetComponent<UI>().pantiesImage;
                gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            }
            else
            {
                gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
            }
        }
    }
}