using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cameron;

namespace Cameron
{
	/// <summary>
	/// Author: Cameron Dougan
	/// Description: This script Exits and closes the application when it is executed, the method is able to be attached to a button or a keypress.
	/// </summary>
	public class ExitGameMethodScript : MonoBehaviour 
	{

		#region Class Variables aka Static Member Variables 
        #endregion

		#region Instance Variables aka Non-Static Member Variables 
        #endregion

		#region Unity Methods
		// For if the method will be attached to a keypress instead of a button
		//void Update () 
		//{
			//if (Input.GetButton("Cancel"))
			//{
				//ExitGameMethod();
			//}
		//}
		#endregion


		#region Custom Public Methods

		public void ExitGameMethod()
		{
			// For if you prefer to test inside the Unity Editor
			// Debug.Log("Game Quit");
			Application.Quit();
		}

		#endregion

		#region Custom Private Methods 
		#endregion

	}
}