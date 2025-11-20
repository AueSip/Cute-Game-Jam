using UnityEngine;
using UnityEngine.InputSystem;
public class FlavourMinigame : MonoBehaviour
{
    public Camera FlavourCam;
    public Camera MiniiCam;
    public LineRenderer lineRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void TestRay()
    {
        if (!MiniiCam.enabled) return;
        string objectname;
        Ray ray = MiniiCam.ScreenPointToRay(Mouse.current.position.ReadValue()); // Create a ray from the mouse position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            objectname = hit.collider.gameObject.name;
            if (objectname == "Vanilla Machine")
            {
                print("Vanilla");
                lineRenderer.startColor = Color.beige;
                lineRenderer.endColor = Color.beige;
                MiniiCam.enabled = false;
                FlavourCam.enabled = true;
            }

            objectname = hit.collider.gameObject.name;
            if (objectname == "Bubblegum Machine")
            {
                print("Bubble");
                lineRenderer.startColor = Color.mediumPurple;
                lineRenderer.endColor = Color.mediumPurple;
                MiniiCam.enabled = false;
                FlavourCam.enabled = true;
            }

            objectname = hit.collider.gameObject.name;
            if (objectname == "Strawberry Machine")
            {
                print("Strawberry");
                lineRenderer.startColor = Color.pink;
                lineRenderer.endColor = Color.pink;
                MiniiCam.enabled = false;
                FlavourCam.enabled = true;
            }

            objectname = hit.collider.gameObject.name;
            if (objectname == "Choco Machine")
            {
                print("Choco");
                lineRenderer.startColor = Color.saddleBrown;
                lineRenderer.endColor = Color.saddleBrown;
                MiniiCam.enabled = false;
                FlavourCam.enabled = true;
            }

            objectname = hit.collider.gameObject.name;
            if (objectname == "Mint Machine")
            {
                print("Mint");
                lineRenderer.startColor = Color.lawnGreen;
                lineRenderer.endColor = Color.lawnGreen;
                MiniiCam.enabled = false;
                FlavourCam.enabled = true;
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
            if (FlavourCam.enabled == true)
            {
                FlavourCam.enabled = false;
                GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;

            }
        }
    }
}
