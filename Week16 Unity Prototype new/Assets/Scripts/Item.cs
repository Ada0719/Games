using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Item : MonoBehaviour
{
    public int ID;
    public string Type;
    public string description;
    public Sprite icon;
    public Material itemMaterial;
    public bool pickedUp;
  

    [HideInInspector]
    public bool equipped;

    [HideInInspector]
    GameObject suit;

    [HideInInspector]
    GameObject player;



    void Start()
    {
        //Get the player of the game
        player = GameObject.FindWithTag("Player");
        //Get the game object to wear the suit
        suit = GameObject.FindWithTag("Suit");
    }

    public void Update()
    {
        //When G is pressed and the item is equipped, unequipped it
        if (Input.GetKeyDown(KeyCode.G) && equipped)
        {
            equipped = false;

            //Change back to the original material
            var mats = suit.GetComponent<MeshRenderer>().materials;
            mats[0] = player.GetComponent<Inventory>().originalSuitMaterial;
            suit.GetComponent<MeshRenderer>().materials = mats;

            //Change back to layer Targets
            player.layer = LayerMask.NameToLayer("Targets");
        }
    }

    public void ItemUsage()
    {
        //Unequipped the current equipped item
        var slotObject = player.GetComponent<Inventory>().slots.Where(s => s.GetComponent<Slot>().containingItem != null && s.GetComponent<Slot>().containingItem.GetComponent<Item>().equipped).FirstOrDefault();
        if (slotObject != null)
            slotObject.GetComponent<Slot>().containingItem.GetComponent<Item>().equipped = false;
        //Equipped this item
        this.equipped = true;

        //Change Material of the object
        var mats = suit.GetComponent<MeshRenderer>().materials;
        mats[0] = itemMaterial;
        suit.GetComponent<MeshRenderer>().materials = mats;

        //Change Layer
        player.layer = LayerMask.NameToLayer(Type);
    }

}
