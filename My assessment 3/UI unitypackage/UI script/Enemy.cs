using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HairongWu;

namespace HairongWu
{
	/// <summary>
	/// Author: HairongWu
	/// Description: This script demonstrates how to ... in Unity
	/// </summary>
	public class Enemy : MonoBehaviour 
	{

		#region Class Variables aka Static Member Variables 
		#endregion

		#region Instance Variables aka Non-Static Member Variables 
		#endregion

		#region Unity Methods
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("enemy"))
			{
				Destroy(other.gameObject);
				Destroy(gameObject);
			}
		}
		#endregion


		#region Custom Public Methods 
		#endregion

		#region Custom Private Methods 
		#endregion

	}
}