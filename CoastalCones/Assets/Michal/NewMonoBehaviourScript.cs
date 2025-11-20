using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public Camera MiniGameCame;
    public TopppingZone zone;
    private float completion = 0f;
    public List<string> toppings = new List<string>();
    Ray ray;
    RaycastHit hit;
    public float yOffset = -0.7f;
    private Vector3 originalPosistion;
    void Start()
    {
        originalPosistion = transform.position;
        
    }
    private void TestRay()
    {
        string objectname;
        Ray ray = MiniGameCame.ScreenPointToRay(Mouse.current.position.ReadValue()); // Create a ray from the mouse position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // Perform the raycast
        {
            objectname = hit.collider.gameObject.name;
            if (objectname == "Sprinkles")
            {
                toppings.Clear();
                toppings.Add("Sprinkles");
            }
            objectname = hit.collider.gameObject.name;
            if (objectname == "Flakes")
            {
                toppings.Clear();
                toppings.Add("Flakes");
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (!MiniGameManager.isToppingMiniGameActive) return;
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TestRay();
        }
        if (MiniGameCame.enabled)
        {
            Vector3 pos = Mouse.current.position.ReadValue();
            pos.z = 1.2f;
            Vector3 worldPos = MiniGameCame.ScreenToWorldPoint(pos);
            worldPos.y += yOffset;
            transform.position = worldPos;
        }
        foreach (string topping in toppings)
        {
            Debug.Log(topping);
        }
        if (toppings.Count > 0 && Keyboard.current.spaceKey.isPressed && zone.ScoopInside)
                {
                completion += 0.1f;
                print("Inside");
                }

        
        if (completion >= 100f)
        {
            transform.position = originalPosistion;
            MiniGameCame.enabled = false;
            GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
            completion = 0f;
            toppings.Clear();
            MiniGameManager.isToppingMiniGameActive = false;
        }

    }
}
