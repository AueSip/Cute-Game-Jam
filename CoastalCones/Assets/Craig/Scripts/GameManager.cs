using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public S_DayCycle dayCycleSC;
    public PlayerReader playerReader;
    public SaveData saveData;
    public S_IceCreamGenerator iceCreamGenerator;
    public S_NPC_SpawnManager npcSpawnManagement;
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
        iceCreamGenerator.Init();
        npcSpawnManagement.Init();
        dayCycleSC.gm = this;

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

    public void DoEndDay()
    {
        saveData.playerSave.experience = experience;
        saveData.playerSave.rating = rating;
        saveData.playerSave.money = money;
        saveData.playerSave.currentDay = currentDay + 1; // day advance
        saveData.playerSave.bought_machines = bought_machines;
        saveData.SaveToJson();
    }

    public void SpawnNPCS()
    {

    }

    public void GetIceCreamGenerator()
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
