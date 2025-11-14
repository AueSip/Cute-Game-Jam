using System.Collections.Generic;
using UnityEngine;



public class S_NPC_Compare_Cone : S_Placement_Pos
{

    private S_NPC npc;
    private GameManager gameManager;

    private IceCream iceCream;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>;
    }
    public override void OnMinigameComplete()
    {   
        base.OnMinigameComplete();
        iceCream = gameManager.npcSpawnManagement.GetFirstNPCIceCream();

        if (iceCream == GetCodeObject().ReturnIceCream())
        {
            
        }
        else
        {
            
        }

        Destroy(GetPlayerIceCream());

        
    }




}