using System.Collections.Generic;
using UnityEngine;



public class S_NPC_Compare_Cone : S_Placement_Pos
{

    public S_NPC npc;

    
    private GameManager gameManager;

    private IceCreams iceCream;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        iceCream = npc.GetIceCream();
    }
    public override void OnMinigameComplete()
    {   
        base.OnMinigameComplete();
        if (GetPlayerIceCream() != null)
        {
            iceCream = gameManager.npcSpawnManagement.GetFirstNPCIceCream();

            if (iceCream == GetCodeObject().ReturnIceCream())
            {
                print("Correct IceCream");
            }
            else
            {
                print("WRONG ICECREAM");
            }
            
            Destroy(GetPlayerIceCream());
            gameManager.npcSpawnManagement.NPCServed();

        }
       
        
    }




}