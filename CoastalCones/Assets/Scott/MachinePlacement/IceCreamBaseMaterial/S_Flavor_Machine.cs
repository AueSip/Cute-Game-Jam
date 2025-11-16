using System.Collections.Generic;
using UnityEngine;



public class S_Flavor_Machine : S_Placement_Pos
{

     public Script_Sound_Player soundManager;

     public S_SelectorTrigger triggerTarget;
    public string machineDispenses;

    public Camera miniCam;



    public Camera mainCam;
    public JSONReader listofItems;
    public override void OnMinigameComplete()
    {
        base.OnMinigameComplete();
        SetActiveCamera(true);
        triggerTarget.SetActiveTrigger(true);
    }

    public void SetActiveCamera(bool val)
    {
        if (val)
        {   
            mainCam.enabled = false;
            miniCam.enabled = true;
        }
        else
        {
            mainCam.enabled = true;
            miniCam.enabled = false;
        }
    }

    public void Finish()
    {
        GetCodeObject().UpdateIceCreamMesh(listofItems.ReturnThisFlavor(machineDispenses));
        soundManager.PlayMachineList(0);
        SetActiveCamera(false);
    }




}