using Unity.VisualScripting;
using UnityEngine;

public class S_ItemToCheckFor : MonoBehaviour
{   

    public string itemName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Locked()
    {
        this.gameObject.transform.SetPositionAndRotation(new Vector3(gameObject.transform.position.x,gameObject.transform.position.y - 500,gameObject.transform.position.z), this.gameObject.transform.rotation);
    }

    public string GetName()
    {
       return itemName;
    }
}
