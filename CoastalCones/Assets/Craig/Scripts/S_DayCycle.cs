using System.Threading;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class S_DayCycle : MonoBehaviour
{
    public float DayLength = 300f;
    private float CurrentTime = 0f;
    public bool dayRunning = false;

    public GameObject directionalLight;
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dayRunning)
        {
            CurrentTime += Time.deltaTime;
            gm.uiManager.UpdateDialRotation(CurrentTime, DayLength);
            UpdateDirectionalLight(CurrentTime, DayLength);
            if (CurrentTime >= DayLength)
            {
                EndDay();
            }
        }
    }

    public void Startday()
    {
        CurrentTime = 0f;
        dayRunning = true;
        
    }

    public void EndDay()
    {
        dayRunning = false;

        if (gm != null)
        {
            gm.DoEndDay();
        }

    }
    
    public bool IsDayOver()
    {
        return !dayRunning;
    }

    public void UpdateDirectionalLight(float value, float maxTime)
{
    float t = Mathf.Clamp01((float)value / maxTime);

    
    float angle = t * 270f;

    
    directionalLight.transform.rotation = Quaternion.Euler(angle, 0, 0);
}
    
}
