using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public S_DayCycle dayCycleSC;
    public PlayerReader playerReader;
    int money;
    int experience;
    int rating;
    int currentDay;
    public float npc_timer;
    public float npc_timerMax;
    public float npc_timerMin;


    List<string> bought_machines;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetValue();
        GameLoop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameLoop()
    {

        Debug.Log("Day Start");
        dayCycleSC.Startday();
    }

    public void DoEndDay(){
        
    }

    public void SpawnNPCS()
    {

    }

    public void SetValue()
    {

        experience = playerReader.ReturnPlayerSave().experience;
        print(experience);

        rating = playerReader.ReturnPlayerSave().rating;
        print(rating);

        money = playerReader.ReturnPlayerSave().money;
        print(money);

        bought_machines = playerReader.ReturnPlayerSave().bought_machines;
        print(bought_machines);

        currentDay = playerReader.ReturnPlayerSave().currentDay;
        print(currentDay);
    }

}
