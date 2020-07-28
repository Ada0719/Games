using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBottle : MonoBehaviour
{
    [Range(1,10)]
    public int mana;

    public void GetPickedUp(out int mana)
    {
        mana = this.mana;
        Destroy(gameObject);
    }
}
