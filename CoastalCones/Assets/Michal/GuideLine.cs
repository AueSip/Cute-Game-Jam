using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GuideLine : MonoBehaviour
{
    public Transform sphere;         
    public int turns = 4;            
    public int pointsPerTurn = 50;   
    public float heightOffset = 0.05f;
    public Camera MiniGameCam;
    private LineRenderer line;
    private bool spiralGenerated = false;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;

    }
    void Update()
    {   
        
        //checks if minigamecam is on and if the spiral is generated then creates line
        if (MiniGameCam.enabled && !spiralGenerated)
        {
            GenerateSpiral();
            line.enabled = true;
            spiralGenerated = true;
        }
        if (!MiniGameCam.enabled && line.enabled)
        {
            line.enabled = false;
            spiralGenerated = false; 
        }
        if (!MiniGameCam.enabled && line.enabled)
        {
            line.enabled = false;
            spiralGenerated = false;  
        }
    }
    void GenerateSpiral()
    {
        float radius = 0.5f * sphere.localScale.x;  
        int totalPoints = turns * pointsPerTurn;
        line.positionCount = totalPoints;

        Vector3 center = sphere.position;
        //placement of spiral
        float y = center.y + (sphere.localScale.y * 0.5f) + heightOffset;
        //loop to create spiral
        for (int i = 0; i < totalPoints; i++)
        {
            //spiral shrink
            float t = (float)i / totalPoints;
            float angle = turns * 2 * Mathf.PI * t;

            float currentRadius = radius * (1 - t);
            //calc point
            float x = currentRadius * Mathf.Cos(angle);
            float z = currentRadius * Mathf.Sin(angle);
            //place point
            line.SetPosition(i, new Vector3(center.x + x, y, center.z + z));
        }
        //that boy thick
        line.startWidth = 0.01f;
        line.endWidth = 0.005f;
    }  
}
