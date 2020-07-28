using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HairongWu;

namespace HairongWu
{
	/// <summary>
	/// Author: HairongWu
	/// Description: Player's Actions
	/// </summary>
	public class Action : MonoBehaviour 
	{



		#region Instance Variables aka Non-Static Member Variables 
		private UI ui;


        #endregion

		#region Unity Methods
		void Start () 
		{
			ui = gameObject.GetComponent<UI>();
		
		}
	
		void Update () 
		{
			if (Input.GetKeyDown(KeyCode.M))
			{
				UseMagic();
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("bottle"))
			{
				PickUpBottle(other.gameObject.GetComponent<ManaBottle>());
			}
			else if (other.gameObject.CompareTag("weapon"))
			{
				ChangeWeapon(other.gameObject.GetComponent<Weapon>());
			}
			else if (other.gameObject.CompareTag("enemy"))
			{
				GetAttacked();
			}
		}
		#endregion


		#region Custom Public Methods 
		#endregion

		#region Custom Private Methods 
		private void GetKilled()
		{
			if (ui.GetKilled())
			{
				GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GameOver(false);
			}
			else
			{
				//TODO: Game Change Code here
			}
		}

		private void GetAttacked()
		{
			//UI Change
			var status = ui.GetAttacked();
			if(status == ProtectionStatus.Killed)
			{
				GetKilled();
			}
			else if(status == ProtectionStatus.ArmorBreak)
			{
				//TODO: Game Change Code here
			}
		}

		private void ChangeWeapon(Weapon weapon)
		{
			//UI Change
			WeaponType weaponType;
			weapon.GetPickedUp(out weaponType);
			ui.ChangeWeapon(weaponType);

			//TODO: Game Change Code here

		}

		private void PickUpBottle(ManaBottle manaBottle)
		{
			//UI Change
			int mana;
			manaBottle.GetPickedUp(out mana);
			ui.AddMana(mana);

			//TODO: Game Change Code here
		}

		private void UseMagic()
		{
			ui.CostMana();
			if (ui.magicable)
			{
				Debug.Log("magic performance");
			}
			else
			{
				Debug.Log("need mana");
			}
			
		}


        #endregion

	}
}