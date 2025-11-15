using System.Collections.Generic;
using UnityEngine;

public class S_NPC : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private IceCreams ice_creams_request = new();

    public S_BubbleChecker bubbleChecker;
    

    public void SetRequest(IceCreams ice)
    {
        ice_creams_request = ice;
        bubbleChecker.SetThisRequest(GetIceCream());
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
