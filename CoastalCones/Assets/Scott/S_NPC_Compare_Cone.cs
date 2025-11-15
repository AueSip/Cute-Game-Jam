using System.Collections.Generic;
using UnityEngine;



public class S_NPC_Compare_Cone : S_Placement_Pos
{

    public S_NPC npc;

    
    private GameManager gameManager;

    private float experienceReward = 100f;

    private float ratingReward = 1f;
    public IceCreams iceCream;

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
            IceCreams other = GetCodeObject().ReturnIceCream();

            


            if (CompareIceCreams(other, iceCream))
            {
                print("Correct IceCream");
                RewardPlayerForSale(true,GetPlayerIceCream().GetComponent<S_IceCreamObject>().iceCream);
                gameManager.npcAudioManager.PlayFinishedList();
            }
            else
            {
                print("WRONG ICECREAM");
                RewardPlayerForSale(false,GetPlayerIceCream().GetComponent<S_IceCreamObject>().iceCream);
                gameManager.npcAudioManager.PlayNegativeSound();
            }
            
            
            gameManager.npcSpawnManagement.NPCServed();
            gameManager.SetPlayerItemHeld(false);
            Destroy(GetPlayerIceCream());

        }


    }

    public void RewardPlayerForSale(bool correct, IceCreams iceCreams)
    {   
        float finalReward = 0f;
        ratingReward = 1;
        int slashReward = 1;
        if (!correct)
        {
            slashReward = 2;
            ratingReward = -ratingReward;
        }

       if (iceCreams.cones != null && iceCreams.cones.Length > 0 && iceCreams.cones[0] != null)
         finalReward += iceCreams.cones[0].value / slashReward;

        if (iceCreams.toppings != null && iceCreams.toppings.Length > 0 && iceCreams.toppings[0] != null)
            finalReward += iceCreams.toppings[0].value / slashReward;

        if (iceCreams.sauces != null && iceCreams.sauces.Length > 0 && iceCreams.sauces[0] != null)
            finalReward += iceCreams.sauces[0].value / slashReward;

        if (iceCreams.beverages != null && iceCreams.beverages.Length > 0 && iceCreams.beverages[0] != null)
            finalReward += iceCreams.beverages[0].value / slashReward;

        if (iceCreams.flavors != null && iceCreams.flavors.Length > 0 && iceCreams.flavors[0] != null)
            finalReward += iceCreams.flavors[0].value / slashReward;


        gameManager.SetMoney((int)(gameManager.GetMoney() + finalReward));
        gameManager.SetRating((int)(gameManager.GetRating() + ratingReward));
        gameManager.SetExperience((int)(gameManager.GetExperience() + experienceReward/slashReward));
    }


    bool CompareIceCreams(IceCreams playerCream, IceCreams npcCream)
    {   
        bool temp = false;
        bool ctemp = false;
        bool ftemp = false;
        bool ttemp = false;
        bool stemp = false;
        bool btemp = false;
       if (playerCream.cones[0].name == npcCream.cones[0].name ||
            (playerCream.cones[0] == null && npcCream.cones[0] == null))
        {
            ctemp = true;
        }

        if (playerCream.flavors[0].name == npcCream.flavors[0].name ||
            (playerCream.flavors[0] == null && npcCream.flavors[0] == null))
        {
            ftemp = true;
        }

        if (playerCream.toppings[0].name == npcCream.toppings[0].name ||
            (playerCream.toppings[0] == null && npcCream.toppings[0] == null))
        {
            ttemp = true;
        }

        if (playerCream.sauces[0].name == npcCream.sauces[0].name ||
            (playerCream.sauces[0] == null && npcCream.sauces[0] == null))
        {
            stemp = true;
        }

        if (playerCream.beverages[0].name == npcCream.beverages[0].name ||
            (playerCream.beverages[0] == null && npcCream.beverages[0] == null))
        {
            btemp = true;
        }



        if (ctemp && ftemp && ttemp && stemp && btemp  )
        {
            temp = true;
        }

        return temp;
    }   

    



}