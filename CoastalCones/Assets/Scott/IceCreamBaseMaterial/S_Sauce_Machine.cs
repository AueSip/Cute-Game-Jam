using System.Collections.Generic;
using UnityEngine;



public class S_Sauce_Machine : S_Placement_Pos
{

    public string machineDispenses;

    public JSONReader listofItems;
    public override void OnMinigameComplete(string str)
    {
        base.OnMinigameComplete(str);
        GetCodeObject().UpdateSauceMesh(listofItems.ReturnThisSauce(machineDispenses));
    }




}