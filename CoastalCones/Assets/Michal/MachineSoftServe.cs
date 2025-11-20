using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MachineSoftServe : MonoBehaviour
{
    public GameObject locationToSpawn;
    public float completion;
    public float servesped;
    public GameObject vanillaCream;
    public Camera MiniGameCam;
    public GameObject guideline;
    Ray ray;
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        guideline.SetActive(false);
    }
    private void TestRay()
    {
        string objectname;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()); // Create a ray from the mouse position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // Perform the raycast
        {
            objectname = hit.collider.gameObject.name;
            if (objectname == "Sphere")
            {
                GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;
                MiniGameCam.enabled = true;
                guideline.SetActive(true);

            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TestRay();
        }
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {  
            if (MiniGameCam.enabled == true)
            {
                MiniGameCam.enabled = false;
                GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
                guideline.SetActive(false);
            }
        }
    }
    
}
