using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace HairongWu
{
	/// <summary>
	/// Author: HairongWu
	/// Description:Behaviour of each armor durable
	/// </summary>
	public class ArmorDurable : MonoBehaviour 
	{
		[HideInInspector]
		public bool isArmorOn;

		public void GetAttacked()
		{
			isArmorOn = false;
			ArmorImageUpdate();
		}

		public void Recover()
		{
			isArmorOn = true;
			ArmorImageUpdate();
		}
		
		private void ArmorImageUpdate()
		{
			if (isArmorOn)
			{
				gameObject.GetComponent<Image>().sprite = GameObject.FindGameObjectWithTag("player").GetComponent<UI>().armorImage;
				gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
			}
			else
			{
				gameObject.GetComponent<Image>().color = new Color(255, 255,255,0f);
			}
		}

		//void Start () 
		//{
		//	Recover();
		//}
	
		//void Update () 
		//{
		//	if (Input.GetKeyDown(KeyCode.I))
		//	{
		//		GetAttacked();
		//	}

		//	if (Input.GetKeyDown(KeyCode.T))
		//	{
		//		Recover();
		//	}
		//}
	
	}
}