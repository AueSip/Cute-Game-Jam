using System.Threading;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public class S_DayCycle : MonoBehaviour
{
    public float DayLength = 300f;
    private float CurrentTime = 0f;
    public bool dayRunning = false;

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
    }
    
    public bool IsDayOver()
    {
        return !dayRunning;
    }
    
}
