using System.Collections.Generic;
using UnityEngine;



public class S_Beverage_Machine : S_Placement_Pos
{

    public string machineDispenses;

    public JSONReader listofItems;
    public override void OnMinigameComplete()
    {   
        base.OnMinigameComplete();
        GetCodeObject().UpdateBeverageMesh(listofItems.ReturnThisBeverage(machineDispenses));
    }




}