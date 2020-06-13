using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggeringStuff : MonoBehaviour
{
    private GameController gc;

    private void Start()
    {
        //Get the game controller
        gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider whatWasHit)
    {
        if (whatWasHit.transform.tag == "Hazad")
        {
            gameObject.layer = LayerMask.NameToLayer("Obstacles");
            Debug.Log(LayerMask.LayerToName(gameObject.layer));
            gc.Help("You are hidden now");
        }
    }

    private void OnTriggerExit(Collider whatWasHit)
    {
        if (whatWasHit.transform.tag == "Hazad")
        {
            var slotObject = GetComponent<Inventory>().slots.Where(s => s.GetComponent<Slot>().containingItem != null && s.GetComponent<Slot>().containingItem.GetComponent<Item>().equipped).FirstOrDefault();
            if(slotObject != null)
            {
                gameObject.layer = LayerMask.NameToLayer(slotObject.GetComponent<Slot>().containingItem.GetComponent<Item>().Type);
            }
            else
            {
                gameObject.layer = LayerMask.NameToLayer("Targets");

            }
            Debug.Log(LayerMask.LayerToName(gameObject.layer));
            gc.Help("You are out now");
        }
    }

}
