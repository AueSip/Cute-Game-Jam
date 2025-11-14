using System.Collections.Generic;
using UnityEngine;



public class S_Trash_Can : S_Placement_Pos
{

    public JSONReader listofItems;
    public override void OnMinigameComplete()
    {   
        base.OnMinigameComplete();
        Destroy(GetPlayerIceCream());
    }




}