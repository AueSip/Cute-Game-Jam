using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SauceMiniGame : MonoBehaviour
{
    public float completion;
    public float servesped;
    public Camera MiniGameCam;

    Ray ray;
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    private void TestRay()
    {
        string objectname;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()); // Create a ray from the mouse position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // Perform the raycast
        {
            objectname = hit.collider.gameObject.name;
            if (objectname == "Sbutton")
            {
                GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;
                MiniGameCam.enabled = true;
                MiniGameManager.isSauceMiniGameActive = true;
                MiniGameManager.isToppingMiniGameActive = false;

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
                MiniGameManager.isSauceMiniGameActive = false;
                MiniGameManager.isToppingMiniGameActive = false;
            }
        }
    }
    
}
