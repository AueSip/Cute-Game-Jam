using UnityEngine;

public class S_Interactable_Base : MonoBehaviour
{

    public bool interactable;

    bool moving = false;
    
    Transform placeTarget;
    Transform targetPos;

    Collider collisionCol;
    //public Script_Game_Manager gameInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collisionCol = GetComponent<Collider>();
       // gameInstance = FindFirstObjectByType<Script_Game_Manager>();
        InitialisationOfObject();
    }


    //Interactivity Can Be Taken From Child
    public bool SetInteractable(bool value)
    {
        return interactable = value;
    }

    public bool GetInteractable()
    {
        return interactable;
    }

    public virtual void Interacted(GameObject player, S_Interact interactComps)
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    public bool GetMoving()
    {
        return moving;
    }

    public bool SetMoving(bool val)
    {
        return moving = val;
    }
    public void SetTargetPosition(Transform pos)
    {
        targetPos = pos;
    }

    public Transform GetTargetPosition()
    {
        return targetPos;
    }

    public Transform GetObjectPlaceTarget()
    {
        return placeTarget;
    }

    public void SetObjectPlaceTarget(Transform val)
    {
        placeTarget = val;
    }

    public virtual void InitialisationOfObject()
    {

    }

    public void SetCollisionEnabled(bool colval)
    {
        collisionCol.enabled = colval;
    }

    public void UpdateThisTransform(Transform tran)
    {
        this.transform.SetPositionAndRotation(tran.position,tran.rotation);
    }
    
    
}
