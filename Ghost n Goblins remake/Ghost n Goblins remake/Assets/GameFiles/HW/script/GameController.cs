using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HairongWu;

namespace HairongWu
{
	/// <summary>
	/// Author: HairongWu
	/// Description: This script demonstrates how to ... in Unity
	/// </summary>
	public class GameController : MonoBehaviour
	{

		#region Class Variables aka Static Member Variables 
		#endregion

		#region Instance Variables aka Non-Static Member Variables 
		private bool isGameOver;
		private bool win;

		#endregion

		#region Unity Methods
		void Start()
		{
			isGameOver = false;

		}

		void Update()
		{
			if (isGameOver)
			{
				if (this.win)
				{
					//SceneManager.LoadSceneAsync("win screen");
				}
				else
				{
					SceneManager.LoadSceneAsync("TitleScreen");
				}
			}
		}
		#endregion


		#region Custom Public Methods 
		public void GameOver(bool win)
		{
			isGameOver = true;
			this.win = win;
		}
        #endregion

		#region Custom Private Methods 
        #endregion

	}
}