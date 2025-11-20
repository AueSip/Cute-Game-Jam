using UnityEngine;
using UnityEngine.InputSystem;
public class SauceItUp : MonoBehaviour
{
    public Camera SauceMiniGameCam;
    private bool isGrabbed = false;
    public float distanceFromCamera = 1.2f;
    private bool hasRotated = false;
    private Quaternion originalRotation;
    private Vector3 originalPosistion;
    public float completion;
    public SauceZone zone;
    void Start()
    {
        originalRotation = transform.rotation;
        originalPosistion = transform.position;
        
    }

    void Update()
    {
        if (!MiniGameManager.isSauceMiniGameActive) return;
        if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Ray ray = SauceMiniGameCam.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        isGrabbed = true;
                        hasRotated = false;
                    }
                }   
            }
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            transform.rotation = originalRotation;
            transform.position = originalPosistion;
            isGrabbed = false;
        }
        if (isGrabbed && SauceMiniGameCam.enabled )
        {
            if (!hasRotated)
            {
                transform.Rotate(Vector3.up, 180);
                hasRotated = true;
            }
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = distanceFromCamera;
            transform.position = SauceMiniGameCam.ScreenToWorldPoint(mousePos);
            if (zone.sauceInside)
                {
                completion += 0.1f;
                print("Inside");
                }
        }
    if (completion >= 100f)
        {
            transform.rotation = originalRotation;
            transform.position = originalPosistion;
            SauceMiniGameCam.enabled = false;
            GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
            completion = 0f;
            MiniGameManager.isSauceMiniGameActive = false;
        }


    }
}