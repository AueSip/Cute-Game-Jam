using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public S_DayCycle dayCycleSC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameLoop()
    {

        Debug.Log("Day Start");
        dayCycleSC.Startday();

        while (!dayCycleSC.IsDayOver())
        {
            SpawnNPCS();
        }
    }

    public void SpawnNPCS()
    {

    }

    public void AddValue( )
    {
        
    }

}
