using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class S_NPC_SpawnManager : MonoBehaviour
{    
    bool moving = false;
    public GameObject npc;

    public Transform leaveLocation;
    public float move_to_location_time;

    public float move_to_delete_time = 5f;
    public List<Transform> locationsForNPCS;

    public Transform initial_Spawn;

    List<GameObject> all_npcs = new();

    private GameManager gameManager;

    float happyTime = 30f;

    float currentHappyTime;

    float waitTimeMin;

    float waitTimeMax;


    //TEMP
    private S_IceCreamGenerator iceCreamGenerator;
    public S_Interact interactionPlayer;


    void Start()
    {   
      
    }

    public void Init(GameManager gm)
    {    
        gameManager = gm;       
        iceCreamGenerator = GameObject.Find("GameManager").GetComponent<S_IceCreamGenerator>();
        happyTime = gameManager.npc_timer;
        waitTimeMax = gameManager.npc_timerMax;
        waitTimeMin = gameManager.npc_timerMin;
        NPC_SpawnLoop();
        NPC_TimerLoop();
    }
    public void SpawnNPC()
    {
        if (all_npcs.Count < locationsForNPCS.Count)
        {
            GameObject tempNPC = Instantiate(npc, initial_Spawn);
            tempNPC.GetComponent<S_NPC>().SetRequest(iceCreamGenerator.ReturnIceCream());
            all_npcs.Add(tempNPC);
            
        }
       
    }

    public void RemoveNPC(List<GameObject> pf_NPCS)
    {
        GameObject first = pf_NPCS[0];
        pf_NPCS.RemoveAt(0);
        StartCoroutine(MoveAndDelete(first,first.transform, leaveLocation));
        /*if (pf_NPCS != null && pf_NPCS.Count > 0)
        {
             pf_NPCS[0].GetComponent<S_AnimatorManager>().SetSpeaking();
        }*/
       
        
    }

    public List<GameObject> UpdateNPCPositions(List<GameObject> pf_NPCS)
    {

        for (int i = 0; i < pf_NPCS.Count; i++)
        {   
            StartCoroutine(MoveToNewPosition(pf_NPCS[i],pf_NPCS[i].transform,locationsForNPCS[i].transform));
            
        }
        ;

        //Debug testing npc spawns
       
       
        
        return pf_NPCS;
    }
    
    IEnumerator MoveToNewPosition(GameObject target,Transform startPosition, Transform endPosition)
    {   
        moving = true;
        float timeElapsed = 0;
        Vector3 tempPos = startPosition.position;
        Quaternion tempRot = startPosition.rotation;
        while (timeElapsed < move_to_location_time)
        {
            tempPos = Vector3.Lerp(startPosition.position, endPosition.position, timeElapsed / move_to_location_time);
            tempRot = Quaternion.Lerp(startPosition.rotation, endPosition.rotation, timeElapsed / move_to_location_time);
            timeElapsed += Time.deltaTime;
            target.transform.SetPositionAndRotation(tempPos, tempRot);
            yield return null;
        }
        UpdateTransform(target,endPosition);
        all_npcs[0].GetComponent<S_AnimatorManager>().SetSpeaking();
        gameManager.npcAudioManager.PlayAppearList();
        moving = false;;
    }
    //I HATE THIS BUT IT WORKS
    IEnumerator MoveAndDelete(GameObject target,Transform startPosition, Transform endPosition)
    {
        moving = true;
        float timeElapsed = 0;
        Vector3 tempPos = startPosition.position;
        Quaternion tempRot = startPosition.rotation;
        while (timeElapsed < move_to_delete_time)
        {
            tempPos = Vector3.Lerp(startPosition.position, endPosition.position, timeElapsed / move_to_delete_time);
            tempRot = Quaternion.Lerp(startPosition.rotation, endPosition.rotation, timeElapsed / move_to_delete_time);
            timeElapsed += Time.deltaTime;
            target.transform.SetPositionAndRotation(tempPos, tempRot);
            yield return null;
        }
        UpdateTransform(target,endPosition);
        
        moving = false;
        Destroy(target);
    }

    public void UpdateTransform(GameObject target,Transform endPosition)
    {
        target.transform.SetPositionAndRotation(endPosition.position, endPosition.rotation);
    }
    

    public void SpawnNPCAndMoveLocation()
    {  
       SpawnNPC();
       UpdateNPCPositions(all_npcs);


        IceCreams iceCream = all_npcs[0].GetComponent<S_NPC>().GetIceCream();
        
        print("I GENERATED THIS NEW ICECRREAM" + " CONE: " + iceCream.cones[0].name  + " FLAVOR: " + iceCream.flavors[0].name + " TOP: " + iceCream.toppings[0].name  + " SAUCE: " +  iceCream.sauces[0].name + " BEVERAGE: " + iceCream.beverages[0].name);
        print("This ice cream costs: " + (iceCream.cones[0].cost + iceCream.flavors[0].cost + iceCream.toppings[0].cost + iceCream.sauces[0].cost + iceCream.beverages[0].cost) + " Euros");
        
       
    }

    public IceCreams GetFirstNPCIceCream()
    {  
       
        return all_npcs[0].GetComponent<S_NPC>().GetIceCream();
      
    }

    public void NPCServed()
    {
        RemoveNPC(all_npcs);
        currentHappyTime = happyTime;
        UpdateNPCPositions(all_npcs);
    }

    public async void NPC_TimerLoop()
    {   
        ManageHappyTime();
        await Awaitable.WaitForSecondsAsync(1f);
        NPC_TimerLoop();
    }

    public async void NPC_SpawnLoop()
    {   
        SpawnNPCAndMoveLocation();
        
        float rn = Random.Range(waitTimeMin, waitTimeMax-gameManager.GetRating());
        await Awaitable.WaitForSecondsAsync(rn);
        
        NPC_SpawnLoop();
    }


    public void ManageHappyTime()
    {   
        if (all_npcs.Count > 0)
        {
            currentHappyTime--;
           
            if (currentHappyTime <= 0)
            {
                NPCServed();
                
            }
        print("CURRENT WAIT: " + currentHappyTime);
        }
        else {
            currentHappyTime = happyTime;
           
        }
        gameManager.ReturnUIManager().UpdateTimer((int)currentHappyTime);
        
    }
}