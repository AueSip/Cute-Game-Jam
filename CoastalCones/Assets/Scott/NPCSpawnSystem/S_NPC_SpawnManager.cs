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
    
    void Start()
    {
        SpawnNPCAndMoveLocation();
    }
    public void SpawnNPC()
    {
        GameObject tempNPC = Instantiate(npc,initial_Spawn);
        all_npcs.Add(tempNPC);
        print("SPAWNED");
    }

    public void RemoveNPC(List<GameObject> pf_NPCS)
    {
        GameObject first = pf_NPCS[0];
        pf_NPCS.RemoveAt(0);
        pf_NPCS.Add(first);
    }

    public List<GameObject> UpdateNPCPositions(List<GameObject> pf_NPCS)
    {

        for (int i = 0; i < pf_NPCS.Count; i++)
        {   
            StartCoroutine(MoveToNewPosition(pf_NPCS[i],pf_NPCS[i].transform,locationsForNPCS[i].transform));
            
        }
        ;

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
        UpdateTransform(endPosition);
        moving = false;;
    }

    public void UpdateTransform(Transform endPosition)
    {
        this.transform.SetPositionAndRotation(endPosition.position, endPosition.rotation);
    }
    

    public async void SpawnNPCAndMoveLocation()
    {   
        print("STARTING");
        await Awaitable.WaitForSecondsAsync(1f);
        SpawnNPC();
        await Awaitable.WaitForSecondsAsync(2f);
        UpdateNPCPositions(all_npcs);
        print("STARTING");
        await Awaitable.WaitForSecondsAsync(1f);
        SpawnNPC();
        await Awaitable.WaitForSecondsAsync(2f);
        UpdateNPCPositions(all_npcs);
        print("STARTING");
        await Awaitable.WaitForSecondsAsync(1f);
        SpawnNPC();
        await Awaitable.WaitForSecondsAsync(2f);
        RemoveNPC(all_npcs);
        await Awaitable.WaitForSecondsAsync(2f);
        UpdateNPCPositions(all_npcs);
        
        print("UpdateNPCPositions");
        SpawnNPCAndMoveLocation();
    }

}