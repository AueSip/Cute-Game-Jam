using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_Interact : MonoBehaviour
{
    /*
    private Script_UI_Handler ui_Handler;
    */
    List<S_Interactable_Base> Overlaps = new List<S_Interactable_Base>();
    List<S_Placement_Pos> Placements = new List<S_Placement_Pos>();
    
    public Script_Sound_Player soundManager;
    bool itemHeld = false;

    S_Interactable_Base objectHeld;

    public GameObject pivot;
    public Transform heldLocation;
    Transform defTran;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   

        //ui_Handler = GameObject.Find("Canvas").GetComponent<Script_UI_Handler>();
        defTran = this.transform;

    }

    // Update is called once per frame
    void Update()
    {   
        TestRay();
        
        if (objectHeld == null)
        {
            return;
        }

        if (objectHeld.GetMoving() == false)
        {
            objectHeld.UpdateThisTransform(heldLocation);
        }

        

    }
    
    private void TestRay()
    {
        Vector3 pos = new Vector3();
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()); // Create a ray from the mouse position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // Perform the raycast
        {
            pos = hit.point;
            pivot.transform.LookAt(pos);
        }
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

        var place = other.GetComponentInParent<S_Placement_Pos>();
        if (place != null)
        {
            if (!Placements.Contains(place))
            {
                Placements.Add(place);

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

        var place = other.GetComponentInParent<S_Placement_Pos>();
        if (Placements != null)
        {
            Placements.Remove(place);

        }
    }

    public void CallInteract(GameObject player)
    {   

        
       if (!itemHeld)
        {
            GrabItem(player);
            soundManager.PlayInteractList();
            return; 
        }
        if (itemHeld && objectHeld != null && Placements != null)
        {
            PlaceHeldItem(player);
            soundManager.PlayInteractList();
            return;

        }
        print("ITEM HELD VALUE:" + itemHeld);
    }

    public Transform GetHeldTransform()
    {
        return this.transform;
    }

    public void PlaceHeldItem(GameObject player)
    {
       if (Placements.Count > 0)
        {
            objectHeld.SetInteractable(true);
            objectHeld.SetCollisionEnabled(true);
            objectHeld.SetTargetPosition(Placements[Placements.Count-1].GetObjectPlaceTarget());
        }
        
      

        objectHeld.Interacted(player, this);
        print("PLACED THIS OBJ");

        
        Placements[Placements.Count-1].PlacedIceCream(objectHeld.gameObject);
        //DEBUG
        

        objectHeld = null;
        itemHeld = false;
    }

    public void GrabItem(GameObject player)
    {
        foreach (S_Interactable_Base sc in Overlaps)
        {   
            if (sc != null && objectHeld == null)
            {
                S_Interactable_Base obj = sc;
                obj.SetTargetPosition(heldLocation);
                obj.SetInteractable(false);
                obj.Interacted(player, this);
                obj.SetCollisionEnabled(false);
                objectHeld = obj;
                print("GRABBED THIS OBJ");
                Overlaps.Remove(sc);
                 
                 
            } 
            itemHeld = true;
        }
        
    }

    public void SetItemHeld(bool held)
    {
        itemHeld = held;
    }
}
