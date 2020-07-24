using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HairongWu;

namespace HairongWu
{
	/// <summary>
	/// Author: HairongWu
	/// Description: Behaviour of each mana bottle slot
	/// </summary>
	public class Bottle : MonoBehaviour 
	{
		[HideInInspector]
		public bool isBottleFull;
		
		public void BottleCost()
		{
			isBottleFull = false;
			BottleImageUpdate();
		}

		public void BottleRecharge()
		{
			isBottleFull = true;
			BottleImageUpdate();
		}

		public void BottleImageUpdate()
		{
			if (isBottleFull)
			{ 
				gameObject.GetComponent<Image>().sprite = GameObject.FindGameObjectWithTag("player").GetComponent<UI>().bottleFullImage; 
			}
			else
			{
				gameObject.GetComponent<Image>().sprite = GameObject.FindGameObjectWithTag("player").GetComponent<UI>().bottleEmptyImage;

			}
		}
	}
}