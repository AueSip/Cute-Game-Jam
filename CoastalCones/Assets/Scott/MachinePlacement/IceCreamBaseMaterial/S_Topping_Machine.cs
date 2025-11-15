using System.Collections.Generic;
using UnityEngine;



public class S_Topping_Machine : S_Placement_Pos
{

     public Script_Sound_Player soundManager;
    public string machineDispenses;

    public JSONReader listofItems;
    public override void OnMinigameComplete()
    {
        base.OnMinigameComplete();
        GetCodeObject().UpdateToppingMesh(listofItems.ReturnThisTopping(machineDispenses));
        soundManager.PlayMachineList(2);
    }




}