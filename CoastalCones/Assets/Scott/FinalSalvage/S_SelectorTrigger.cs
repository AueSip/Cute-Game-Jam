using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_SelectorTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool ActiveTrigger = false;

    private float rotAddition = 70f;
    private float move_to_location_time = 1f;

    public S_Flavor_Machine flavorMachine;

    private Quaternion defRot;


    
    void Start()
    {
        defRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {  
         
        if (Mouse.current.leftButton.wasPressedThisFrame && ActiveTrigger)
        {
            StartTrigger();
        }

    }

    public void StartTrigger()
        {   
            ActiveTrigger = false;
            // Compute final rotation (add 90 to X axis)
            Quaternion startRot = transform.rotation;
            Quaternion endRot = Quaternion.Euler(
                transform.eulerAngles.x + rotAddition ,
                transform.eulerAngles.y ,
                transform.eulerAngles.z 
            );

            // Start rotation coroutine
            StartCoroutine(RotateToNewRotation(gameObject, startRot, endRot));
        }

    

    IEnumerator RotateToNewRotation(GameObject target, Quaternion startRot, Quaternion endRot)
        {
            float timeElapsed = 0f;

            while (timeElapsed < move_to_location_time)
            {
                float t = timeElapsed / move_to_location_time;

                target.transform.rotation = Quaternion.Lerp(startRot, endRot, t);

                timeElapsed += Time.deltaTime;
                yield return null;
            }

            target.transform.rotation = endRot; // ensure exact final rotation
            flavorMachine.Finish();
            ResetRotation();
        }

    public void SetActiveTrigger(bool val)
    {
        ActiveTrigger = val;
    }

    public void ResetRotation()
    {
        gameObject.transform.rotation = defRot;
    }

    
}
