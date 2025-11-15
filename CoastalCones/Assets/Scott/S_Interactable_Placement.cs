using UnityEngine;

public class S_Placement_Pos : MonoBehaviour
{   


    bool itemPlaced = false;
    private S_IceCreamObject playerIceCreamCode;
    GameObject iceCreamObj;
    public Transform GetObjectPlaceTarget()
    {
        return this.transform;
    }

    public void PlacedIceCream(GameObject iceCream)
    {
        iceCreamObj = iceCream; 
        SetPieceValue();
        SetItemPlaced(true);
        print("PLACED IT");
        
        //DEBUG ON COMPLETION
        if (itemPlaced)
        {
            OnMinigameComplete();
        }
    }

    public virtual void OnMinigameComplete()
    {

    }

    public void SetItemPlaced(bool val)
    {
        itemPlaced = val;
    }

     public bool GetItemPlaced()
    {
        return itemPlaced;
    }



    public GameObject GetPlayerIceCream()
    {
        return iceCreamObj;
    }


    public void SetPieceValue()
    {
         SetCodeObject(GetPlayerIceCream().GetComponent<S_IceCreamObject>());

       
    }

    public void SetCodeObject(S_IceCreamObject obj)
    {
        playerIceCreamCode = obj;
    }

    public S_IceCreamObject GetCodeObject()
    {
        return playerIceCreamCode;
    }

    public virtual void UpdatePiece()
    {
       
    }

}