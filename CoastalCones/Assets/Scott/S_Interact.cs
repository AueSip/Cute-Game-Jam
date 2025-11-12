using System.Collections.Generic;
using UnityEngine;

public class S_Interact : MonoBehaviour
{
    /*
    private Script_UI_Handler ui_Handler;
    */
    List<S_Interactable_Base> Overlaps = new List<S_Interactable_Base>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ui_Handler = GameObject.Find("Canvas").GetComponent<Script_UI_Handler>();
    }

    // Update is called once per frame
    void Update()
    {

    }

   

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponentInParent<S_Interactable_Base>();
        if (interactable != null)
        {
            if (!Overlaps.Contains(interactable))
            {
                Overlaps.Add(interactable);

            
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponentInParent<S_Interactable_Base>();
        if (interactable != null)
        {
            Overlaps.Remove(interactable);

        }
    }

    public void CallInteract(GameObject player)
    {
        print("Button Press");
        foreach (S_Interactable_Base sc in Overlaps)
        {
            if (sc != null)
            {
                S_Interactable_Base obj = sc;
                obj.Interacted(player);
            }
            
        }
    }
}
