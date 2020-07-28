using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HairongWu;

namespace HairongWu
{
	/// <summary>
	/// Author: HairongWu
	/// Description: This script demonstrates how to shoot in Unity
	/// </summary>
	[RequireComponent(typeof(Rigidbody))]
	public class Shoot : MonoBehaviour 
	{
		
		[SerializeField] GameObject projectile;
		
		void Start () 
		{
		
		}
	
		void Update () 
		{
		if (Input.GetButtonDown("Fire1"))
			{
				Instantiate(projectile, this.transform.position, this.transform.rotation);
			}
		}

	
	}

	
}