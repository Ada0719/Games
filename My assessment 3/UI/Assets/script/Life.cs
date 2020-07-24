using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HairongWu;

namespace HairongWu
{
	/// <summary>
	/// Author: HairongWu
	/// Description: Behaviour of each life slot
	/// </summary>
	public class Life : MonoBehaviour 
	{
		[HideInInspector]
		public bool isLifeOn;

		public void LostLife()
		{
			isLifeOn = false;
			LifeImageUpdae();
		}

		public void InitializeLife()
		{
			isLifeOn = true;
			LifeImageUpdae();
		}

		private void LifeImageUpdae()
		{
			if (isLifeOn)
			{
				gameObject.GetComponent<Image>().sprite = GameObject.FindGameObjectWithTag("player").GetComponent<UI>().lifeImage;
			}
			else
			{
				gameObject.GetComponent<Image>().sprite = null;
			}
		}
	}
}