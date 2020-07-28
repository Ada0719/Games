using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cameron;

namespace Cameron
{
	/// <summary>
	/// Author: Cameron Dougan
	/// Description: This script loads the different scene of the Unity Project, being able to be applied to buttons and key presses
	/// </summary>
	public class SceneManagerScript : MonoBehaviour 
	{

		#region Class Variables aka Static Member Variables 
		#endregion

		#region Instance Variables aka Non-Static Member Variables 
		#endregion

		#region Custom Public Methods

		// Calls for the SceneManager to load a specified scene of a Unity project
		public void SceneManagerMethod(string LoadScene)
		{
			// SceneManager.LoadScene("Name of Scene");
			SceneManager.LoadSceneAsync(LoadScene);
		}

		#endregion

		#region Custom Private Methods 
		#endregion

	}
}