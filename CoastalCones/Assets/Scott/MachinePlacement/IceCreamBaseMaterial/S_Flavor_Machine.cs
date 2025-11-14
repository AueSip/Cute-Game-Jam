using System.Collections.Generic;
using UnityEngine;



public class S_Flavor_Machine : S_Placement_Pos
{

    public string machineDispenses;

    public JSONReader listofItems;
    public override void OnMinigameComplete()
    {
        base.OnMinigameComplete();
        GetCodeObject().UpdateIceCreamMesh(listofItems.ReturnThisFlavor(machineDispenses));
    }




}