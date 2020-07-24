using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HairongWu
{
    public class Weapon : MonoBehaviour
    {
        public WeaponType weaponType;

        public void GetPickedUp(out WeaponType weaponType)
        {
            weaponType = this.weaponType;
            Destroy (gameObject);
        }
    }
}
