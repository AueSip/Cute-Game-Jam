using System.Collections.Generic;
using UnityEngine;



public class S_Topping_Machine : S_Placement_Pos
{

    public string machineDispenses;

    public JSONReader listofItems;
    public override void OnMinigameComplete()
    {
        base.OnMinigameComplete();
        GetCodeObject().UpdateToppingMesh(listofItems.ReturnThisTopping(machineDispenses));
    }




}