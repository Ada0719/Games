using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Isaac;

namespace Isaac
{
    /// <summary>
    /// Author: Isaac
    /// Description: This script demonstrates how to ... in Unity
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Jumping : MonoBehaviour
    {

        #region Class Variables aka Static Member Variables 
        [SerializeField] Rigidbody myRigidBody;
        [Header("This Is Jump Settings")]
        [Range(1,20)]
        [SerializeField] int jumpForce = 10;


        #endregion

		#region Instance Variables aka Non-Static Member Variables 
        #endregion

		#region Unity Methods
		void Start () 
		{
            myRigidBody = this.GetComponent<Rigidbody>();
		
		}
	
		void Update () 
		{
		   if (Input.GetButtonDown("Jump"))
            {
                myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }

		}
		#endregion


		#region Custom Public Methods 
        #endregion

		#region Custom Private Methods 
        #endregion

	}
}