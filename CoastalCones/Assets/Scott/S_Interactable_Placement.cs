using UnityEngine;

public class S_Placement_Pos : MonoBehaviour
{   

    public JSONReader listReader;
    
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

    }

    public virtual void OnMinigameComplete(string str)
    {

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