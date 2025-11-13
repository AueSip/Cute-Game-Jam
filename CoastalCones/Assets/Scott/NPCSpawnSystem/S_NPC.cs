using System.Collections.Generic;
using UnityEngine;

public class S_NPC : S_Interactable_Base
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private IceCreams ice_creams_request = new();
    public override void Interacted(GameObject player, S_Interact interactComps)
    {
       
    }
    

    public override void InitialisationOfObject()
    {

    }

    public void SetRequest(IceCreams ice)
    {
        ice_creams_request = ice;
    }

    public IceCreams GetIceCream()
    {
        return ice_creams_request;
    }
    // Update is called once per frame
    void Update()
    {

    }

}
