using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerController : MonoBehaviour
{   
    private Vector2 l;

    public S_Interact interact;
    private  Vector3 lookRot;
    private GameObject player_camera;
    public float speed_of_camera = 0.5f;

    public bool activeCam = false;
    private bool camera_lock = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCameraLock(true);
        player_camera = GameObject.Find("pf_Player");
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (!camera_lock)
        {   
            Looking();
        }
       
    }

    public void SetCameraLock(bool val)
    {
        camera_lock = val;
        if (camera_lock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void OnLook(InputValue value)
    {
        l = value.Get<Vector2>();
    }

    void Looking()
    {
        // Mouse input accumulates rotation
        lookRot.y += l.x * speed_of_camera;  // Yaw
        lookRot.x -= l.y * speed_of_camera; // Pitch inverted

        // Clamp vertical rotation
        lookRot.x = Mathf.Clamp(lookRot.x, -90f, 90f);

        // Apply rotation
        player_camera.transform.localRotation = Quaternion.Euler(lookRot.x, lookRot.y, 0f);
    }

    public void OnLockCamera(InputValue value)
    {
        //toggles the lock
        SetCameraLock(!camera_lock);
    }

    public void OnPickUp(InputValue value)
    {
        print("Interacted");

        interact.CallInteract(player_camera);
    }
}
