using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HairongWu;

namespace HairongWu
{
	/// <summary>
	/// Author: HairongWu
	/// Description: This script demonstrates how to jump in Unity
	/// </summary>
	
		[RequireComponent(typeof(Rigidbody))]
	public class Jump : MonoBehaviour 
	{
		Rigidbody myRigidbody;

		[Range(1, 20)]
		[SerializeField] int jumpForce = 10;
		
		void Start () 
		{
			myRigidbody = this.GetComponent<Rigidbody>();
		}
	
		void Update () 
		{
		if (Input.GetButtonDown("Jump"))
			{
				myRigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
			}
		}
	
	} 
}