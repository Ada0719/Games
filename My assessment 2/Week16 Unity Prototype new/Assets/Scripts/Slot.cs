using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public int Id;
    [HideInInspector]
    public GameObject containingItem;
    [HideInInspector]
    public Transform slotIconPanel;

    void Start()
    {
        //Make the first child of the Slot object the panel for displaying item icon
        slotIconPanel = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        //Display the item icon on the slot icon panel
        slotIconPanel.GetComponent<Image>().sprite = containingItem.GetComponent<Item>().icon;
    }

    public void UseItem()
    {
        //If there is an item in the slot, use it
        if (containingItem != null)
            containingItem.GetComponent<Item>().ItemUsage();
    }

    //To be called when the slot is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }
}
