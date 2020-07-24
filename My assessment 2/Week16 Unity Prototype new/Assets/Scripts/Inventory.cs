using UnityEngine;
using System.Collections;
using System;


public class Inventory : MonoBehaviour
{
    private GameController gc;
    private bool inventoryEnabled;
    public GameObject inventory;
    public GameObject slotHolder;

    [HideInInspector]
    public Material originalSuitMaterial;

    private int totalSlotNumber;

    [HideInInspector]
    public GameObject[] slots;

    void Start()
    {
        //Get the game controller
        gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        //Set the player's original Suit Material
        originalSuitMaterial = GameObject.FindWithTag("Suit").GetComponent<MeshRenderer>().material;
        //Get the total number of slots
        totalSlotNumber = slotHolder.transform.childCount;
        //Initialise an array of slot objects
        slots = new GameObject[totalSlotNumber];
        //Add all the slot objects to the array
        for (int i = 0; i < totalSlotNumber; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        //Press I to turn on/off the Inventory menu
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
            if (inventoryEnabled)
                gc.Help("Click The item to equip");
            else
                gc.HelpOff();
        }

        inventory.SetActive(inventoryEnabled);
    }

    void AddItem(GameObject pickedUpItem)
    {
        //Iterate all slot objects
        for (int i = 0; i < totalSlotNumber; i++)
        {
            var slot = slots[i].GetComponent<Slot>();
            //Add Item to Slot if the slot is empty
            if (slot.containingItem == null)
            {
                //Mark the Item as picked up
                pickedUpItem.GetComponent<Item>().pickedUp = true;
                //Assign the item to the solt
                slot.containingItem = pickedUpItem;
                //make the item a child of the slot
                pickedUpItem.transform.parent = slots[i].transform;
                //Deativate the gameobject of the Item to make it disappear on the scene
                pickedUpItem.SetActive(false);
                //Update the slot
                slot.UpdateSlot();
                //Once the item is attached to the slot, exit from the loop
                return;
            }
        }
    }

    //To be called when the item enter the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            var itemPickedup = other.gameObject;
            AddItem(itemPickedup);
            gc.Help(itemPickedup.GetComponent<Item>().description + " is picked up. Press I to check your inventory.");
        }
    }
}
