using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class S_Interactable_Object : S_Interactable_Base
{

    float move_to_hand_time = 2f;

    private Coroutine moveCoroutine;
    
    Transform originalLocation;

    S_Interact interactComp;

    

    public override void InitialisationOfObject()
    {   
        originalLocation = this.transform;
        SetObjectPlaceTarget(originalLocation);
       
    }

    public override void Interacted(GameObject player, S_Interact interactComps)
    {
        base.Interacted(player, interactComps);
        interactComp = interactComps;
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        
        moveCoroutine = StartCoroutine(MoveToHand(GetObjectPosition(), GetTargetPosition()));
    }

    public Transform GetObjectPosition()
    {
        return this.transform;
    }

    
    
   


    void Update()
    {
       
    }

    IEnumerator MoveToHand(Transform startPosition, Transform endPosition)
    {
        SetMoving(true);
        float timeElapsed = 0;
        Vector3 tempPos = startPosition.position;
        Quaternion tempRot = startPosition.rotation;
        while (timeElapsed < move_to_hand_time)
        {
            tempPos = Vector3.Lerp(startPosition.position, endPosition.position, timeElapsed / move_to_hand_time);
            tempRot = Quaternion.Lerp(startPosition.rotation, endPosition.rotation, timeElapsed / move_to_hand_time);
            timeElapsed += Time.deltaTime;
            this.transform.SetPositionAndRotation(tempPos, tempRot);
            yield return null;
        }
        UpdateTransform(endPosition);
        SetMoving(false);
    }

    public void UpdateTransform(Transform endPosition)
    {
        this.transform.SetPositionAndRotation(endPosition.position, endPosition.rotation);
    }





}
