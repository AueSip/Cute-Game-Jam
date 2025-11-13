using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class S_NPC_SpawnManager : MonoBehaviour
{    
    bool moving = false;
    public GameObject npc;

    public float move_to_location_time;
    public List<Transform> locationsForNPCS;

    public Transform initial_Spawn;

    List<GameObject> all_npcs = new();

    //TEMP
    public S_IceCreamGenerator iceCreamGenerator;
    
    void Start()
    {
        SpawnNPCAndMoveLocation();
    }
    public void SpawnNPC()
    {
        if (all_npcs.Count < locationsForNPCS.Count)
        {
            GameObject tempNPC = Instantiate(npc,initial_Spawn);
            tempNPC.GetComponent<S_NPC>().SetRequest(iceCreamGenerator.ReturnIceCream());
            all_npcs.Add(tempNPC);
        }
       
    }

    public void RemoveNPC(List<GameObject> pf_NPCS)
    {
        GameObject first = pf_NPCS[0];
        pf_NPCS.RemoveAt(0);
        pf_NPCS.Add(first);

        IceCreams iceCream = pf_NPCS[0].GetComponent<S_NPC>().GetIceCream();
        print("I GENERATED THIS NEW ICECRREAM" + " CONE: " + iceCream.cones[0].name  + " FLAVOR: " + iceCream.flavors[0].name + " TOP: " + iceCream.toppings[0].name  + " SAUCE: " +  iceCream.sauces[0].name + " BEVERAGE: " + iceCream.beverages[0].name);
        print("This ice cream costs: " + (iceCream.cones[0].cost + iceCream.flavors[0].cost + iceCream.toppings[0].cost + iceCream.sauces[0].cost + iceCream.beverages[0].cost) + " Euros");
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
        moving = false;;
    }

    public void UpdateTransform(GameObject target,Transform endPosition)
    {
        target.transform.SetPositionAndRotation(endPosition.position, endPosition.rotation);
    }
    

    public async void SpawnNPCAndMoveLocation()
    {   
       
        await Awaitable.WaitForSecondsAsync(1f);
        SpawnNPC();
        await Awaitable.WaitForSecondsAsync(2f);
        UpdateNPCPositions(all_npcs);
    
        await Awaitable.WaitForSecondsAsync(1f);
        SpawnNPC();
        await Awaitable.WaitForSecondsAsync(2f);
        UpdateNPCPositions(all_npcs);
       
        await Awaitable.WaitForSecondsAsync(1f);
        SpawnNPC();
        await Awaitable.WaitForSecondsAsync(2f);
        RemoveNPC(all_npcs);
        await Awaitable.WaitForSecondsAsync(2f);
        UpdateNPCPositions(all_npcs);
        
       
        SpawnNPCAndMoveLocation();
    }

}