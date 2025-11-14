
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public S_DayCycle dayCycleSC;
    public PlayerReader playerReader;
    public SaveData saveData;
    public S_IceCreamGenerator iceCreamGenerator;
    public S_NPC_SpawnManager npcSpawnManagement;

    public S_Ui_Manager uiManager;

    public S_IceCreamObject iceCreamObj;
    public Transform iceCreamSpawnLocation;
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
       GameLoop();
    }

    // Update is called once per frame
    void Update()
    {

    }

     public void SetExperience(int value)
    {
        experience = value;
         uiManager.UpdateExperience(experience);
    }

    public int GetExperience()
    {
        return experience;
    }

     public void SetRating(int value)
    {
        rating = value;
        uiManager.UpdateRatingScale(rating);
    }

    public int GetRating()
    {
        return rating;
    }

     public void SetMoney(int value)
    {
        money = value;
        uiManager.UpdateCurrency(money);
    }

    public int GetMoney()
    {
        return money;
    }

        public void SetBoughtMachines(List<string> machines)
    {
        bought_machines = new List<string>(machines); // makes a clean copy
    }

    public void AddBoughtMachine(string machineName)
    {
        if (!bought_machines.Contains(machineName))
        {
            bought_machines.Add(machineName);
        }
    }

    public List<string> GetBoughtMachines()
    {
        return bought_machines;
    }

       public void SetCurrentDay(int value)
    {
        currentDay = value;
        uiManager.UpdateDay(currentDay);
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }





    public void GameLoop()
    {

        Debug.Log("Day Start");
        dayCycleSC.Startday();
        SetValue();
        iceCreamGenerator.Init(this);
        npcSpawnManagement.Init(this);
        dayCycleSC.gm = this;
        SpawnIceCream();
        
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
        SetExperience(playerReader.ReturnPlayerSave().experience);
        print(experience);
       
        SetRating(playerReader.ReturnPlayerSave().rating);
        print(rating);
        
        SetMoney(playerReader.ReturnPlayerSave().money);
        print(money);
        
        SetBoughtMachines(playerReader.ReturnPlayerSave().bought_machines);
        print(bought_machines);

        SetCurrentDay(playerReader.ReturnPlayerSave().currentDay);
        print(currentDay);
        
    }


    public async void SpawnIceCream()
    {
        S_IceCreamObject temp = Instantiate(iceCreamObj,iceCreamSpawnLocation);
        temp.Init(this);
        await Awaitable.WaitForSecondsAsync(5f);
        SpawnIceCream();
    }

    public S_Ui_Manager ReturnUIManager()
    {   
       return uiManager;
    }

   
    
   

}
