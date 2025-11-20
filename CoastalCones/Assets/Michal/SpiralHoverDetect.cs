using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpiralHoverDetect : MonoBehaviour
{
    public Camera MiniGameCam;
    public LineRenderer lineRenderer;
    public float hoverThreshold = 0.02f;

    private bool[] hoveredPoints;  
    private int hoveredCount = 0;

    void Start()
    {
        hoveredPoints = new bool[lineRenderer.positionCount];
    }

    void Update()
{
    if (lineRenderer == null) return;
    if (hoveredPoints == null || hoveredPoints.Length != lineRenderer.positionCount)
    {
        hoveredPoints = new bool[lineRenderer.positionCount];
        hoveredCount = 0; 
    }

    if (!MiniGameCam.enabled) return;
    if (Mouse.current == null) return;

    Ray ray = MiniGameCam.ScreenPointToRay(Mouse.current.position.ReadValue());
    Plane plane = new Plane(Vector3.up, lineRenderer.GetPosition(0));

    if (plane.Raycast(ray, out float enter))
    {
        Vector3 mouseWorldPos = ray.GetPoint(enter);

        //for loop checks every point in linerender 1 by 1
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            if (!hoveredPoints[i] && Vector3.Distance(mouseWorldPos, lineRenderer.GetPosition(i)) < hoverThreshold)
            {
                hoveredPoints[i] = true;
                hoveredCount++;
            }
        }
    }

    float completionPercent = (float)hoveredCount / lineRenderer.positionCount;
    if (completionPercent >= 0.8f)
    {
        MiniGameCam.enabled = false;
        GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
        hoveredCount = 0;
        //recounts each point makes them false so minigame is replayable :)
        for (int i = 0; i < hoveredPoints.Length; i++)
            hoveredPoints[i] = false;

    }
}

}
